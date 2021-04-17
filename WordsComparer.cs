using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    
    class WordsComparer
    {
        struct Comparison
        {
            public bool wordsHaveSameLengths;
            public bool wordsHaveSameCountsOfVovels;
            public bool wordsContainSameLettersIfOrderIsImportant;
            public bool wordsContainSameLettersIfOrderIsNotImportant;
            public bool wordsHaveSameLowercasesCount;
            public bool wordsHaveSameUppercasesCount;
            public bool wordsHaveSameOrderOfUppercases;
            public bool wordsHaveSameOrderOfLowercases;
        }

        private string firstWord;
        private string secondWord;
        private Comparison comparison;

        public WordsComparer(string string1, string string2) {
            firstWord = string1;
            secondWord = string2;
            comparison = compareWords();
        }

        private bool checkIfWordsHaveSameLengths()
        {
            return firstWord.Length == secondWord.Length;
        }

        private bool checkIfWordsHaveSameCountsOfVovels()
        {
            string text = firstWord.ToLower();
            string text2 = secondWord.ToLower();
            string vowels = "aąeęioóuy";
            int vowelsCounter1 = 0;
            int vowelsCounter2 = 0;
            foreach (char letter in text)
            {
                if (vowels.Contains(letter))
                    vowelsCounter1++;
            }
            foreach (char letter in text2)
            {
                if (vowels.Contains(letter))
                    vowelsCounter2++;
            }
            return vowelsCounter1 == vowelsCounter2;
        }

        private bool checkIfWordsContainSameLettersIfOrderIsImportant(string string1, string string2)
        {

            string lowerString1 = string1.ToLower();
            string lowerString2 = string2.ToLower();
            for (int i = 0; i < lowerString1.Length; i++)
            {
                if (lowerString1[i] != lowerString2[i]) return false;
            }
            return true;
        }

        private bool checkIfWordsContainSameLettersIfOrderIsNotImportant()
        {
            char[] charString1 = firstWord.ToLower().ToCharArray();
            char[] charString2 = secondWord.ToLower().ToCharArray();
            Array.Sort(charString1);
            Array.Sort(charString2);
            string str1 = new string(charString1);
            string str2 = new string(charString2);
            return checkIfWordsContainSameLettersIfOrderIsImportant(str1, str2);
        }

        static private int uppercasesCount(string string1)
        {
            int uppers = 0;

            foreach (char letter in string1)
            {
                if (char.IsUpper(letter)) uppers++;
            }
            return uppers;
        }

        static private int lowercasesCount(string string1)
        {
            int lowers = 0;
            foreach (char letter in string1)
            {
                if (char.IsLower(letter)) lowers++;
            }
            return lowers;
        }

        static private bool checkIfWordsHaveSameOrderOfUppercases(string string1, string string2)
        {
            for (int i = 0; i < string1.Length; i++)
            {
                if (char.IsUpper(string1[i]))
                {
                    if (!char.IsUpper(string2[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static private bool checkIfWordsHaveSameOrderOfLowercases(string string1, string string2)
        {
            for (int i = 0; i < string1.Length; i++)
            {
                if (char.IsLower(string1[i]))
                {
                    if (!char.IsLower(string2[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Comparison compareWords(){
            Comparison c = new Comparison
            {
                wordsHaveSameLengths = checkIfWordsHaveSameLengths(),
                wordsHaveSameCountsOfVovels = checkIfWordsHaveSameCountsOfVovels(),
                wordsContainSameLettersIfOrderIsImportant = checkIfWordsContainSameLettersIfOrderIsImportant(firstWord, secondWord),
                wordsContainSameLettersIfOrderIsNotImportant = checkIfWordsContainSameLettersIfOrderIsNotImportant(),
                wordsHaveSameLowercasesCount = lowercasesCount(firstWord) == lowercasesCount(secondWord),
                wordsHaveSameUppercasesCount = uppercasesCount(firstWord) == uppercasesCount(secondWord),
                wordsHaveSameOrderOfUppercases = checkIfWordsHaveSameOrderOfUppercases(firstWord, secondWord),
                wordsHaveSameOrderOfLowercases = checkIfWordsHaveSameOrderOfLowercases(firstWord, secondWord),
        };
            return c;
        }

        public void writeDifferencesBetweenWords()
        {
            Console.WriteLine("Dla slow " + firstWord + " oraz " + secondWord + "roznice to: ");
            if (!comparison.wordsHaveSameLengths)
            {
                Console.WriteLine("długość ciągu znaków");
            }
            if (!comparison.wordsHaveSameCountsOfVovels)
            {
                Console.WriteLine("ilość zawartych samogłosek");
            }
            if (!comparison.wordsContainSameLettersIfOrderIsImportant && comparison.wordsContainSameLettersIfOrderIsNotImportant) 
                Console.WriteLine("kolejnością znaków (są anagramami)");
            if (!comparison.wordsContainSameLettersIfOrderIsImportant && !comparison.wordsContainSameLettersIfOrderIsNotImportant) 
                Console.WriteLine("zawierają różne litery");
            if (!comparison.wordsHaveSameLowercasesCount)
            {
                Console.WriteLine("zawierają różną ilość małych liter");
            }
            else
            {
                if ((uppercasesCount(firstWord) > 0) && (uppercasesCount(secondWord) > 0))
                {
                    if (!comparison.wordsHaveSameOrderOfUppercases) Console.WriteLine("mają różnie rozmieszczone wielkie litery");
                }
            }
            if (!comparison.wordsHaveSameUppercasesCount)
            {
                Console.WriteLine("zawierają różną ilość wielkich liter");
            }
            else
            {
                if ((lowercasesCount(firstWord) > 0) && (lowercasesCount(secondWord) > 0))
                {
                    if (!comparison.wordsHaveSameOrderOfLowercases) Console.WriteLine("mają różnie rozmieszczone małe litery");
                }
            }
            
        }
    }
}
