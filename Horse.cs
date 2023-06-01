using Horsey;
using System;
using System.CodeDom.Compiler;

public class Horse
{
    //Position and Timeline of Horsey
    int[] pos = new int[2];
    int[,] posHistory = new int[64,2];
    int iTurnCount = 0;

    public Horse() {
        //Horseshit
    }

    public void InitHorse()
    {
        Random random = new Random();
        InitHorse(random);
    }
    public void InitHorse(Random random)
    {
        pos[0] = random.Next(0, 8);
        pos[1] = random.Next(0, 8);
    }

    public bool InitHorse(char x, int y)
    {
        this.pos = Collection.CoordTranslate(x, y);
        if (pos[0] != -1 && pos[1] != -1)
        {
            posHistory[iTurnCount,0] = pos[0];
            posHistory[iTurnCount,1] = pos[1];
            return true;
        } else return false;
    }

}
