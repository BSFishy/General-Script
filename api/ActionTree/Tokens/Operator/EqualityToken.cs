using System;

namespace GeneralScript.Api.ActionTree.Tokens.Operator
{
    public abstract class EqualityToken : SidedOperatorToken
    {
        protected EqualityToken(EType left, EType right, Func<IHasOutput, IHasOutput, ActionTreeToken> dele) : base(EType.Bool, left, right, dele)
        {
        }
    }
}