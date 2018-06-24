using System;
using System.IO;
using System.Reflection;
using GeneralScript.Api;
using GeneralScript.Api.Default.Dialect;

namespace GeneralScript.Cli
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Error("The file to run is the one and only file that should be passed as an argument.");
            }

            if (args[0].StartsWith("-"))
            {
                Error("Invalid filename. Cannot start with \"-\".");
            }

            string code = "";
            try
            {
                code = System.IO.File.ReadAllText(args[0]);
            }
            catch (FileNotFoundException)
            {
                Error("The file you specified does not exist.");
            }
            
            LoadAssemblies();

            // TODO: add other options to commandline arguments
            ParsingApi.SetDialect(new DefaultDialect());
            
            Api.Program p = GS.CreateProgram(code);
            GS.Run(p);
        }
        
        private static void Error(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(0xA0);
        }

        private static void LoadAssemblies()
        {
            AssemblyName api = AssemblyName.GetAssemblyName("api/api.dll");
            
            Assembly.Load(api);
            
            GS.LoadDialects();
        }
    }
}