using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Number
{
    public class Double : ConstantType
    {
        public Double() : base(EType.Double, typeof(double))
        {
        }
    }
}