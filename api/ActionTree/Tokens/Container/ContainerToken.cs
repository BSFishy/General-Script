using System.Collections.Generic;

namespace GeneralScript.Api.ActionTree.Tokens.Container
{
    public abstract class ContainerToken<T> : ActionTreeToken, IContainerToken<T>
    {
        private readonly List<T> _children = new List<T>();

        public void AddChild(T child)
        {
            _children.Add(child);
        }

        public List<T> GetChildren()
        {
            return _children;
        }
    }
}