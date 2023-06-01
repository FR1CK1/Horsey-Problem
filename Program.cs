using System;
using System.Runtime.CompilerServices;

namespace Horsey
{

    class Horsey
    {
        static void Main(string[] args)
        {
            int iHorseCount = 0;
            for (bool bEsc = false; bEsc == false;)
            {
                string sChoose = GenerateMenu();
                bEsc = ChooseOption(sChoose, iHorseCount);
            }

            static string GenerateMenu()
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Random Horse : rnd");
                Console.WriteLine("Set Horse    : set");
                Console.WriteLine();
                Console.WriteLine("Exit         : esc");
                Console.WriteLine();
                Console.Write("Select Option:");
                return Console.ReadLine();
            }

            static bool ChooseOption(string sChoose, int iHorseCount)
            {
                Horse[] h = new Horse[64]; 
                for (int i=0; i < 64; i++)
                {
                    h[i] = new Horse();
                }
                switch (sChoose)
                {
                    case "rnd":
                        //Generate knight with random Position
                        h[iHorseCount].InitHorse();
                        iHorseCount++;
                        return false;
                    case "set":
                        //Generate knight with given coordinates
                        for (bool correct = false; correct == false;)
                        {
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Position? : ");
                            string posLine = Console.ReadLine();
                            if (posLine.Length != 2)
                            {
                                Console.WriteLine("Input not useable. Please give correct coordinates");
                            } else
                            {
                                correct = h[iHorseCount].InitHorse(posLine[0], (int)posLine[1]);
                            }
                        }
                        iHorseCount++;
                        return false;
                    case "esc":
                        return true;
                    default:
                        Console.WriteLine("Imput Error");
                        return false;
                }
            }
        }
    }
}