using System;
using System.IO;
using System.Web.SessionState;
using GleamTech.Reflection;
using GleamTech.Web;

namespace GleamTech.FileUltimateExamples.Common
{
    [HttpHandlerSessionState(SessionStateBehavior.ReadOnly)]
    public class ExamplesExplorerHandler : JsonMethodHandler
    {
        public string GetDescription(string descriptionFile)
        {
            var type = GetType();
            using (var stream = AssemblyResourceHelper.GetResourceStream(type.Assembly, type.Namespace, descriptionFile))
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }

        public string GetSourceFile(string assemblyResourceLocator, string sourceFile)
        {
            var type = Type.GetType(assemblyResourceLocator );
            using (var stream = AssemblyResourceHelper.GetResourceStream(type.Assembly, type.Namespace, sourceFile))
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}