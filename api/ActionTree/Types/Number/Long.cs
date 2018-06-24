using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Number
{
    public class Long : ConstantType
    {
        public Long() : base(EType.Long, typeof(long))
        {
        }
    }
}