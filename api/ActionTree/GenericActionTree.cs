using System.Collections.Generic;

namespace GeneralScript.Api.ActionTree
{
    /// <summary>
    /// This represents a generic action tree generator. An action tree generator is used to add more structure and definition
    /// to the already structured parsed data. For example, this helps define function calls, giving an input, output, type, etc.
    /// If you would like to make your own generator, extend this class, and override <see cref="_generate"/>. Other than
    /// that, the methods in this class are called internally, and should not be called manually.
    /// </summary>
    public abstract class GenericActionTree
    {
        /// <summary>
        /// This is the main method which generates the action tree. This does the bulk of the lookups, and data definitions.
        /// </summary>
        /// <param name="f">The file to generate the action tree for</param>
        /// <returns>The structured action tree</returns>
        protected abstract List<ActionTreeToken> _generate(File f);
        
        /// <summary>
        /// This is the internal method for generating the action tree. This method is called automatically, and should
        /// not be ran manually.
        /// </summary>
        /// <param name="p">The file to generate the action tree for</param>
        public void Generate(File p)
        {
            p.SetActionTree(_generateActionTreeResult(_generate(p)));
        }

        private ActionTreeResult _generateActionTreeResult(List<ActionTreeToken> tokens)
        {
            return new ActionTreeResult(this, tokens);
        }
    }
}