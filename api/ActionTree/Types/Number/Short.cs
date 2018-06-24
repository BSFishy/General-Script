using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Number
{
    public class Short : ConstantType
    {
        public Short() : base(EType.Short, typeof(short))
        {
        }
    }
}