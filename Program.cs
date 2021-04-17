using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Program
    {
        static private bool CheckLength(string string1, string string2)
        {
            return string1.Length == string2.Length;
        }

        static private int CountVowels(string userText)
        {
            string text = userText.ToLower();
            string vowels = "aeiou";
            int counter = 0;
            foreach (char letter in text)
            {
                if(vowels.Contains(letter))
                counter++;
            }
            return counter;
        }

        static private int UpperCounter(string string1)
        {
            int uppers = 0;
            foreach(char letter in string1)
            {
                if (char.IsUpper(letter)) uppers++;
            }
            return uppers;
        }

        static private int LowerCounter(string string1)
        {
            int lowers = 0;
            foreach (char letter in string1)
            {
                if (char.IsLower(letter)) lowers++;
            }
            return lowers;
        }

        static private bool UppersIndexesCompare(string string1, string string2)
        {
            for (int i = 0; i < string1.Length; i++)
            {
                if (char.IsUpper(string1[i])){
                    if (!char.IsUpper(string2[i])){
                        return false;
                    }
                }
            }
            return true;
        }

         static private bool LowerIndexesCompare(string string1, string string2)
        {
            for (int i = 0; i < string1.Length; i++)
            {
                if (char.IsLower(string1[i])){
                    if (!char.IsLower(string2[i])){
                        return false;
                    }
                }
            }
            return true;
        }


        static private bool CheckIfContainSameLettersInSameOrder(string string1, string string2)
        {
            string lowerString1 = string1.ToLower();
            string lowerString2 = string2.ToLower();
            for ( int i = 0 ; i < lowerString1.Length ; i++ )
            {
                 if(lowerString1[i] != lowerString2[i]) return false;
            }
            return true;
        }

        static private bool CheckIfContainSameLettersOrderNoMatters(string string1, string string2)
        {
            char [] charString1 = string1.ToLower().ToCharArray();
            char [] charString2 = string2.ToLower().ToCharArray();
            Array.Sort(charString1);
            Array.Sort(charString2);
            string str1 = new string(charString1);
            string str2 = new string(charString2);
            return CheckIfContainSameLettersInSameOrder(str1, str2);
        }

        static private void ExplainTheDifference(string string1, string string2)
        {
            string myAnswer = "Podane ciągi znaków różnią się: \n";
            bool sameLenght = CheckLength(string1, string2);
            bool sameCountOfVowels = CountVowels(string1) == CountVowels(string2);
            bool sameCountOfUppers = UpperCounter(string1) == UpperCounter(string2);
            bool sameCountOfLowers = LowerCounter(string1) == LowerCounter(string2);
            bool sameLettersSameOrder = CheckIfContainSameLettersInSameOrder(string1, string2);
            bool sameLettersOrderNoMatters = CheckIfContainSameLettersOrderNoMatters(string1, string2);
            if (!sameLenght) myAnswer += "długością\n";

            if (!sameCountOfVowels) myAnswer += "ilością wystąpień samogłosek\n";

            if (!sameCountOfUppers) {
                myAnswer += "ilością wystąpień wielkich liter\n";
            }else{
                if ((UpperCounter(string1) > 0) && (UpperCounter(string2) > 0))
                {
                    bool upperCaseIndexes = UppersIndexesCompare(string1, string2);
                    if (!upperCaseIndexes) myAnswer += "mają różnie rozmieszczone wielkie litery\n";
                }
            };

            if (!sameCountOfLowers)
            {
                myAnswer += "ilością wystąpień małych liter\n";
            }else{
                if ((LowerCounter(string1) > 0) && (LowerCounter(string2) > 0))
                {
                    bool lowerCaseIndexes = LowerIndexesCompare(string1, string2);
                    if (!lowerCaseIndexes) myAnswer += "mają różnie rozmieszczone małe litery\n";
                }
            };

        if (!sameLettersSameOrder && sameLettersOrderNoMatters) myAnswer += "kolejnością znaków (są anagramami)\n";
            if (!sameLettersSameOrder && !sameLettersOrderNoMatters) myAnswer += "zawierają różne litery\n";
            
            Console.WriteLine(myAnswer);
        }

        static void Main(string[] args)
        {
            Console.Write("Podaj pierszy ciąg znaków: ");
            string string1 = Console.ReadLine();
            Console.Write("Podaj drugi ciąg znaków: ");
            string string2 = Console.ReadLine();

            if (Equals(string1, string2)) 
                Console.WriteLine("Te ciągi znaków są identyczne.");
            else
                ExplainTheDifference(string1, string2);
            Console.ReadLine();
        }
    }
}
