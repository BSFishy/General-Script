namespace GeneralScript.Api.VirtualMachineApi
{
    public abstract class VirtualMachine
    {
        private string _name;
        private string _description;

        public string Name => _name;
        public string Description => _description;

        public void Initialize(string name, string description)
        {
            _name = name;
            _description = description;
        }
    }
}