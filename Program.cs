using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w programie, który porównuje podane ciągi znaków.");
            Console.Write("Podaj pierszy ciąg znaków: ");
            string firstWord = Console.ReadLine();
            Console.Write("Podaj drugi ciąg znaków: ");
            string secondWord = Console.ReadLine();

            WordsComparer wordsComparer = new WordsComparer(firstWord, secondWord);
            wordsComparer.writeDifferencesBetweenWords();
            Console.ReadKey();
        }
    }
}
