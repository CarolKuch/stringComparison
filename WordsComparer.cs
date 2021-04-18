using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    
    class WordsComparer
    {
        public struct Comparison
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
        
        public Comparison ComparisonBetweenWords
        {
            get { return comparison; }
        }
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
                wordsHaveSameOrderOfUppercases = false,
                wordsHaveSameOrderOfLowercases = false,
        };
            return c;
        }

        public string describeDifferencesBetweenWords()
        {
            string descriptionOfDifferencedBetweenWords = "Dla słów " + firstWord + " oraz " + secondWord + " różnice to: \n";
            if (firstWord.Equals(secondWord))
            {                
                if(firstWord == "") descriptionOfDifferencedBetweenWords = "Podane ciągi znaków są identyczne, ale puste";
                else descriptionOfDifferencedBetweenWords = "Podane ciągi znaków są identyczne";
            }
            else
            {
                if (!comparison.wordsHaveSameLengths) descriptionOfDifferencedBetweenWords += "długość ciągu znaków\n";
                if (!comparison.wordsHaveSameCountsOfVovels) descriptionOfDifferencedBetweenWords += "liczba zawartych samogłosek\n";
                if (!comparison.wordsContainSameLettersIfOrderIsImportant && comparison.wordsContainSameLettersIfOrderIsNotImportant)
                    descriptionOfDifferencedBetweenWords += "kolejnością znaków (są anagramami)\n";
                if (!comparison.wordsContainSameLettersIfOrderIsImportant && !comparison.wordsContainSameLettersIfOrderIsNotImportant)
                    descriptionOfDifferencedBetweenWords += "zawierają różne litery\n";
                if (!comparison.wordsHaveSameLowercasesCount) descriptionOfDifferencedBetweenWords += "liczba małych liter\n";
                else
                {
                    if ((uppercasesCount(firstWord) > 0) && (uppercasesCount(secondWord) > 0) && comparison.wordsHaveSameLengths)
                    {
                        comparison.wordsHaveSameOrderOfUppercases = checkIfWordsHaveSameOrderOfUppercases(firstWord, secondWord);
                        if (!comparison.wordsHaveSameOrderOfUppercases) descriptionOfDifferencedBetweenWords += "mają różnie rozmieszczone wielkie litery\n";
                    }
                }
                if (!comparison.wordsHaveSameUppercasesCount) descriptionOfDifferencedBetweenWords += "liczba wielkich liter\n";
                else
                {
                    if ((lowercasesCount(firstWord) > 0) && (lowercasesCount(secondWord) > 0) && comparison.wordsHaveSameLengths)
                    {
                        comparison.wordsHaveSameOrderOfLowercases = checkIfWordsHaveSameOrderOfLowercases(firstWord, secondWord);
                        if (!comparison.wordsHaveSameOrderOfLowercases) descriptionOfDifferencedBetweenWords += "mają różnie rozmieszczone małe litery\n";
                    }
                }
            }
            return descriptionOfDifferencedBetweenWords;
        }
    }
}
