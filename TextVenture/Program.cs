
namespace TextVenture
{
    class Program
    {
        //FEATUES TO ADD:
        //1. DONE add var to keep track of previously entered box, so it can then be restored upon exiting the box can traverse tree/fort spaces now
        //2. DONE add way to navigate sw, se, nw, ne
        //3. DONE Create separate class for characterPlayer, Monster, World, etc.
        //4 .DONE Move fort stuff into fort class ( makes sense)
        //5  DONE enter and exit points put in fort
        //6. DONE Once fort entered, enter fort at start point.
        //7  DONE Once on exit square, exit fort.
        //8. DONE Replace new player in fortSession with current player in worldSession. hp and ac transfer between areas now
        //8. MEAH make more general class for fort, city, world to extend called MAP
        //9. generate cities! (max of 3 per game?)
        //10. food/suplies? goes down each time you move a square?
        //11. purchace more at cities?
        //12. money for defeating stuff in forts/ wilderness
        static void Main(string[] args)
        {
            WorldSession ws = new WorldSession();
            //s.Start();
            //run stuff fron session to create world here:
            //creates world:
            ws.AskSize();
            //creates map/forts:
            ws.CreateMap();
            //runs game:
            while (true)
            {
                if (!ws.Play()) break;
            }
        }
    }
}
