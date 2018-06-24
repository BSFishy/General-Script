using System.Collections.Generic;
using GeneralScript.Api.ActionTree.Tokens.Container.Block;

namespace GeneralScript.Api.ActionTree.Tokens.Statement
{
    public abstract class BlockStatementCommand : CommandToken, IBlockToken<CommandToken>
    {
        private readonly List<CommandToken> _children = new List<CommandToken>();
        protected readonly Scope Scope = new Scope();

        public void AddChild(CommandToken child)
        {
            _children.Add(child);
        }

        public List<CommandToken> GetChildren()
        {
            return _children;
        }

        public Scope GetScope()
        {
            return Scope;
        }
    }
}