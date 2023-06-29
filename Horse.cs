using Horsey;
using System;
using System.CodeDom.Compiler;

public class Horse
{
    //Position and Timeline of Horsey
    int[] pos = new int[2];
    int[,] posHistory = new int[64, 2];
    int iTurnCount = 0;
    bool bHasPath = false;

    public Horse()
    {
        //Feed Horse
    }

    public void InitHorse()
    {
        Random random = new Random();
        pos[0] = random.Next(1, 8);
        pos[1] = random.Next(1, 8);
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
    }

    public void InitHorse(int x, int y)
    {
        pos[0] = x;
        pos[1] = y;
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
    }

    public int[] GetPos()
    {
        return pos;
    }

    public bool HasPath()
    {
        return bHasPath;
    }

    public bool StartHorse()
    {
        int iErrorCount = 0;
        bool bSomethinUndone = false;
        Random random = new Random();
        for (; iTurnCount < 64;)
        {
            int iDirection = random.Next(1, 8);
            switch (iDirection)
            {
                case 1:
                    UpLeft();
                    break;
                case 2:
                    UpRight();
                    break;
                case 3:
                    RightUp();
                    break;
                case 4:
                    RightDown();
                    break;
                case 5:
                    DownRight();
                    break;
                case 6:
                    DownLeft();
                    break;
                case 7:
                    LeftDown();
                    break;
                case 8:
                    LeftUp();
                    break;
            }

            if (CheckIfLegal())
            {
                for (int i = 0; i < iTurnCount - 1; i++)
                {
                    if (pos[0] == posHistory[i, 0] && pos[1] == posHistory[i, 1])
                    {
                        Undo();
                        iErrorCount++;
                        bSomethinUndone = true;
                        break;
                    }
                }
            }
            else
            {
                iErrorCount++;
                bSomethinUndone = true;
                Undo();
            }

            if (bSomethinUndone == false)
            {
                if (StartHorse() == false)
                {
                    iErrorCount++;
                }
            }

            if (iErrorCount >= 8)
            {
                return false;
            }

        }
        return true;
    }

    //Beyond this line, Movement
    void UpLeft()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += -1;
        pos[1] += 2;
        iTurnCount++;
    }

    void UpRight()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += 1;
        pos[1] += 2;
        iTurnCount++;
    }

    void RightUp()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += 2;
        pos[1] += 1;
        iTurnCount++;
    }

    void RightDown()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += 2;
        pos[1] += -1;
        iTurnCount++;
    }

    void DownRight()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += 1;
        pos[1] += -2;
        iTurnCount++;
    }

    void DownLeft()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += -1;
        pos[1] += -2;
        iTurnCount++;
    }

    void LeftDown()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += -2;
        pos[1] += -1;
        iTurnCount++;
    }

    void LeftUp()
    {
        posHistory[iTurnCount, 0] = pos[0];
        posHistory[iTurnCount, 1] = pos[1];
        pos[0] += -2;
        pos[1] += 1;
        iTurnCount++;
    }

    void Undo()
    {
        posHistory[iTurnCount, 0] = -1;
        posHistory[iTurnCount, 1] = -1;
        iTurnCount--;
        pos[0] = posHistory[iTurnCount, 0];
        pos[1] = posHistory[iTurnCount, 1];
    }

    bool CheckIfLegal()
    {
        bool isLegal = false;
        if (1 <= pos[0] && pos[0] <= 8)
        {
            if (1 <= pos[1] && pos[1] <= 8)
            {
                isLegal = true;
            }
        }
        return isLegal;
    }
}
