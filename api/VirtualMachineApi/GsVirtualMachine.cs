namespace GeneralScript.Api.VirtualMachineApi
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    public class GsVirtualMachine : System.Attribute
    {
        private string _name;
        private string _description;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }
    }
}