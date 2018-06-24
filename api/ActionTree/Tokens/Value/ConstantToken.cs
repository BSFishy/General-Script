namespace GeneralScript.Api.ActionTree.Tokens.Value
{
    public abstract class ConstantToken : ValueToken, IHasConstantOutput
    {
//        public override void Instantiate(params dynamic[] input)
//        {
//            OneArgumentCheck(typeof(IHasConstantOutput), input);
//
//            Value = input[0];
//            Initialize(Value);
//        }

        public dynamic Output()
        {
            return ((IHasConstantOutput) Value).Output();
        }
    }
}