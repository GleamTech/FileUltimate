using GleamTech.FileUltimateExamples.Common.Resources;
using GleamTech.Reflection;
using GleamTech.Web;

namespace GleamTech.FileUltimateExamples.Common
{
    public static class ExamplesExplorerContext
    {
        private static bool isStarted;

        public static void Start()
        {
            if (isStarted)
                return;

            RegisterRoutes();
            RegisterResources();

            isStarted = true;
        }

        private static void RegisterRoutes()
        {
            HttpHandlerRouteHandler<ExamplesExplorerHandler>.Register();
        }

        private static void RegisterResources()
        {
            AssemblyResourceStore = new AssemblyResourceStore(
                typeof (AssemblyResourceLocator),
                HostingPathHelper.ApplicationPhysicalPath.Append("App_GlobalResources").ToString()
            );
            ResourceManager.Register(AssemblyResourceStore);

            CssBundle = new ResourceBundle(AssemblyResourceStore.Name + "/examples.css")
            {
                {AssemblyResourceStore, @"shCore.css"},
                {AssemblyResourceStore, @"shThemeVS.css"},
                {AssemblyResourceStore, @"Default.css"}
            };
            ResourceManager.Register(CssBundle);

            JsBundle = new ResourceBundle(AssemblyResourceStore.Name + "/examples.js")
            {
                {AssemblyResourceStore, @"shCore.js"},
                {AssemblyResourceStore, @"shBrushCSharp.js"},
                {AssemblyResourceStore, @"shBrushVB.js"},
                {AssemblyResourceStore, @"shBrushXml.js"},
                {AssemblyResourceStore, @"Default.js"}
            };
            ResourceManager.Register(JsBundle);
        }

        internal static AssemblyResourceStore AssemblyResourceStore { get; private set; }

        public static ResourceBundle CssBundle { get; private set; }

        public static ResourceBundle JsBundle { get; private set; }
    }
}
