using System.Collections.Generic;

namespace GeneralScript.Api.Parser
{
    /// <summary>
    /// The result of a parsing operation. This contains the parser itself, as well as the parsed tree.
    /// </summary>
    public class ParserResult
    {
        private readonly GenericParser _parser;
        private readonly List<ParsedToken> _tokens = new List<ParsedToken>();

        /// <summary>
        /// The parser used for the operation. This may be usefull for debugging or running the parser again.
        /// </summary>
        public GenericParser Parser => _parser;
        /// <summary>
        /// The tokens, or result of the parser.
        /// </summary>
        public List<ParsedToken> Tokens => _tokens;

        /// <summary>
        /// The constructer of a parsed token. This should not be instantiated anywhere except in the parser, created by the <see cref="GenericParser"/>.
        /// </summary>
        /// <param name="parser">The parser used to create this result</param>
        /// <param name="tokens">The tokens that the parser parsed</param>
        public ParserResult(GenericParser parser, List<ParsedToken> tokens)
        {
            _parser = parser;
            _tokens.AddRange(tokens);
        }
    }
}