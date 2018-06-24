using System.Collections.Generic;
using GeneralScript.Api.Lexer;

namespace GeneralScript.Api.Parser
{
    /// <summary>
    /// A token representing something in the language. This could be a command, a block, or something smaller, like a string or an operator.
    /// Note that this is parsed, and should have structure. This means that commands should have all of the arguments and variables, and
    /// operations should have all of the inputs, etc.
    /// </summary>
    public class ParsedToken
    {
        private readonly LexedToken _token;
        private readonly List<LexedToken> _children = new List<LexedToken>();

        /// <summary>
        /// The base or identification token of this object. This is the container, and specifies what this token is used for.
        /// </summary>
        public LexedToken Token => _token;
        /// <summary>
        /// The children of this token. This includes all of the inputs, operators, etc. These children should not be referenced anywhere
        /// except for here.
        /// </summary>
        public List<LexedToken> Children => _children;

        /// <summary>
        /// The constructor used to make a parsed token. This should be called when a token is completely parsed, and all of the
        /// child tokens are instantiated, so that this token can be instantiated.
        /// </summary>
        /// <param name="token">The identification token</param>
        /// <param name="children">The children of this token</param>
        public ParsedToken(LexedToken token, List<LexedToken> children = null)
        {
            _token = token;
            if(children != null)
                _children.AddRange(children);
        }
    }
}