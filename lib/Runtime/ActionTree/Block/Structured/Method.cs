using System;
using System.Collections.Generic;
using GeneralScript.Api.ActionTree;
using GeneralScript.Api.ActionTree.Tokens.Container;
using GeneralScript.Api.ActionTree.Tokens.Container.Block;
using GeneralScript.Api.ActionTree.Tokens.Special;
using GeneralScript.Api.ActionTree.Tokens.Statement;
using GeneralScript.Api.ActionTree.Tokens.Value;
using GeneralScript.Api.ActionTree.Types.Object;
using GeneralScript.Api.Default.Runtime.ActionTree.Statement.Command;
using GeneralScript.Api.Default.Runtime.ActionTree.Value;

namespace GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured
{
    public class Method : BlockToken<IStatementToken>, IStructureChild
    {
        private string _name;
        
        private Modifiers.Access _accessModifier = Modifiers.Access.Public;
        private readonly List<Modifiers.Description> _descriptionModifiers = new List<Modifiers.Description>();

        private ReturnType _return;
        
        private readonly List<IArgument> _arguments = new List<IArgument>();

        public string Name => _name;

//        public override void Instantiate(params dynamic[] input)
//        {
//            ArgumentCheck(new[] {typeof(IArgument[])}, input);
//
//            _arguments = input[0];
//        }

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

        public void SetReturn(ReturnType type)
        {
            _return = type;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public override ActionTreeToken Perform()
        {
            return this;
        }

        public ValueToken Call(Dictionary<string, ValueHandle> parameters)
        {
            foreach(KeyValuePair<string, ValueHandle> param in parameters)
            {
                Scope.AddVariable(param.Key, param.Value);
            }

            foreach (IArgument arg in _arguments)
            {
                if(!Scope.Variables.ContainsKey(arg.GetName()) && arg.IsRequired())
                    // TODO: implement custom errors
                    throw new ArgumentException("The required argument \"" + arg.GetName() + "\" was not revieved");
            }

            foreach (IStatementToken statment in GetChildren())
            {
                if (statment is Return)
                    return (ValueToken) statment.Perform();
                
                statment.Perform();
            }

            return new Null();
        }
    }
}