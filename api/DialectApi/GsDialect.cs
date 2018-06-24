using System.Runtime.InteropServices;

namespace GeneralScript.Api.DialectApi
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    public class GsDialect : System.Attribute
    {
        private string _name;
        private string _description;
        private string _version;
        
        private string _extension;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        public string Version
        {
            get => _version;
            set => _version = value;
        }

        public string Extension
        {
            get => _extension;
            set => _extension = value;
        }
    }
}