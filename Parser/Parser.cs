using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QueryParser
{
    public class ConditionParser
    {
        public ENUM_OPERATOR Operator { get; set; }
        public String LeftSide { get; set; }
        public String RightSide { get; set; }
        public String Statement { get; set; }

        private int index;
        private String currentWord;
        private ENUM_WORD_TYPE currentWordType;
        private Stack<String> wordStack;

        public ConditionParser(String statement)
        {
            currentWord = "";
            currentWordType = ENUM_WORD_TYPE.UNKNOWN;
            Parse(statement);
        }

        private void Parse(String statement)
        {
            index = 0;
            Statement = statement;
            while (currentWordType != ENUM_WORD_TYPE.LOGICAL_OPERAOTR)
            {
                fetchWord();
            }
        }

        private void fetchWord()
        {
            String word = "";

            while (Char.IsWhiteSpace(Statement[index]))
                index ++;

            // index now points to non-whitespace char
            while (!Char.IsWhiteSpace(Statement[index]))
            {
                word += Statement[index];
                index ++;
            }                

            // index now points to whitespace char
            // word now contains a whole word
            currentWordType = getWordType(word);
            currentWord = word;
        }

        private bool isLogicalOperator(String word)
        {
            return false;
        }

        private ENUM_WORD_TYPE getWordType(String word)
        {
            if (SpecialWordsAndSymbols.IsLogicalOperator(word))
                return ENUM_WORD_TYPE.LOGICAL_OPERAOTR;
            
            return ENUM_WORD_TYPE.UNKNOWN;
        }
    }
}

/*
select:
    - find line starting with from
    - could at least check parenthesis and quotaions closure (using stack) ?
from
    - includes joins
    - find line starting with where
where
    - this gets parsed to nodes
    - is stsupid
    - needs to account for:
        - parenthessis
        - quotations
            - escaped quotations
    - algorithm:
        1) read a word - until white space is found
            - it could be one of:
                - field
                - constant - is a number / is a string
                - variable - starts with @
                - operator - is one of:
                    - +, -, *, \, =, <, >, <>, <=, >=, &, |, is null, is not null
                - function - ends with () with a list of arguments inside - do i check the arguments?
                - logical operator:
                    - AND, OR, NOT
                - keyword:
                    exists, not exists, in, not in
                - whitespace
                    space, tab, crlf
            - if logical operator:
                - return operator, left side and right side

        


or and 

Archived_NoSync = 0
and 
(   USR_ID is null
or
USR_ID = @UsrId
or
(    @mode <> 'CREATOR'
and
ORD_Status not in ('Draft', 'Template')
          )
      )


*/