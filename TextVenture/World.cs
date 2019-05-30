using System;

namespace TextVenture
{
    //world should have 2d array for world, array of forts, player
    class World
    {
        char[,] charArr;
        Player p;
        Fort[] fortArr;

        //might not need these values:
        readonly int fortXDim;
        readonly int fortYDim;
        public World()
        {

        }
        //FILL THIS IN 
        public World(char[,]c, Player p, Fort[] f, int fortXDim, int fortYDim)
        {
            charArr = c;
            this.p = p;
            fortArr = f;
            this.fortXDim = fortXDim;
            this.fortYDim = fortYDim;
        }
        public int GetFortXDim()
        {
            return fortXDim;
        }
        public int GetFortYDim()
        {
            return fortYDim;
        }

        public void AddFortToArr(Fort f)
        {
            //add fort to arr:
            Array.Resize(ref fortArr, fortArr.Length + 1);
            fortArr[fortArr.Length - 1] = f;
        }

        public char[,] GetCharArr()
        {
            return charArr;
        }
        public int GetLengthXY(char c)
        {
            if (c.Equals('x')) return charArr.GetLength(1);
            if (c.Equals('y')) return charArr.GetLength(0);
            else return -1;
        }
        //if false, then x, if true, then y:
        //can't really set length here:
        public void SetLengthXY(int xy, bool boolean)
        {
            if (boolean) //y
            {

            } //x
            else { }
        }
        public Fort[] GetFortArr()
        {
            return fortArr;
        }
        public Player GetPlayer()
        {
            return p;
        }

    }
}
