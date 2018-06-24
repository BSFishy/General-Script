using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;
using GeneralScript.Api.DialectApi;
using GeneralScript.Api.VirtualMachineApi;

namespace GeneralScript.Api
{
    /// <summary>
    /// The API used to lex, parse, and generate the action tree from. These methods are called from within the program, and
    /// don't need to be called a second time.
    /// 
    /// If you want to set the Api to a different one, simply call the <see cref="SetApi"/> method with the new Api,
    /// and that Api will be used for all of the functions.
    /// 
    /// If you want to make your own system, make a class extending this one,
    /// override <see cref="_lex"/>, <see cref="_parse"/>, and <see cref="_buildActionTree"/>.
    /// </summary>
    // TODO: allow to setup different dialects/VM's
    public abstract class ParsingApi
    {
        //// <summary>
        //// A multi-pass method of parsing. This will run each individual method by itself(parse, lex, action tree) and
        //// get each result set of that. The constant re-iteration over all of the tokens may slow down compile time, though
        //// it may also increase performance during the runtime.
        //// </summary>
        //public static readonly ParsingApi Default = new DefaultApi();

        /// <summary>
        /// The internal command called to lex a file.
        /// </summary>
        /// <param name="p">The file to lex</param>
        protected abstract void _lex(File p);
        
        /// <summary>
        /// The internal command called to parse a file.
        /// </summary>
        /// <param name="p">The file to parse</param>
        protected abstract void _parse(File p);

        /// <summary>
        /// The internal command called to build the action tree for a file.
        /// </summary>
        /// <param name="p">The file to build the action tree for</param>
        protected abstract void _buildActionTree(File p);

        private static ParsingApi _api;

        private static Dialect _dialect;
        private static VirtualMachine _virtualMachine;
        
        private static List<Dialect> _dialects = new List<Dialect>();
        private static List<VirtualMachine> _virtualMachines = new List<VirtualMachine>();

        /// <summary>
        /// The method used to set the Api with. This will determine which method to use when lexing, parsing, and
        /// building the action tree for the files.
        /// </summary>
        /// <param name="api">The new Api to use</param>
        /// <exception cref="ArgumentException">In the event the Api is attempted to be set multiple times</exception>
        public static void SetApi(ParsingApi api)
        {
            if(_api != null)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Cannot set the API multiple times");
            
            _api = api;
        }

        public static void SetDialect(Dialect dialect)
        {
            if(_dialect != null)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Cannot set the dialect multiple times");

            _dialect = dialect;
            SetApi(_dialect.Api);
        }

        public static void SetVirtualMachine(VirtualMachine virtualMachine)
        {
            if(_virtualMachine != null)
                // TODO: fix these exceptions as custom errors
                throw new ArgumentException("Cannot set the virtual machine multiple times");

            _virtualMachine = virtualMachine;
        }

        public static void AddDialect(Dialect dialect)
        {
            if (!_dialects.Contains(dialect))
            {
                _dialects.Add(dialect);
            }
        }

        public static void AddVirtaulMachine(VirtualMachine virtualMachine)
        {
            if (!_virtualMachines.Contains(virtualMachine))
            {
                _virtualMachines.Add(virtualMachine);
            }
        }

        /// <summary>
        /// The main method called to lex a file. This method is called internally in a program, and is not required to be
        /// called manually.
        /// </summary>
        /// <param name="p">The file to lex</param>
        public static void Lex(File p)
        {
            _checkApi();
            _api._lex(p);
        }

        /// <summary>
        /// The main method called to parse a file. This method is called internally in a program, and is not required to be
        /// called manually.
        /// </summary>
        /// <param name="p">The file to parse</param>
        public static void Parse(File p)
        {
            _checkApi();
            _api._parse(p);
        }

        /// <summary>
        /// The main method called to build an action tree for a file.This method is called internally in a program, and is not required to be
        /// called manually.
        /// </summary>
        /// <param name="p">The file to build the action tree for</param>
        public static void BuildActionTree(File p)
        {
            _checkApi();
            _api._buildActionTree(p);
        }

        private static void _checkApi()
        {
            if(_api == null)
                // TODO: use a custom error?
               throw new DataException("The API must be set");
        }
    }
}