using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextVenture
{
    class FortSession
    {
        Fort fort;
        char currentBox = '[';
        //treat this class like session: containing all of the same methods but for fort instead of world:
        public void DrawMap()
        {
            for (int i = 0; i < fort.GetFortCharArr().GetLength(0); i++)
            {
                for (int j = 0; j < fort.GetFortCharArr().GetLength(1); j++)
                {
                    ChooseColor(fort.GetFortCharArr()[i,j]);
                    Console.Write(" " + fort.GetFortCharArr()[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void UpdateYX(int y, int x)
        {
            fort.GetFortPlayer().SetPlayerY(y);
            fort.GetFortPlayer().SetPlayerX(x);
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
                case '[':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case ']':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                default:
                    ResetColors();
                    break;
            }
        }

        //could just have fort here because fort contains instance of player?
        public FortSession(Fort f, Player p)
        {
            fort = f;
            fort.SetFortPlayer(p);
            DrawMap();
            ResetColors();
        }

        public bool Play()
        {
            Console.WriteLine("north, south, east, Or west?");
            string s = Console.ReadLine();
            switch (s)
            {
                //put all repeated code into new separate smaller routine to cut code down
                case "north":
                case "n":
                    if (!Move("N")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    //leaves 'C' at exit ']': restore fort location of 'C' to be ']' instead:
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                case "south":
                case "s":
                    if (!Move("S")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                case "east":
                case "e":
                    if (!Move("E")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                case "west":
                case "w":
                    if (!Move("W")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else DrawMap();
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                //diag moves split into own routine to make it easier to read/debug:
                case "norteast":
                case "ne":
                    if (!DiagMove("NE")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                case "northwest":
                case "nw":
                    if (!DiagMove("NW")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                case "southwest":
                case "sw":
                    if (!DiagMove("SW")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                case "southeast":
                case "se":
                    if (!DiagMove("SE")) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Coundn't go that way."); DrawMap(); }
                    else { DrawMap(); }
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    break;
                //*****************************************
                case "exit":
                case "quit":
                    //REMOVE THE 'C' SQUARE FROM THE MAP AND REPLACE WITH CURRENT BOX VALUE:
                    //***(temp fix, as the fort will have an entrance and an exit x and y at a later date):
                    fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                    //where start box is, change back to 'C':
                    //fort.GetFortCharArr()[fort.GetFortCharArr().GetLength(0)-2, 1] = 'C';
                    //fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(),  = 'C';
                    return false;
                default:
                    if (currentBox.Equals(']'))
                    {
                        fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                        return false;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Not valid direction.");
                    ResetColors();
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

        public bool DiagMove(string direction)
        {
            switch (direction)
            {
                case "NW": //charArr is world.GetCharArr()[,]:
                    //add else if's of these if's to detect entering fort. start fortSession:
                    //**************************************************************************
                    //add player to fort class:
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1);
                        } 
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() - 1);
                        }
                        return true;
                    }
                    break;
                case "NE":
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1);
                        } 
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX() + 1);
                        }
                        return true;
                    }
                    break;
                case "SW":
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() - 1);
                        }
                        return true;
                    }
                    break;
                case "SE":
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1].Equals('W'))
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX() + 1);
                        }
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        public bool Move(string direction)
        {
            //based on location of character, check one north south east or west of curr char location:
            switch (direction)
            {
                case "N":
                    //doesn't throw because of one space padding that is provided by the 'W' wall:
                    //could throw indexOutOfBoundsException:
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX()].Equals('W')  /*&&!charArr[charPosY-1,charPosX].Equals('T') && !charArr[charPosY-1, charPosX].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX()];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX()] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX());
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX()];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX()] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() - 1, fort.GetFortPlayer().GetPlayerX());
                        }
                        return true;
                    }
                    else
                        break;
                case "S":
                    //could throw indexOutOfBoundsException:
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX()].Equals('W')  /*&&!charArr[charPosY + 1, charPosX].Equals('T') && !charArr[charPosY + 1, charPosX].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX()];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX()] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX());
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX()];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX()] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY() + 1, fort.GetFortPlayer().GetPlayerX());
                        }
                        return true;
                    }
                    else
                        break;
                case "E":
                    //could throw indexOutOfBoundsException:
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1].Equals('W')  /*&&!charArr[charPosY, charPosX+1].Equals('T') && !charArr[charPosY, charPosX+1].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() + 1);
                        }
                        return true;
                    }
                    else
                        break;
                case "W":
                    //could throw indexOutOfBoundsException:
                    if (!fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1].Equals('W')  /*&&!charArr[charPosY, charPosX-1].Equals('T') && !charArr[charPosY, charPosX-1].Equals('F')*/)
                    {
                        //good! if currentBox not set yet:
                        if (currentBox.Equals(' '))
                        {
                            //set currentBox for the first time:
                            currentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = ' ';
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1);
                        }
                        else //currentBox set:
                        {
                            char futureCurrentBox = fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1];
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1] = 'C';
                            fort.GetFortCharArr()[fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX()] = currentBox;
                            currentBox = futureCurrentBox;
                            //update charposY and charPosX locations:
                            UpdateYX(fort.GetFortPlayer().GetPlayerY(), fort.GetFortPlayer().GetPlayerX() - 1);
                        }
                        return true;
                    }
                    else
                        break;

                default:
                    break;
            }
            
            return false;
        }
    }
}
