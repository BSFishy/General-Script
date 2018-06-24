using System.Collections.Generic;

namespace GeneralScript.Api.ActionTree.Tokens.Container
{
    public interface IModifiable
    {
        Modifiers.Access GetAccess();
        
        List<Modifiers.Description> GetModifiers();
    }
}