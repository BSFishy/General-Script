using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace GeneralScript.Api.DialectApi
{
    public class DialectLoader
    {
        public static void Load(string dir)
        {
            foreach (string file in Directory.EnumerateFiles(dir))
            {
                if (file.EndsWith("dll"))
                {
                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(file);
                    Assembly assembly = Assembly.Load(assemblyName);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetCustomAttributes(typeof(GsDialect), true).Length == 1)
                        {
                            object o = type.GetConstructor(new Type[0])?.Invoke(new object[0]);

                            if (o == null)
                            {
                                Console.WriteLine("Recieved a class with the \"GsDialect\" attribute, but it wasn't a dialect. Ignoring.");
                                continue;
                            }

                            Dialect d = (Dialect) o;
                            GsDialect attribute = (GsDialect) type.GetCustomAttributes(typeof(GsDialect), true)[0];
                            
                            d.Initialize(attribute.Name ?? "", attribute.Description ?? "", attribute.Version ?? "1.0", attribute.Extension ?? "");

                            ParsingApi.AddDialect(d);
                            
                            Console.WriteLine("Successfully loaded " + d.Name);
                        }
                    }
                }
            }
        }
    }
}