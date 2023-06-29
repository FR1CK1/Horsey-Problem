using System;

namespace Horsey
{
    public class Collection
    {
        public static int CoordTranslateToInt(char x)
        //Translates A-H in 1-8
        {
            int result = -1;
            switch (x)
            {
                case 'a':
                case 'A':
                    result = 1;
                    break;
                case 'b':
                case 'B':
                    result = 2;
                    break;
                case 'c':
                case 'C':
                    result = 3;
                    break;
                case 'd':
                case 'D':
                    result = 4;
                    break;
                case 'e':
                case 'E':
                    result = 5;
                    break;
                case 'f':
                case 'F':
                    result = 6;
                    break;
                case 'g':
                case 'G':
                    result = 7;
                    break;
                case 'h':
                case 'H':
                    result = 8;
                    break;
                default:
                    Console.WriteLine("Buchstaben nur von A-H nutzen");
                    break;
            }
            return result;
        }

        public static char CoordTranslateToChar(int i)
        {
            char c;
            switch(i)
            {
                case 1:
                    c= 'A'; break;
                case 2:
                    c = 'B'; break;
                case 3:
                    c = 'C'; break;
                case 4:
                    c = 'D'; break;
                case 5:
                    c = 'E'; break;
                case 6:
                    c = 'F'; break;
                case 7:
                    c = 'G'; break;
                case 8:
                    c = 'H'; break;
                default:
                    c = 'X'; break;
            }
            return c;
        }
    }
}