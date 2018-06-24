﻿using System.Collections.Generic;

namespace GeneralScript.Api.ActionTree
{
    /// <summary>
    /// A representation of the result of an action tree. This contains data about the action tree generator, and the
    /// result of that generator on a specific file. This is instantiated internally, and should not be called manually.
    /// </summary>
    public class ActionTreeResult
    {
        private readonly GenericActionTree _actionTree;
        private readonly List<ActionTreeToken> _tokens = new List<ActionTreeToken>();

        /// <summary>
        /// The action tree generator used to generate the tokens.
        /// </summary>
        public GenericActionTree ActionTree => _actionTree;
        /// <summary>
        /// The tokens generated by the action tree generator.
        /// </summary>
        public List<ActionTreeToken> Tokens => _tokens;

        /// <summary>
        /// The constructor for the result of an action tree generator. Again, this is called internally, and should not
        /// be called manually.
        /// </summary>
        /// <param name="tree">The generator used to generate the tokens</param>
        /// <param name="tokens">The tokens generated by the action tree generator</param>
        public ActionTreeResult(GenericActionTree tree, List<ActionTreeToken> tokens = null)
        {
            _actionTree = tree;
            if(tokens != null)
                _tokens.AddRange(tokens);
        }
    }
}