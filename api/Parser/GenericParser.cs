using System.Collections.Generic;

namespace GeneralScript.Api.Parser
{
    /// <summary>
    /// A generic parser that structures lexed tokens. The parser is called through <see cref="Parse"/>. This class
    /// can also be extended to provide an actual parsing method.
    /// </summary>
    public abstract class GenericParser
    {
        /// <summary>
        /// The method that actually does the parsing. This method is the bulk of the operation at this point in time,
        /// and structures the lexed output to provide a very informative tree of tokens.
        /// </summary>
        /// <param name="p">The program that is being parsed</param>
        /// <returns>A list of structured tokens</returns>
        protected abstract List<ParsedToken> _parse(File p);
        
        /// <summary>
        /// Parse the specified program. This method will generate a <see cref="ParserResult"/> and set the given program's
        /// <see cref="Program.Parser"/> to that result. In order to generate the parsed data, the overriden <see cref="_parse"/>
        /// method is called.
        /// </summary>
        /// <param name="p">The program to parse</param>
        public void Parse(File p)
        {
            p.SetParser(_generateResult(_parse(p)));
        }

        private ParserResult _generateResult(List<ParsedToken> tokens)
        {
            return new ParserResult(this, tokens);
        }
    }
}