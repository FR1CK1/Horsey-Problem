using System;

namespace Horsey
{
    public class Collection
    {
        public static int[] CoordTranslate(char x, int y)
        {
            int[] result = new int[2];
            bool bPosCorrect = true;
            switch (x)
            {
                case 'a':
                case 'A':
                    result[0] = 0;
                    break;
                case 'b':
                case 'B':
                    result[0] = 1;
                    break;
                case 'c':
                case 'C':
                    result[0] = 2;
                    break;
                case 'd':
                case 'D':
                    result[0] = 3;
                    break;
                case 'e':
                case 'E':
                    result[0] = 4;
                    break;
                case 'f':
                case 'F':
                    result[0] = 5;
                    break;
                case 'g':
                case 'G':
                    result[0] = 6;
                    break;
                case 'h':
                case 'H':
                    result[0] = 7;
                    break;
                default:
                    Console.WriteLine("Buchstaben nur von A-H nutzen");
                    bPosCorrect = false;
                    break;
            }

            if (y <= 1 || y >= 8)
            {
                Console.WriteLine("Zahl nur von 1-8");
                bPosCorrect = false;
            }
            else
            {
                result[1] = y - 1;
            }

            if (bPosCorrect)
            {
                return result;
            } else
            {
                result[0] = -1;
                result[1] = -1;
                return result;
            }
        }
    }
}