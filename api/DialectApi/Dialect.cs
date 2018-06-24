namespace GeneralScript.Api.DialectApi
{
    public abstract class Dialect
    {
        private string _name;
        private string _description;
        private string _version;
        
        private string _extension;

        private readonly ParsingApi _api;

        public string Name => _name;
        public string Description => _description;
        public string Version => _version;

        public string Extension => _extension;

        public ParsingApi Api => _api;

        public Dialect(ParsingApi api)
        {
            _api = api;
        }

        public void Initialize(string name, string description, string version, string extension)
        {
            _name = name;
            _description = description;
            _version = version;

            _extension = extension;
        }
    }
}