namespace GeneralScript.Api.ActionTree.Tokens.Operator
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class OperatorToken : ActionTreeToken, IOperatorToken
    {
        private readonly EType _type;

        protected OperatorToken(EType type)
        {
            _type = type;
        }


        public EType OutputType()
        {
            return _type;
        }
    }
}