using System.Collections.Generic;

namespace GeneralScript.Api.Lexer
{
    /// <summary>
    /// This represents the results of a lexer. This is instantiated internally, and should not be called manually.
    /// </summary>
    public class LexerResult
    {
        private readonly GenericLexer _lexer;
        private readonly List<LexedToken> _tokens;

        /// <summary>
        /// This is the lexer used to get the resulting tokens.
        /// </summary>
        public GenericLexer Lexer => _lexer;
        /// <summary>
        /// These are the tokens which the lexer outputted.
        /// </summary>
        public List<LexedToken> Tokens => _tokens;

        /// <summary>
        /// This is the constructor for a lexer result. Again, this is called internally, and should not be called
        /// manually.
        /// </summary>
        /// <param name="lexer">The lexer used to do the lexing</param>
        /// <param name="tokens">The tokens the lexer outputted</param>
        public LexerResult(GenericLexer lexer, List<LexedToken> tokens)
        {
            _lexer = lexer;
            _tokens = tokens;
        }
    }
}