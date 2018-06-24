using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Character
{
    public class Char : ConstantType
    {
        public Char() : base(EType.Char, typeof(char))
        {
        }
    }
}