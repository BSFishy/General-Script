using System;

namespace GeneralScript.Api.ActionTree.Tokens.Operator
{
    public abstract class ArithmaticToken : SidedOperatorToken
    {
        protected ArithmaticToken(Func<IHasOutput, IHasOutput, ActionTreeToken> dele) : base(EType.Num, EType.Num, EType.Num, dele)
        {
        }
    }
}