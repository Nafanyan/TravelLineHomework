
using Microsoft.Extensions.Primitives;

namespace Shop.Views
{
    internal interface IViews
    {
        public void StartPage();
        public void Print(string print);
        public string? InputUser();
    }

}
