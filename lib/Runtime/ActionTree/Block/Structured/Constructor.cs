using System.Collections.Generic;
using GeneralScript.Api.ActionTree;
using GeneralScript.Api.ActionTree.Tokens.Container;
using GeneralScript.Api.ActionTree.Tokens.Container.Block;
using GeneralScript.Api.ActionTree.Tokens.Special;
using GeneralScript.Api.ActionTree.Tokens.Statement;
using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured
{
    public class Constructor : BlockToken<IStatementToken>, IStructureChild
    {
        private Modifiers.Access _accessModifier = Modifiers.Access.Public;
        
        private readonly List<IArgument> _arguments = new List<IArgument>();

        public void SetAccess(Modifiers.Access access)
        {
            // TODO: is there a check here?
            _accessModifier = access;
        }

        public void AddArgument(IArgument argument)
        {
            if(!_arguments.Contains(argument))
                _arguments.Add(argument);
        }
        
        public override ActionTreeToken Perform()
        {
            return this;
        }

        public void Call(Dictionary<string, ValueHandle> parameters)
        {
            // TODO: implement constructor
        }
    }
}