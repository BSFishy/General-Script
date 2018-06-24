namespace GeneralScript.Api.ActionTree.Tokens.Container
{
    public static class Modifiers
    {
        public enum Access
        {
            Public,
            Private,
            // TODO: do we need a package private?
            //PACKAGE_PRIVATE,
            Protected
        }

        public enum Description
        {
            Static,
            Final,
            Constant,
            Abstract,
            Void,
        }
    }
}