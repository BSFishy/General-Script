namespace GeneralScript.Api.ActionTree.Tokens.Value
{
    public interface IHasConstantOutput : IHasOutput
    {
        dynamic Output();
    }
}