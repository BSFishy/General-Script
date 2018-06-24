using GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured.ClassSpecific;
using GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured.EnumSpecific;
using GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured.InterfaceSpecific;

namespace GeneralScript.Api.Default.Runtime.ActionTree.Block.Structured
{
    public interface IStructureChild : IClassChild, IInterfaceChild, IEnumChild
    {
        
    }
}