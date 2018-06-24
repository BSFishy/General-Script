using System;
using System.Collections.Generic;
using GeneralScript.Api.ActionTree;
using GeneralScript.Api.ActionTree.Tokens;
using GeneralScript.Api.ActionTree.Tokens.Container;
using GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured.InterfaceSpecific;

namespace GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured
{
    public class Interface : ContainerToken<IInterfaceChild>, IStructureChild, IHasScope, IModifiable
    {
        private Scope _scope;

        private Modifiers.Access _accessModifier;
        private List<Modifiers.Description> _descriptionModifiers;
        
//        public override void Instantiate(params dynamic[] input)
//        {
//            ArgumentCheck(new[] {typeof(Modifiers.Access), typeof(List<Modifiers.Description>), typeof(Scope)}, input);
//
//            _accessModifier = input[0];
//            _descriptionModifiers = input[1];
//            _scope = input[2];
//        }

        public void SetAccess(Modifiers.Access access)
        {
//            if (_accessModifier != null)
//            {
//                // TODO: use custom error
//                throw new ArgumentException("Cannot set access modifier multiple times");
//            }

            _accessModifier = access;
        }

        public void AddModifier(Modifiers.Description modifier)
        {
            if(!_descriptionModifiers.Contains(modifier))
                _descriptionModifiers.Add(modifier);
        }

        public void SetScope(Scope scope)
        {
            if(_scope != null)
                // TODO: use custom error
                throw new ArgumentException("Cannot set scope multiple times");

            _scope = scope;
        }

        public override ActionTreeToken Perform()
        {
            return this;
        }

        public Scope GetScope()
        {
            return _scope;
        }

        public Modifiers.Access GetAccess()
        {
            return _accessModifier;
        }

        public List<Modifiers.Description> GetModifiers()
        {
            return _descriptionModifiers;
        }
    }
}