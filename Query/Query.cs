using System;
using QueryParser;

namespace QueryParser.Queries
{
    public class Node
    {
        Node LeftNode { get; set; }
        Node RightNode { get; set; }
        String Expression { get; set; }
        ENUM_OPERATOR Operator { get; set; }

        public Node(String statement)
        {
            // parse statement
            // find first logical operator
            // store operator as tihs nodes operator
            // create lef node - send left side as argument
            // create riht node - send right side as argument
            // if log. operator is NOT - only assign left side

            ConditionParser parser = new ConditionParser(statement);
            LeftNode = new Node(parser.LeftSide);
            RightNode = new Node(parser.RightSide);
            Operator = parser.Operator;
        }
    }

    public class Query
    {
        /*
            structure of a query:
                SelectList
                    * comma separated expressions
                WhereCond
                    TREE ?
                    Stack ?
                   
where A
  and (   B
       or C
       or (    D
           and E)
          )
      )

ABCDE&||&

whereCond tree:
                        and
                    /        \
                   A         or
                            /   \
                        B        or 
                               /    \
                              C       and
                                     /   \
                                    D     E

        and
    /        \
    A         and
            /   \
        B        not
                  or 
                /    \
               C       and
                      /   \
                     D     E

        and
    /        \
    A         and
            /   \
        not
          B        or 
                /    \
              C       and
                    /   \
                   D     E


reverse polish notation (stack): A & (B | (C | (D & E)))
ABCDE&||&
stack: A & (B | (C | (D & E)))

algorithm:
1) go through nodes
    *   of it is OR, duplicate as and, stuff the copy behind the current query
        - set the duplicates successor to my successor, set my successor to the duplicate

data model:
query:
    node:
        *leftNode
        *rightNode
        *isLeaf
        *expression
        *operator



        */
    }
}