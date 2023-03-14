
namespace FirstHomework
{
    // internal - виден внутри сборки
    internal class Person
    {
        // private - вмден внутри класса
        private string _name;

        // свойство с именем
        // свойство = методы
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                // value - передоваемый параметр
                _name = value;
            }
        }
        public Person(string name)
        {
            _name = name;
        }

    }
}
