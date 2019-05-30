
namespace TextVenture
{
    class Player
    {
        int x, y, health, armor;
        //enum correct data type for this?
        enum CurrLocation { Fort, World, City };

        public Player()
        {

        }
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void UpdateYX(int y, int x)
        {
            this.y = y;
            this.x = x;
        }
        public void SetPlayerX(int x) {
            this.x = x;
        }
        public void SetPlayerY(int y)
        {
            this.y = y;
        }
        public int GetPlayerX()
        {
            return x;
        }
        public int GetPlayerY()
        {
            return y;
        }
        
    }
}
