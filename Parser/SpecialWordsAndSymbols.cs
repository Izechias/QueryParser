using System;
using System.Collections.Generic;

namespace QueryParser
{
    public static class SpecialWordsAndSymbols
    {
        private static List<String> incomplete = new List<String>{"is", "is not"};
        private static List<String> keywords = new List<String>{"exists", "in"};
        private static List<String> operators = new List<String>{"+", "-", "*", "/", "&", "|"};
        private static List<String> specials = new List<String>{"is null", "is not null"};
        private static List<String> comparators = new List<String>{"<", ">", "<>", "<=", ">=", "="};
        private static List<String> logicals = new List<String>{"and", "or", "not"};

        public static bool IsIncomplete(String word)
        {
            if (incomplete.Contains(word))
                return true;
            else
                return false;
        }

        public static bool IsKeyword(String word)
        {
            if (keywords.Contains(word))
                return true;
            else
                return false;
        }

        public static bool IsOperator(String word)
        {
            if (operators.Contains(word))
                return true;
            else
                return false;
        }

        public static bool IsSpecial(String word)
        {
            if (specials.Contains(word))
                return true;
            else
                return false;
        }

        public static bool IsComparator(String word)
        {
            if (comparators.Contains(word))
                return true;
            else
                return false;
        }

        public static bool IsLogicalOperator(String word)
        {
            if (logicals.Contains(word))
                return true;
            else
                return false;
        }
    }
}