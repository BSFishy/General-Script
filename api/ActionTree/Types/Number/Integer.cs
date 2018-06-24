using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Number
{
    public class Integer : ConstantType
    {
        public Integer() : base(EType.Integer, typeof(int))
        {
        }
    }
}