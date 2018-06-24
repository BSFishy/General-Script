using GeneralScript.Api.ActionTree.Tokens.Operator;
using GeneralScript.Api.ActionTree.Types;
using GeneralScript.Api.ActionTree.Types.Number;

namespace GeneralScript.Api.Default.Runtime.ActionTree.Operator
{
    public class Arithmatic
    {
        public class Add : ArithmaticToken
        {
            public Add() :
                base((left, right) => new Integer().Setup(((ConstantType)left).Output() + ((ConstantType)left).Output()))
            {
            }
        }
        
        public class Subtract : ArithmaticToken
        {
            public Subtract() :
                base((left, right) => new Integer().Setup(((ConstantType)left).Output() - ((ConstantType)left).Output()))
            {
            }
        }
        
        public class Multiply : ArithmaticToken
        {
            public Multiply() :
                base((left, right) => new Integer().Setup(((ConstantType)left).Output() * ((ConstantType)left).Output()))
            {
            }
        }
        
        public class Divide : ArithmaticToken
        {
            public Divide() :
                base((left, right) => new Integer().Setup(((ConstantType)left).Output() / ((ConstantType)left).Output()))
            {
            }
        }
    }
}