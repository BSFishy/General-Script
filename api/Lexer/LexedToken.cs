using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global

namespace GeneralScript.Api.Lexer
{
    /// <summary>
    /// This class represents a token which has been lexed. The lexing process takes in the bare code, splits it into
    /// smaller "tokens", and returns them. This represents one of those tokens, without any sort of structure.
    /// </summary>
    public class LexedToken
    {
        private readonly Type _type;
        private readonly string _value;

        /// <summary>
        /// The <see cref="Type"/> of this token.
        /// </summary>
        public Type type => _type;
        /// <summary>
        /// The value of this token. This is a string, to prevent any cast errors.
        /// </summary>
        public string Value => _value;

        /// <summary>
        /// The constructor of a lexed token. Tokens should be instantiated by the lexer to be passed on to the parser.
        /// </summary>
        /// <param name="type">The type of the token</param>
        /// <param name="value">The value of the token</param>
        public LexedToken(Type type, string value)
        {
            _type = type;
            _value = value;
        }
        
        /// <summary>
        /// This represents all of the types a token can be. The correct type is very recommended, as that will make it
        /// much easier for the parser and action tree generator to do their things.
        /// </summary>
        public class Type
        {
            /// <summary>
            /// A list of all of the potential types.
            /// </summary>
            public static readonly List<Type> Values = new List<Type>();
            private static int _currentId;
            
            /// <summary>
            /// This represents anything that is not one of the others. This includes variables, types, modifiers, etc.
            /// </summary>
            public static readonly Type Identifier = new Type("identifier");
            /// <summary>
            /// This represents any kind of opterator. This will include =, +, ;, etc.
            /// </summary>
            public static readonly Type Operator = new Type("operator");
            /// <summary>
            /// This represents any sort of literal value defined. This can be an integer, string, etc.
            /// </summary>
            public static readonly Type Object = new Type("object");
            /// <summary>
            /// This represents a new line character.
            /// </summary>
            public static readonly Type NewLine = new Type("newline");

            private readonly int _id;
            private readonly string _name;

            /// <summary>
            /// This is the id of the type. This is used in comparisons between two types.
            /// </summary>
            public int Id => _id;
            /// <summary>
            /// This is the name of the type. This can be used to get a type from the name.
            /// </summary>
            public string Name => _name;

            private Type(string name)
            {
                _id = _currentId++;
                _name = name;
                
                Values.Add(this);
            }

            /// <summary>
            /// This will get any type who's name is <see cref="t"/>. If no type's name is <see cref="t"/>, null is returned.
            /// </summary>
            /// <param name="t">The name to compare against</param>
            /// <returns>The type who's name is <see cref="t"/></returns>
            public static Type TypeOf(string t)
            {
                foreach (Type type in Values)
                {
                    if (type.Name == t)
                        return type;
                }

                return null;
            }

            public override bool Equals(object obj)
            {
                return obj is Type type && Equals(type);
            }

            private bool Equals(Type other)
            {
                return _id == other._id && string.Equals(_name, other._name);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (_id * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                }
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}