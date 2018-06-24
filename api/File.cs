using System;
using GeneralScript.Api.ActionTree;
using GeneralScript.Api.Lexer;
using GeneralScript.Api.Parser;

namespace GeneralScript.Api
{
    /// <summary>
    /// This represents a GeneralScript file. The file can be lexed, parsed, generate an action tree, then referenced by the main program.
    /// </summary>
    public class File
    {
        private LexerResult _lexer;
        private ParserResult _parser;
        private ActionTreeResult _actionTree;

        /// <summary>
        /// The result of the lexer. This contains the lexer itself(for future lexing), as well as the list of lexed tokens
        /// </summary>
        public LexerResult Lexer => _lexer;
        /// <summary>
        /// The result of the parser. This contains the parser itself(for future parsing), as well as the structured tokens
        /// </summary>
        public ParserResult Parser => _parser;
        /// <summary>
        /// The result of the action tree generator. This contains the action tree generator(for future generation), as well
        /// as the action tree itself.
        /// </summary>
        public ActionTreeResult ActionTree => _actionTree;

        private readonly string _code;

        /// <summary>
        /// The source code that this object represents.
        /// </summary>
        public string Code => _code;

        /// <summary>
        /// The constructor for a file. Once this is instantiated, a lexer, parser, or action tree generator can be ran on
        /// this to generate their respective output. Run these in order, though, because if not, they will throw an error.
        /// </summary>
        /// <param name="code">The code this object represents</param>
        public File(string code)
        {
            _code = code;
        }

        /// <summary>
        /// Set the lexer for this file. This should only be ran internally from the lexer itself.
        /// </summary>
        /// <param name="result">The result of the lexer</param>
        public void SetLexer(LexerResult result)
        {
            if(_lexer != null)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Attempted to set the lexer multiple times");
            
            _lexer = result;
        }

        /// <summary>
        /// Set the parser for this file. This should only be ran internally from the parser itself.
        /// </summary>
        /// <param name="result">The result of the parser</param>
        public void SetParser(ParserResult result)
        {
            if(_parser != null)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Attempted to set the parser multiple times");
            _parser = result;
        }

        /// <summary>
        /// Set the action tree for this file. This should only be ran internally from the action tree generator itself.
        /// </summary>
        /// <param name="result">The result of the action tree</param>
        public void SetActionTree(ActionTreeResult result)
        {
            if(_actionTree != null)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Attempted to set the action tree multiple times");
            _actionTree = result;
        }
    }
}