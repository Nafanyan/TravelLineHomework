
using Microsoft.Extensions.Primitives;

namespace Shop.Views
{
    internal interface IViews
    {
        public void StartPage();
        public void MessageShow(string msg);
        public string? UserInput();
    }

}
