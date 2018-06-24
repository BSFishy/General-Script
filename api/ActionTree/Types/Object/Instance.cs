using GeneralScript.Api.ActionTree.Tokens;
using GeneralScript.Api.ActionTree.Tokens.Container;
using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.ActionTree.Types.Object
{
    public class Instance : ConstantToken
    {
//        public override void Instantiate(params dynamic[] input)
//        {
//            OneArgumentCheck(typeof(ContainerToken<ActionTreeToken>), input);
//
//            Value = new InstanceOutput(input[0]);
//        }

        public void Setup(ContainerToken<ActionTreeToken> container)
        {
            Value = new InstanceOutput(container);
        }

        private class InstanceOutput : IHasConstantOutput
        {
            private readonly ContainerToken<ActionTreeToken> _instance;

            public InstanceOutput(ContainerToken<ActionTreeToken> instance)
            {
                _instance = instance;
            }

            public ActionTreeToken Perform()
            {
                return _instance;
            }

            public EType OutputType()
            {
                return EType.Instance;
            }

            public dynamic Output()
            {
                return _instance;
            }
        }
    }
}