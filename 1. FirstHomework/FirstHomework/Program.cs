using System;

namespace FirstHomework
{
    internal class Program
    {
        public static void Main()
        {
            string nameStudent = "Igor";
            Person student = new Person(nameStudent);
            student.Name = "Ilya";
            Console.WriteLine(student.Name);
        }
    }
}