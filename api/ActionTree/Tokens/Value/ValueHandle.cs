namespace GeneralScript.Api.ActionTree.Tokens.Value
{
    public class ValueHandle
    {
        protected TypeToken Type;
        protected ValueToken Value;

        protected ValueHandle(ValueToken value, TypeToken type)
        {
            Value = value;
            Type = type;
        }

        public TypeToken GetClass()
        {
            return Type;
        }

        public new EType GetType()
        {
            return Value.OutputType();
        }

        public ValueToken GetValue()
        {
            return Value;
        }
    }
}