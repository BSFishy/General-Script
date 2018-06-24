using System;
using GeneralScript.Api.ActionTree.Tokens;
using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.ActionTree.Types
{
    public class ConstantType : ConstantToken
    {
        private readonly EType _eType;
        private readonly Type _type;

        public ConstantType(EType eType, Type type)
        {
            _eType = eType;
            _type = type;
        }

//        public override void Instantiate(params dynamic[] input)
//        {
//            OneArgumentCheck(_type, input);
//
//            Value = new ConstantOutput(_eType, input[0], this);
//        }

        public void Setup(dynamic output)
        {
            Value = new ConstantOutput(_eType, output, this);
        }

        private class ConstantOutput : IHasConstantOutput
        {
            private readonly ConstantToken _instance;
            private readonly dynamic _output;
            private readonly EType _type;

            public ConstantOutput(EType type, dynamic output, ConstantToken instance)
            {
                _type = type;
                _output = output;
                _instance = instance;
            }

            public ActionTreeToken Perform()
            {
                return _instance;
            }

            public EType OutputType()
            {
                return _type;
            }

            public dynamic Output()
            {
                return _output;
            }
        }
    }
}