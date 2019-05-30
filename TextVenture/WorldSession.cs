using System;

namespace TextVenture
{
    
    //game session including:
    //instance of world
    class WorldSession
    {
        World world;
        int fortCount = 0;
        static Random rand = new Random();
        //can set this to 'O' and cut out much code?
        static char currentBox = 'O';

        public void UpdateYX(int y, int x)
        {
            world.GetPlayer().SetPlayerY(y);
            world.GetPlayer().SetPlayerX(x);
        }

        public bool Move(string direction)
        {
            //based on location of character, check one north south east or west of curr char location:
            switch (direction)
            {
                case "N":
                    //doesn't throw because of one space padding that is provided by the 'W' wall:
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX()].Equals('W')  /*&&!charArr[charPosY-1,charPosX].Equals('T') && !charArr[charPosY-1, charPosX].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX()];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX()] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX());
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX()];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX()] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX());
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    else
                        break;
                case "S":
                    //could throw indexOutOfBoundsException:
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX()].Equals('W')  /*&&!charArr[charPosY + 1, charPosX].Equals('T') && !charArr[charPosY + 1, charPosX].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX()];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX()] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX());
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX()];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX()] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX());
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    else
                        break;
                case "E":
                    //could throw indexOutOfBoundsException:
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1].Equals('W')  /*&&!charArr[charPosY, charPosX+1].Equals('T') && !charArr[charPosY, charPosX+1].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() + 1);
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    else
                        break;
                case "W":
                    //could throw indexOutOfBoundsException:
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1].Equals('W')  /*&&!charArr[charPosY, charPosX-1].Equals('T') && !charArr[charPosY, charPosX-1].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX() - 1);
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    else
                        break;

                default:
                    break;
            }
            return false;
        }
        //start fort session:
       // when to start fort session?
       //when spot traversed to == 'F'
        public void StartFortSession(int x, int y)
        {
            //get fort number in the ordered fort[] to send as parameter for play instead of x and y:
            //CODE HERE: a loop on x and y, find matching pair, send matching fort number as parameter:
            int num = -1;
            for (int i = 0; i < world.GetFortArr().Length; i++)
            {
                if (world.GetFortArr()[i].GetFortX() == x && world.GetFortArr()[i].GetFortY() == y) { num = i; break; }
            }
            if (num == -1) return;
            //fort session class will need: specific fort passed to it(?):
            //construct new fort instance using constructor with extra player parameter:
            //player will always spawn in bottom left of fort:
            Player p = new Player(1, world.GetFortYDim() - 2);
            //Fort f = new Fort(world.GetFortArr()[num].GetFortX()+0, world.GetFortArr()[num].GetFortY()+0, world.GetFortArr()[num].GetFortCharArr(),p);
            //FortSession fs = new FortSession(f, p);
            FortSession fs = new FortSession(world.GetFortArr()[num], p);
            while (true)
            {
                if (!fs.Play()) break;
            }
        }

        public bool DiagMove(string direction)
        {
            switch (direction)
            {
                case "NW": //charArr is world.GetCharArr()[,]:
                    //add else if's of these if's to detect entering fort. start fortSession:
                    //**************************************************************************
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1);
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(),world.GetPlayer().GetPlayerY());
                        return true;
                    } 
                    break;
                case "NE":
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() - 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() + 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() + 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() + 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() + 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() + 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() - 1, world.GetPlayer().GetPlayerX() + 1);
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    break;
                case "SW":
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() - 1);
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    break;
                case "SE":
                    if (!world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = 'O';
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1];
                            world.GetCharArr()[world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1] = 'C';
                            world.GetCharArr()[world.GetPlayer().GetPlayerY(), world.GetPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(world.GetPlayer().GetPlayerY() + 1, world.GetPlayer().GetPlayerX() + 1);
                        }
                        StartFortSession(world.GetPlayer().GetPlayerX(), world.GetPlayer().GetPlayerY());
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        } 

        //move character arround in array:
        public bool Play()
        {
            Console.WriteLine("north, south, east, Or west?");
            string s = Console.ReadLine();
            switch (s)
            {
                case "north":
                case "n":
                    if (!Move("N")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    break;
                case "south":
                case "s":
                    if (!Move("S")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    break;
                case "east":
                case "e":
                    if (!Move("E")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    break;
                case "west":
                case "w":
                    if (!Move("W")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    break;
                //diag moves split into own routine to make it easier to read/debug:
                case "norteast":
                case "ne":
                    if (!DiagMove("NE")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    break;
                case "northwest":
                case "nw":
                    if (!DiagMove("NW")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    break;
                case "southwest":
                case "sw":
                    if (!DiagMove("SW")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    break;
                case "southeast":
                case "se":
                    if (!DiagMove("SE")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    break;
                //*****************************************
                case "exit":
                case "quit":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Not valid direction.");
                    return true;
            }
            //reset back to white:
            ResetColors();
            return true;
        }

        public static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ChooseColor(char chr)
        {
            switch (chr)
            {
                case 'O':
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 'W':
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 'T':
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'F':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 'C':
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ' ':
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 'S':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    ResetColors();
                    break;
            }
        }

        public void DrawAllForts()
        {
            for (int i = 0; i < world.GetFortArr().Length; i++)
            {
                //debug:
                ResetColors();
                Console.WriteLine("Fort At: X:" + world.GetFortArr()[i].GetFortX() + ", Y:" + world.GetFortArr()[i].GetFortY());
                //keep forts cubes or allow different shapes?
                for (int j = 0; j < world.GetFortYDim(); j++)
                {
                    for (int k = 0; k < world.GetFortXDim(); k++)
                    {
                        //public static void ChooseColor(charArr[i,j])
                        ChooseColor(world.GetFortArr()[i].GetFortCharArr()[j,k]);
                        Console.Write(" " + world.GetFortArr()[i].GetFortCharArr()[j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void DrawMap()
        {
            for (int i = 0; i < world.GetLengthXY('y'); i++)
            {
                for (int j = 0; j < world.GetLengthXY('x'); j++)
                {
                    ChooseColor(world.GetCharArr()[i, j]);
                    Console.Write(" " + world.GetCharArr()[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void CreateMap()
        {
            //1.fill with all W:
            for (int i = 0; i < world.GetLengthXY('y'); i++)
            {
                for (int j = 0; j < world.GetLengthXY('x'); j++)
                {
                    world.GetCharArr()[i,j] = 'W';
                }
            }
            //2. fill all but first layer as O:
            for (int i = 1; i < world.GetLengthXY('y') - 1; i++)
            {
                for (int j = 1; j < world.GetLengthXY('x') - 1; j++)
                {
                    world.GetCharArr()[i, j] = 'O';
                }
            }
            //3. fill randomly with trees
            for (int i = 1; i < world.GetLengthXY('y') - 1; i++)
            {
                for (int j = 1; j < world.GetLengthXY('x') - 1; j++)
                {
                    //<5 percent chance of tree
                    //once tree decided, then higher chance of trees in spaces arround it
                    //if(j==i)charArr[i, j] = 'T';
                    int num = rand.Next(1, 26);
                    if (num == 1 || num == 2 || num == 3 || num == 4 || num == 5)
                    {
                        //ChooseColor(charArr[i, j]);
                        //Console.ForegroundColor = ConsoleColor.DarkGreen;
                        world.GetCharArr()[i, j] = 'T';
                    }
                }
            }
            //4. fill randomly with fort
            for (int i = 1; i < world.GetLengthXY('y') - 1; i++)
            {
                for (int j = 1; j < world.GetLengthXY('x') - 1; j++)
                {
                    //<5 percent chance of fort
                    //once tree decided, then higher chance of trees in spaces arround it
                    //if(j==i)charArr[i, j] = 'T';
                    int num = rand.Next(1, 100);
                    if (num == 1 || num == 2)
                    {
                        //ChooseColor(charArr[i, j]);
                        //Console.ForegroundColor = ConsoleColor.DarkGreen;
                        world.GetCharArr()[i, j] = 'F';
                        fortCount++;
                        world.AddFortToArr(CreateFort(j, i));
                    }
                }
            }
            //5. set postion of character:
            //charArr[charPosY, charPosX] = 'C';
            world.GetCharArr()[world.GetPlayer().GetPlayerY(),world.GetPlayer().GetPlayerX()] = 'C';
            //print out array:
            DrawMap();
            //print out forts:
            //DrawAllForts();
            //reset back to white:
            ResetColors();
            //Console.ReadLine();
        }

        public Fort CreateFort(int x, int y)
        {
            //issue because using the wrong integers when assigning chr[] dimentions:
            char[,] chr = new char[world.GetFortYDim(), world.GetFortXDim()];
            //1.fill with all W:
            for (int j = 0; j < world.GetFortYDim(); j++)
            {
                for (int k = 0; k < world.GetFortXDim(); k++)
                {
                    chr[j, k] = 'W';
                }
            }
            //2. empty space:
            for (int j = 1; j < world.GetFortYDim() - 1; j++)
            {
                for (int k = 1; k < world.GetFortXDim() - 1; k++)
                {
                    chr[j, k] = ' ';
                }
            }
            //3. slab:
            for (int j = 1; j < world.GetFortYDim() - 1; j++)
            {
                for (int k = 1; k < world.GetFortXDim() - 1; k++)
                {
                    //<5 percent chance of tree
                    //once tree decided, then higher chance of trees in spaces arround it
                    //if(j==i)charArr[i, j] = 'T';
                    int num = rand.Next(1, 26);
                    if (num == 1 || num == 2 || num == 3 || num == 4 || num == 5)
                    {
                        //ChooseColor(charArr[i, j]);
                        //Console.ForegroundColor = ConsoleColor.DarkGreen;
                        chr[j, k] = 'S';
                    }
                }
            } //4. fill in character space
            //error on this line causes error on fort f declaration:
            //change to bottom left corner:
            chr[chr.GetLength(0)-2, 1] = 'C';
            //construct new player for fort constructor:
            //flip x and y?
            Player p = new Player(chr.GetLength(1) / 2, chr.GetLength(0) / 2);
            //5. exit space:
            //PASS p AS PARAMETER TO f:
            Fort f = new Fort(x, y, chr);
            return f;
        }

        public void AskSize()
        {
            while (true)
            {
                int x = 0;
                int y = 0;
                int fortDimX = 0;
                int fortDimY = 0;
                int charPosX = 0;
                int charPosY = 0;
                char[,] charArr;
                Console.WriteLine("Enter X (Greater than 5):");

                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine("Wrong input"); continue; }
                Console.WriteLine("Enter Y (Greater than 5):");
                try
                {
                    y = int.Parse(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine("Wrong input"); continue; }
                // same thing for fort size:
                Console.WriteLine("Enter Fort Size (Greater than 5):");
                try
                {
                    //fortSpace = int.Parse(Console.ReadLine());
                    //same value for now:
                    fortDimX = int.Parse(Console.ReadLine());
                    fortDimY = fortDimX;
                }
                catch (Exception e) { Console.WriteLine("Wrong input"); continue; }
                //saved locally instead:

                //world.SetLengthXY(x, false);
                //world.SetLengthXY(y, true);
                //lX = x;
                //lY = y; 
                //update x and y values of char:
                charPosX = x / 2;
                charPosY = y / 2;
                if (x <= 5 || y <= 5)
                    continue;
                //construct charArr:
                charArr = new char[y, x];
                //WHERE TO DO THIS NEED TO CREATE EVERYTING BEFORE WORLD IS READY???
                Player p = new Player(charPosX, charPosY);
                //construct fort[] (initial size 0, add with method in world.cs:
                Fort[] f = new Fort[0];
                world = new World(charArr,p,f,fortDimX,fortDimY);
                break;
            }
        }

        public WorldSession()
        {

        }
    }
}
