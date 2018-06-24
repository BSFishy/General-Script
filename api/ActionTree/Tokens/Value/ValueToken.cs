namespace GeneralScript.Api.ActionTree.Tokens.Value
{
    public abstract class ValueToken : ActionTreeToken, IValueToken
    {
        protected IHasOutput Value;

//        protected abstract void Initialize(IHasOutput value);
//
//        public override void Instantiate(params dynamic[] input)
//        {
//            OneArgumentCheck(typeof(IHasOutput), input);
//
//            Value = input[0];
//            Initialize(Value);
//        }
        
        public EType OutputType()
        {
            return Value.OutputType();
        }

        public override ActionTreeToken Perform()
        {
            return Value.Perform();
        }
    }
}