
using Shop.ExceptionHandling.BuyProductException;

namespace Shop.ExceptionHandling.HomeControllerException
{
    internal class ValidateHomeController
    {
        private List<string> _listOfCommands;
        public ValidateHomeController(List<string> listOfCommands)
        {
            _listOfCommands = listOfCommands;
        }
        public string CheckModuleSelection(string userInput)
        {
            NullOrWhiteSpace(userInput);

            if (!_listOfCommands.Contains(userInput))
            {
                throw new HomeControllerException("Режим работы следует выбирать используя цифры 1 и 2");
            }

            return userInput;
        }

        private void NullOrWhiteSpace(string source)
        {
            if (source == null || source == "")
            {
                throw new BuyProductArgumentException("Входное значение не может быть пустым");
            }
        }
    }
}
