using System;
using System.Collections.Generic;

namespace GeneralScript.Api.ActionTree
{
    /// <summary>
    /// Represents a token super-type. This is what all tokens extend in order to be valid tokens, and in order to be ran
    /// properly. Custom tokens can be created in order to make a custom dialect of GeneralScript, but be aware that another
    /// custom <see cref="GenericActionTree"/> will need to be made.
    /// </summary>
    public abstract class ActionTreeToken
    {
//        /// <summary>
//        /// The method called to initialize the data for the token. This can inclide information such as modifiers for a
//        /// block, or types for a variable, etc. This needs to be implemented in the <see cref="GenericActionTree"/>, similar
//        /// to <see cref="Perform"/>, in order to work properly.
//        /// </summary>
//        /// <param name="input">The input data for the token</param>
//        public abstract void Instantiate(params dynamic[] input);
        
        /// <summary>
        /// The main method called when running the code. This will provide the method with any required inputs, and
        /// allows for dynamic outputs. It is recommended that a class extends a class from the <see cref="GeneralScript.Parsing.Generic.ActionTree.Tokens"/>
        /// namespace, as those classes provide a more specific scope.
        /// 
        /// For a token to work properly, it must be implemented properly in the <see cref="GenericActionTree"/>. The inputs
        /// and outputs can be properly handled if that is done, but otherwise it will not work.
        /// </summary>
        /// <returns>The output data for the token</returns>
        public abstract ActionTreeToken Perform();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedType"></param>
        /// <param name="inputs"></param>
        protected void OneArgumentCheck(Type expectedType, params dynamic[] inputs)
        {
            ArgumentCheck(new[] {expectedType}, inputs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedTypes"></param>
        /// <param name="inputs"></param>
        /// <exception cref="ArgumentException"></exception>
        protected void ArgumentCheck(Type[] expectedTypes, params dynamic[] inputs)
        {
            if (expectedTypes == null)
                return;
            
            if(inputs.Length != expectedTypes.Length)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Invalid number of arguments passed. Expected " + expectedTypes.Length + " but got " + inputs.Length);

            for (int x = 0; x < inputs.Length; x++)
            {
                dynamic input = inputs[x];
                Type expectedType = expectedTypes[x];
                
                if(input.GetType() != expectedType)
                    // TODO: fix these exceptions as custom errors
                    throw new ArgumentException("Recieved bad argument when trying to instantiate a token");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedTypes1"></param>
        /// <param name="expectedTypes2"></param>
        /// <param name="inputs"></param>
        protected void RequiredArgumentCheck(Type[] expectedTypes1, Type[] expectedTypes2, params dynamic[] inputs)
        {
            List<Type> types;
            
            if (expectedTypes1 != null)
            {
                types = new List<Type>(expectedTypes1);
                
                if(expectedTypes2 != null)
                    types.AddRange(expectedTypes2);
            }
            else if (expectedTypes2 != null)
            {
                types = new List<Type>(expectedTypes2);
            }
            else
            {
                return;
            }

            ArgumentCheck(types.ToArray(), inputs);
        }
    }
}