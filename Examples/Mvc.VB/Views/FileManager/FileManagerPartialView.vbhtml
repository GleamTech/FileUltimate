@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.FileUltimate
@ModelType FileManager

Partial view rendered at @DateTime.Now.ToString("T")

@Me.RenderBody(Model)
