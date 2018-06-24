using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Character
{
    public class String : ConstantType
    {
        public String() : base(EType.String, typeof(string))
        {
        }
    }
}