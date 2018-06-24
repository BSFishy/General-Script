using System;
using System.Collections.Generic;
using System.Data;
using GeneralScript.Api.ActionTree;
using GeneralScript.Api.ActionTree.Tokens.Container;
using GeneralScript.Api.ActionTree.Tokens.Statement;
using GeneralScript.Api.ActionTree.Tokens.Value;
using GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured;

namespace GeneralScript.Api.Default.Runtime.ActionTree.Statement.Command
{
    public class CallFunction : CommandToken
    {
        private ContainerToken<ActionTreeToken> _container;

        private string _methodName;

        private readonly Dictionary<string, ValueHandle> _arguments = new Dictionary<string, ValueHandle>();

        public void SetContainer(ContainerToken<ActionTreeToken> container)
        {
            if(_container != null)
                // TODO: create cutsom error
                throw new ArgumentException("Cannot set container multiple times");

            _container = container;
        }

        public void SetMethodName(string name)
        {
            if(_methodName != null)
                // TODO: create custom error
                throw new ArgumentException("Cannot set method name multiple times");

            _methodName = name;
        }

        public void AddArgument(string name, ValueHandle argument)
        {
            if(!_arguments.ContainsKey(name))
                _arguments.Add(name, argument);
        }
        
        public override ActionTreeToken Perform()
        {
            Method m = null;
            
            // TODO: optimize this(set during initialization rather than runtime)
            foreach (ActionTreeToken child in _container.GetChildren())
            {
                if (child is Method)
                {
                    if (((Method) child).Name == _methodName)
                    {
                        m = (Method) child;
                        break;
                    }
                }
            }

            if (m == null)
            {
                // TODO: custom error
                throw new DataException("Method not found: " + _methodName);
            }

            return m.Call(_arguments);
        }
    }
}