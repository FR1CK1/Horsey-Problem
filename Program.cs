using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Horsey
{

    class Horsey
    {
        static void Main(string[] args)
        {
            Dictionary<int, Horse> horsestable = new Dictionary<int, Horse>();
            int iHorseCount = 0;
            Horse h = null;
            for (bool bEsc = false; bEsc == false;)
            {
                string sChoose = GenerateMenu();

                switch (sChoose)
                {
                    case "rnd":
                        //Generate knight with random Position
                        h = new Horse();
                        h.InitHorse();
                        horsestable.Add(iHorseCount, h);
                        iHorseCount++;
                        bEsc = false;
                        break;
                    case "set":
                        //Generate knight with given coordinates
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Position? : ");
                        string posLine = Console.ReadLine();
                        if (posLine.Length != 2)
                        {
                            Console.WriteLine("Input not useable. Please give correct coordinates");
                        }
                        else
                        {
                            int x = Collection.CoordTranslateToInt(posLine[0]);
                            int y = (int)char.GetNumericValue(posLine[1]);
                            if (x >= 1 && x <= 8)
                            {
                                if (y >= 1 && y <= 8)
                                {
                                    h = new Horse();
                                    h.InitHorse(x, y);
                                    horsestable.Add(iHorseCount, h);
                                    iHorseCount++;
                                }
                                else Console.WriteLine("Input not useable. Please give correct coordinates");
                            }
                            else Console.WriteLine("Input not useable. Please give correct coordinates");
                        }
                        bEsc = false;
                        break;
                    case "pos":
                        //Gives position of every horse in the stable
                        Console.WriteLine("Horse Number | Position | Has walked yet?");
                        //!TODO - Formated Print needet
                        for (int i = 0; i < iHorseCount; i++)
                        {
                            h = new Horse();
                            h = horsestable.GetValueOrDefault(i);
                            int[] pos = h.GetPos();
                            Console.WriteLine(i + " - " + Collection.CoordTranslateToChar(pos[0]) + pos[1] + " - " + h.HasPath());
                        }
                        break;
                    case "go":
                        h = new Horse();
                        h = horsestable.GetValueOrDefault(0);
                        for (; h.StartHorse() == false;) ;
                        break;
                    case "esc":
                        bEsc = true;
                        break;
                    default:
                        Console.WriteLine("Imput Error");
                        bEsc = false;
                        break;
                }

                static string GenerateMenu()
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Random Horse : rnd");
                    Console.WriteLine("Set Horse    : set");
                    Console.WriteLine("Get Positions: pos");
                    Console.WriteLine("Start a Horse: go");
                    Console.WriteLine();
                    Console.WriteLine("Exit         : esc");
                    Console.WriteLine();
                    Console.Write("Select Option:");
                    return Console.ReadLine();
                }
            }
        }
    }
}