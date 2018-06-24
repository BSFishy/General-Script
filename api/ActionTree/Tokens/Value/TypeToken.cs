using GeneralScript.Api.ActionTree.Tokens.Container;

namespace GeneralScript.Api.ActionTree.Tokens.Value
{
    public abstract class TypeToken
    {
        private ContainerToken<ActionTreeToken> _type;

        protected TypeToken(ContainerToken<ActionTreeToken> type)
        {
            _type = type;
        }

        public new ContainerToken<ActionTreeToken> GetType()
        {
            return _type;
        }
    }
}