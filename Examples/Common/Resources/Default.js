
var viewport;
var examplesData = [];

Ext.define("ExampleModel", {
    extend: "Ext.data.Model",
    fields: [
            "url",
            "sourceFiles",
            "descriptionFile",
            {
                name: "qtip",
                convert: function (value, record) {
                    return record.get("text");
                }
            }
        ]
});

Ext.onReady(function () {
    var treeStore = Ext.create("Ext.data.TreeStore", {
        model: "ExampleModel",
        proxy: {
            data: examplesData,
            type: "memory"
        }        
    });

    viewport = Ext.create("Ext.container.Viewport", {
        layout: {
            type: "border",
            padding: 5,
            panelCollapseAnimate: false
        },
        items: [{
            region: "west",
            collapsible: true,
            split: true,
            title: "FileUltimate Examples",
            width: 250,
            minWidth: 190,
            id: "ExampleTree",
            xtype: "treepanel",
            store: treeStore,
            rootVisible: false,
            lines: false,
            listeners: {
                beforeselect: function (sm, node) {
                    if (node.isLeaf())
                        return true;
                    else {
                        node.expand();
                        return false;
                    }
                },
                beforeitemdblclick: function (sm, node) {
                    return false;
                },
                select: loadNode
            }
        }, {
            region: "center",
            minWidth: 300,
            title: String.fromCharCode(160),
            id: "ExamplePanel",
            tools: [
                {
                    type: "maximize",
                    tooltip: "Open example in separate window/tab",
                    autoEl: {
                        tag: "a",
                        href: "",
                        target: "_blank",
                        style: "outline: none"
                    }
                }]
        }, {
            region: "east",
            collapsible: true,
            split: true,
            width: 250,
            minWidth: 120,
            bodyPadding: 5,
            //weight: -100,
            title: "Description",
            id: "DescriptionPanel",
            autoScroll: true
        }, {
            region: "south",
            collapsible: true,
            split: true,
            height: 350,
            minHeight: 60,
            weight: -100,
            xtype: "tabpanel",
            minTabWidth: 100,
            title: "Source Code",
            id: "SourceFilesTabPanel",
            tabPosition: "bottom",
            listeners: {
                "tabchange": loadSourceFile
            }
        }]
    });
    
    Ext.tip.QuickTipManager.init(true, { trackMouse: false, showDelay: 500 });

    var exampleTree = Ext.getCmp("ExampleTree");
    var nodeToBeSelected = exampleTree.getRootNode().firstChild.firstChild;
    if (nodeToBeSelected) {
        nodeToBeSelected.parentNode.expand();
        exampleTree.getSelectionModel().select(nodeToBeSelected);
    }
});

function loadNode(sm, node) {
    loadExample(node);
    loadDescription(node);
}

function loadExample(node) {
    var examplePanel = Ext.getCmp("ExamplePanel");
    examplePanel.setTitle(node.getPath("text").replace(/^\/Root\//i, "").replace("/", " > "));

    var openNewTool = examplePanel.tools[0];
    openNewTool.stopEvent = false;
    openNewTool.el.set({ href: node.data.url });

    examplePanel.setLoading(true);
    var iframe = document.getElementById("ExampleIframe");
    if (iframe == null) {
        examplePanel.update('<iframe id="ExampleIframe" style="background-color: transparent; width: 100%; height:100%;" frameborder="0" allowTransparency="true" src="javascript:&quot;&quot;"></iframe>');
        iframe = document.getElementById("ExampleIframe");
        Ext.get(iframe).on("load", function () {
            //autoResize(iframe);
            examplePanel.setLoading(false);
        });
        iframe.src = node.data.url;
    } else
        iframe.src = node.data.url;

    var sourceFilesTabPanel = Ext.getCmp("SourceFilesTabPanel");
    sourceFilesTabPanel.removeAll();
    for (var i = 0; i < node.data.sourceFiles.length; i++) {
        var sourceFile = node.data.sourceFiles[i];
        var parts = sourceFile.split(/\/|\\/);

        sourceFilesTabPanel.add({
            title: parts[parts.length - 1],
            assemblyResourceLocator: node.parentNode.data.assemblyResourceLocator,
            sourceFile: sourceFile,
            autoScroll: true
        });
    }
    sourceFilesTabPanel.setActiveTab(0);
}

function loadDescription(node) {
    var descriptionPanel = Ext.getCmp("DescriptionPanel");
    
    descriptionPanel.setLoading(true);
    Ext.Ajax.request({
        url: "examplesexplorer.ashx/GetDescription",
        method: "POST",
        jsonData: {
            descriptionFile: node.data.descriptionFile
        },
        success: function (response, options) {
            var responseObject = Ext.JSON.decode(response.responseText);
            if (!responseObject.Success) {
                options.failure();
                return;
            }

            var description = responseObject.Result;
            descriptionPanel.update(description);

            descriptionPanel.setLoading(false);
        },
        failure: function () {
            descriptionPanel.update("");
            descriptionPanel.setLoading(false);
        }
    });
}

function loadSourceFile(tabPanel, tab) {
    if (tab.fileAlreadyLoaded)
        return;

    tabPanel.setLoading(true);
    Ext.Ajax.request({
        url: "examplesexplorer.ashx/GetSourceFile",
        method: "POST",
        jsonData: {
            assemblyResourceLocator: tab.assemblyResourceLocator,
            sourceFile: tab.sourceFile
        },
        success: function (response, options) {
            var responseObject = Ext.JSON.decode(response.responseText);
            if (!responseObject.Success) {
                options.failure();
                return;
            }

            var sourceFileText = responseObject.Result;
            var brush;

            if (Ext.String.endsWith(tab.sourceFile, ".cs", true)) {
                brush = new SyntaxHighlighter.brushes.CSharp();
                brush.init({ toolbar: false, brush: "c-sharp" });
            } else if (Ext.String.endsWith(tab.sourceFile, ".vb", true)) {
                brush = new SyntaxHighlighter.brushes.Vb();
                brush.init({ toolbar: false, brush: "vb" });
            } else {
                brush = new SyntaxHighlighter.brushes.Xml();
                brush.init({ toolbar: false, brush: "xml" });
            }

            tab.update(brush.getHtml(sourceFileText));

            tab.fileAlreadyLoaded = true;
            tabPanel.setLoading(false);
        },
        failure: function () {
            tab.update("");
            tabPanel.setLoading(false);
        }
    });
}

function autoResize(iframe) {
    var iframeDocument = iframe.contentDocument || iframe.contentWindow.document;

    iframe.style.width = "0";
    iframe.style.height = "0";

    var width = 0, height = 0;
    if (iframeDocument.documentElement && (iframeDocument.documentElement.scrollWidth || iframeDocument.documentElement.scrollHeight)) {
        width = iframeDocument.documentElement.scrollWidth;
        height = iframeDocument.documentElement.scrollHeight;
    } else if (iframeDocument.body) {
        width = iframeDocument.body.scrollWidth;
        height = iframeDocument.body.scrollHeight;
    }

    iframe.style.width = width + "px";
    iframe.style.height = height + "px";
}