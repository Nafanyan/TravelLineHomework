
namespace Shop.Models
{
    internal interface IModels
    {
        public string ReadRequest(string request);
        public string ReadAll();
        public string RemoveElement(string id);
        public string AddRequest(string request);
        public string GetTypeProduct();
        public bool WriteFile(string path);
    }
}
