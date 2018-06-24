using GeneralScript.Api.ActionTree.Tokens;

namespace GeneralScript.Api.ActionTree.Types.Object
{
    public class Bool : ConstantType
    {
        public Bool() : base(EType.Bool, typeof(bool))
        {
        }
    }
}