using GeneralScript.Api.ActionTree.Tokens.Special;
using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.ActionTree.Tokens.Args
{
    public class Argument : IArgument
    {
        private readonly bool _required;
        private readonly string _name;
        private readonly TypeToken _type;

        public bool Required => _required;
        public string Name => _name;
        public TypeToken Type => _type;

        public Argument(bool required, string name, TypeToken type)
        {
            _required = required;
            _name = name;
            _type = type;
        }

        public string GetName()
        {
            return _name;
        }

        public new TypeToken GetType()
        {
            return _type;
        }

        public bool IsRequired()
        {
            return _required;
        }
    }
}