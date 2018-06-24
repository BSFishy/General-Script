using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Number
{
    public class Float : ConstantType
    {
        public Float() : base(EType.Float, typeof(float))
        {
        }
    }
}