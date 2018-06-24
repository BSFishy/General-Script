using GeneralScript.Api.ActionTree.Tokens.Value;

namespace GeneralScript.Api.ActionTree.Tokens.Special
{
    public interface IArgument
    {
        string GetName();

        TypeToken GetType();

        bool IsRequired();
    }
}