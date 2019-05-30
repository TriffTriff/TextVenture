
namespace TextVenture
{
    class Program
    {
        //FEATUES TO ADD:
        //1. DONE add var to keep track of previously entered box, so it can then be restored upon exiting the box can traverse tree/fort spaces now
        //2. DONE add way to navigate sw, se, nw, ne
        //3. DONE Create separate class for characterPlayer, Monster, World, etc.
        //4 .DONE Move fort stuff into fort class ( makes sense)
        //4.5 enter and exit points put in fort, fort builder put in fort class
        //5. DONE Once fort entered, enter fort at start point.
        //5. MEAH make more general class for fort, city, world to extend called MAP
        //6. generate cities! (max of 3 per game(?))
        //7. food/suplies? goes down each time you move a square?
        //8. purchace more at cities?
        //9. money for defeating stuff in forts/ wilderness
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
