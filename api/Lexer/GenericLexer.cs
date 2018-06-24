using System.Collections.Generic;

namespace GeneralScript.Api.Lexer
{
    /// <summary>
    /// This class represents a generic lexer. A lexer is used to seperate a program into individual "tokens".
    /// This is a bare bones, not implemented version of a lexer. This class should be
    /// extended and the <see cref="_lex"/> method should be overriden if you want to make your own lexer. All of the
    /// other methods will be taken care of, and should not be overriden.
    /// </summary>
    public abstract class GenericLexer
    {
        /// <summary>
        /// The internal command used to lex a file. This is the method which is overriden, and handles the bulk of the
        /// lexing process.
        /// </summary>
        /// <param name="p">The file to lex</param>
        /// <returns>A list of lexed tokens</returns>
        protected abstract List<LexedToken> _lex(File p);
        
        /// <summary>
        /// The main method that is called by the Api to lex a file. This will handle to instantiation of a
        /// <see cref="LexerResult"/> and will set the lexer inside of the file to that result.
        /// </summary>
        /// <param name="p">The file to lex</param>
        public void Lex(File p)
        {
            p.SetLexer(_generateResult(_lex(p)));
        }

        private LexerResult _generateResult(List<LexedToken> tokens)
        {
            return new LexerResult(this, tokens);
        }
    }
}