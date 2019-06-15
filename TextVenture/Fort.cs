
using System;

namespace TextVenture
{
    class Fort
    {
        int x, y, fortStartX, fortStartY;
        int fortDimX, fortDimY;
        int fortExitX, fortExitY;
        char[,] fortSpace;
        static Random r = new Random();
        Player p;

        public Fort()
        {
        }
        //add 4 vars: x and y for exit and player location:
        //add things like x and y dimention from program to fort
        //everything pertaining to fort in fort class: makes more sense
        //ex: fort generation here instead of in program
        public Fort(int x, int y, char[,] fortDim)
        {
            //set fortStartX and Y:
            fortStartX = r.Next(1, fortDim.GetLength(1) - 1);
            fortStartY = r.Next(1, fortDim.GetLength(0) - 1);
            //set fortExitX and fortExitY. make sure that x y combo does not match xy combo for enterence:
            while (true)
            {
                fortExitX = r.Next(1, fortDim.GetLength(1) - 1);
                fortExitY = r.Next(1, fortDim.GetLength(0) - 1);
                if (fortStartX == fortExitX && fortStartY == fortExitY)
                    continue;
                else break;
            }
            this.x = x;
            this.y = y;
            fortSpace = fortDim;
            //set fort enterence xy as '[', exit as ']':
            fortSpace[fortStartY, fortStartX] = '[';
            fortSpace[fortExitY, fortExitX] = ']';
        }
        public Fort(int x, int y, char[,] fortDim, Player p)
        {
            //set fortStartX and Y:
            fortStartX = r.Next(1, fortDim.GetLength(1) - 1);
            fortStartY = r.Next(1, fortDim.GetLength(0) - 1);
            //set fortExitX and fortExitY. make sure that x y combo does not match xy combo for enterence:
            while (true)
            {
                fortExitX = r.Next(1, fortDim.GetLength(1) - 1);
                fortExitY = r.Next(1, fortDim.GetLength(0) - 1);
                if (fortStartX == fortExitX && fortStartY == fortExitY)
                    continue;
                else break;
            }

            this.x = x;
            this.y = y;
            fortSpace = fortDim;
            //set fort enterence xy as '[', exit as ']':
            fortSpace[fortStartY, fortStartX] = '[';
            fortSpace[fortExitY, fortExitX] = ']';
            this.p = p;
        }
        public int GetFortStartX()
        {
            return fortStartX;
        }
        public int GetFortStartY()
        {
            return fortStartY;
        }
        public int GetFortExitX()
        {
            return fortExitX;
        }
        public int GetFortExitY()
        {
            return fortExitY;
        }
        public char[,] GetFortCharArr()
        {
            return fortSpace;
        }
        public int GetFortX()
        {
            return x;
        }
        public int GetFortY()
        {
            return y;
        }
        public void SetFortX(int x)
        {
            this.x = x;
        }
        public void SetFortY(int y)
        {
            this.y = y;
        }
        public void SetFortXDim(int x)
        {
            fortDimX = x;
        }
        public void SetFortYDim(int y)
        {
            fortDimY = y;
        }
        public Player GetFortPlayer()
        {
            return p;
        }
        public void SetFortPlayer(Player p)
        {
            this.p = p;
        }
    }
}