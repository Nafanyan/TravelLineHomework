
namespace Calculator.Views
{
    internal interface IViews
    {
        public void StartPrint();
        public void PrintData(string source);
        public void EndPrint();
        public void PrintOptions();
    }
}
