using System;
using System.IO;
using GeneralScript.Api.DialectApi;

namespace GeneralScript.Api
{
    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// The top-level class for the GeneralScript programming language. GeneralScript is a general purpose domain specific language, meaning
    /// that it is general purpose, in a specific environment. An environment could be anything from a standalone program,
    /// to a game, to a sub-langauge inside another program. To get started
    /// </summary>
    public class GS
    {
        public static void LoadDialects()
        {
            DialectLoader.Load(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "dialects");
        }
        
        /// <summary>
        /// Creates a program for manipulation before it is actually ran. It is recommended that you use <see cref="System.IO.File.ReadAllText(String)"/>
        /// in order to get all of the text in a file
        /// </summary>
        /// <param name="code">The code to be ran</param>
        /// <returns>The program which was generated from the code</returns>
        public static Program CreateProgram(string code)
        {
            return new Program(code);
        }

        /// <summary>
        /// <see cref="CreateProgram(string)"/>
        /// </summary>
        /// <param name="lines"><see cref="CreateProgram(string)"/></param>
        /// <returns><see cref="CreateProgram(string)"/></returns>
        public static Program CreateProgram(string[] lines)
        {
            string code = "";

            foreach (string line in lines)
            {
                code += "\n" + line;
            }
            
            return CreateProgram(code);
        }
        
        /// <summary>
        /// The main method to run a file. This will generate a program, lex, parse, and generate an action tree, then
        /// do the same for any imports, then actually run the program. The program will be returned, for any debugging or information
        /// getting.
        /// </summary>
        /// <param name="program">The program to be ran</param>
        /// <returns>The program after the run has finished</returns>
        public static Program Run(Program program)
        {
            program.Run();
            return program;
        }
        
        /// <summary>
        /// <see cref="Run(Program)"/>
        /// </summary>
        /// <param name="code"><see cref="Run(Program)"/></param>
        /// <returns><see cref="Run(Program)"/></returns>
        public static Program Run(string code)
        {
            return Run(CreateProgram(code));
        }
        
        /// <summary>
        /// <see cref="Run(Program)"/>
        /// </summary>
        /// <param name="lines"><see cref="Run(Program)"/></param>
        /// <returns><see cref="Run(Program)"/></returns>
        public static Program Run(string[] lines)
        {
            return Run(CreateProgram(lines));
        }
    }
}