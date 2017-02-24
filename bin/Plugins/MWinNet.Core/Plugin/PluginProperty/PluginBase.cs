using System;

namespace MWinNet.Core
{
    public class PluginBase : ICloneable
    {
        public string Path
        {
            get; set;
        }

        public string AssemblyName
        {
            get; set;
        }

        public string ClassName
        {
            get; set;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        protected void InitializePlugin()
        {
            Plugin.InitializePlugin(this.Clone() as PluginBase);
        }
    }
}
