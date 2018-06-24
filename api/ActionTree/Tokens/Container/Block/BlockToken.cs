namespace GeneralScript.Api.ActionTree.Tokens.Container.Block
{
    public abstract class BlockToken<T> : ContainerToken<T>, IBlockToken<T>, IHasScope
    {
        protected readonly Scope Scope = new Scope();
        
        public Scope GetScope()
        {
            return Scope;
        }
    }
}