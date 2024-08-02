using System;
using System.Threading;
using System.IO;
using Console = System.Console;

namespace tictactoe
{
    class Program
    {
        private static char[] spaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static int jucator = 1;
        private static int choice;
        private static int flag;

        static void X0Board()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }

        public static int CheckIfContinue()
        {
            if ((spaces[0] == spaces[1] && spaces[1] == spaces[2])
                || (spaces[3] == spaces[4] && spaces[4] == spaces[5])
                || (spaces[6] == spaces[7] && spaces[7] == spaces[8])
                || (spaces[0] == spaces[3] && spaces[3] == spaces[6])
                || (spaces[1] == spaces[4] && spaces[4] == spaces[7])
                || (spaces[2] == spaces[5] && spaces[5] == spaces[8])
                || (spaces[0] == spaces[4] && spaces[4] == spaces[8])
                || (spaces[2] == spaces[4] && spaces[4] == spaces[6]))
            {
                return 1;
            }
            else if(spaces[0] == '1' ||
                    spaces[1] == '2' ||
                    spaces[2] == '3' ||
                    spaces[3] == '4' ||
                    spaces[4] == '5' ||
                    spaces[5] == '6' ||
                    spaces[6] == '7' ||
                    spaces[7] == '8' ||
                    spaces[8] == '9')
                {
                    return 0;
                }
            else
            {
                return -1;
            }
        }

        static void X(int pozitie)
        {
            spaces[pozitie] = 'X';
        }

        static void Zero(int pozitie)
        {
            spaces[pozitie] = '0';
        }

        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("jucator 1: X");
                Console.WriteLine("jucator 2: 0");

                Console.WriteLine("\n");
                X0Board();

                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' && spaces[choice] != '0')
                {
                    if (jucator % 2 == 0)
                    {
                        Zero(choice);
                    }
                    else
                    {
                        X(choice);
                    }
                    jucator++;

                }
                else
                {
                    Console.WriteLine("Sorry but the choice {0} is occupied", choice);
                    Console.WriteLine(("The board is loading..."));
                    Thread.Sleep(2000);
                }


                flag = CheckIfContinue();

            } while (flag == 0);
            
            Console.Clear();
            X0Board();
            
            if (flag == 1)
            {
                Console.WriteLine("Player {0} won!", (jucator % 2) + 1);
            }
            else 
            {
                Console.WriteLine("Tie game!");
            }
        }
        

    }
}