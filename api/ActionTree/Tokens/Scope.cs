using System.Collections.Generic;
using GeneralScript.Api.ActionTree.Tokens.Container;
using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.ActionTree.Tokens
{
    public class Scope
    {
        // TODO: implement scope
        // Variables, functions, structures

        private Scope _global;
        private Scope _parent;

        public Scope GlobalScope => _global;
        public Scope ParentScope => _parent;
        
        public readonly Dictionary<string, ValueHandle> Variables = new Dictionary<string, ValueHandle>();
        public readonly List<ContainerToken<ActionTreeToken>> Structures = new List<ContainerToken<ActionTreeToken>>();

        public Scope()
        {
            _global = new Scope(true);
            _parent = null;
        }

        private Scope(bool global, Scope parent = null)
        {
            if (global)
            {
                _global = this;
                _parent = null;
            }
            else if(parent != null)
            {
                _global = parent._global;
                _parent = parent;
            }
        }

        public Scope Fork()
        {
            return new Scope(false, this);
        }

        public void AddVariable(string name, ValueHandle value)
        {
            Variables.Add(name, value);
        }
    }
}