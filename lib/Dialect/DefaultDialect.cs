using GeneralScript.Api.DialectApi;

namespace GeneralScript.Api.Default.Dialect
{
    [GsDialect(Name = "General Script", Description = "The default dialect of General Script", Version = "2018.1", Extension = "gs")]
    public class DefaultDialect : DialectApi.Dialect
    {
        public DefaultDialect() : base(new DefaultParsingApi())
        {
        }
    }
}