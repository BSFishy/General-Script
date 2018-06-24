using System.Collections.Generic;

namespace GeneralScript.Api.ActionTree.Tokens.Container
{
    public interface IContainerToken<T>
    {
        void AddChild(T child);
        
        List<T> GetChildren();
    }
}