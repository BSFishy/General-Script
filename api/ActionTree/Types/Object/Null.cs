using GeneralScript.Api.ActionTree.Tokens;
using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.ActionTree.Types.Object
{
    public class Null : ConstantToken
    {
        //public static readonly Null Constant = new Null();

//        public override void Instantiate(params dynamic[] input)
//        {
//            Value = new NullOutput(this);
//        }

        public void Setup()
        {
            Value = new NullOutput(this);
        }
        
        private class NullOutput : IHasConstantOutput
        {
            private readonly ConstantToken _instance;

            public NullOutput(ConstantToken instance)
            {
                _instance = instance;
            }

            public ActionTreeToken Perform()
            {
                return _instance;
            }

            public EType OutputType()
            {
                return EType.Null;
            }

            public dynamic Output()
            {
                return null;
            }
        }
    }
}