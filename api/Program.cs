namespace GeneralScript.Api
{
    /// <summary>
    /// A representation of a GeneralScript program. This class handles storage of the lexer, parser, and action tree, as well as the source code.
    /// This also contains other files which should be loaded into the path.
    /// </summary>
    public class Program : File
    {
        /// <summary>
        /// The constructor to create a program. This should not be called by anything except for <see cref="GS"/>, as it
        /// does other operations to make the program instantiate or run differently
        /// </summary>
        /// <param name="code"></param>
        public Program(string code) : base(code)
        {
            
        }

        /// <summary>
        /// Run the program. This is assuming all of the other API's and whatnot are already setup. If those are not setup,
        /// an exception will be thrown.
        /// </summary>
        public void Run()
        {
            ParsingApi.Lex(this);
            ParsingApi.Parse(this);
            ParsingApi.BuildActionTree(this);
        }
    }
}