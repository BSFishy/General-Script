namespace GeneralScript.Api.ActionTree.Tokens
{
    public interface IHasOutput
    {
        ActionTreeToken Perform();

        EType OutputType();
    }
}