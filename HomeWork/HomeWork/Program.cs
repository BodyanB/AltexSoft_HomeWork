using System;

namespace HomeWork
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var homework = new Home();
            var result = homework.InvokePriceCalculatiion();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
