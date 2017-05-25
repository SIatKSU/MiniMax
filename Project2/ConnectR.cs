using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project2
{


    class ConnectR
    {
        public const int HERPDERP = 0;
        public const int MINIMAX1 = 1;
        public const int BETTERMINIMAX = 2;

        public static Board board;
                
        public static Player player1, player2;

        /////////////// BEGIN Player Subclass ///////////////
        public class Player         //player class tracks basic player settings.
        {
            internal Boolean isHuman;
            internal int algorithm;
            internal int depth;

            /* //experimenting with delegates
            public delegate int alg();
            public alg ratingAlg;            
            */
        }
        /////////////// END Player Subclass /////////////////

        public static void initPlayers()
        {
            player1 = new Player();
            player2 = new Player();
        }

        /* //experimenting with delegates
         * //to get this work - Convert Board.BetterRateBoard and Board.RateBoard1 to static methods.  I'd rather not do that right now! maybe later.
         * 
        //initialization method: for each player, set which rating algorithm they will use (based on what they chose in the comboboxes)
        public static void setRatingAlg(Player player)
        {
            if (player.algorithm == BETTERMINIMAX)
            {
                player.ratingAlg = Board.BetterRateBoard;
            }
            else
            {
                player.ratingAlg = Board.RateBoard1;
            }
        }
        */

        //create a new game board; calculate the lengths of the diagonals.
        //note: this method is called by the main form.  settings are read from the main form.
        public static void initMainBoard()
        {
            board = new Board();
            Board.setupDiagonals();
            Board.setColumnPriorities();
            //Board.setSlotWeights();       //no need; Rating is intrinsically biased towards center as is.
        }

        //return the current player.
        public static Player getCurrentPlayer()
        {
            return (board.turnP1) ? player1 : player2;
        }

        public static int getAImove(Player currPlayer, ref int boardValue)
        {
            int columnChoice;
            if (currPlayer.algorithm == HERPDERP)
            {
                columnChoice = board.herpderp(ref boardValue);
            }
            else
            { //if (currPlayer.algorithm == MINIMAX1} ||(currPlayer.algorithm == BETTERMINIMAX)
                columnChoice = board.MiniMaxStart(ref boardValue, currPlayer.depth);                
            }
            return columnChoice;
        }

        //main loop of the Connect 4 game.
        public static void MainLoop()
        {
            Stopwatch stopWatch = new Stopwatch();

            string choice;
            int columnChoice;
            bool exiting = false;

            if (player1.isHuman)
                board.printBoard();          //the AI doesn't need to see the board to make a move.

            do
            {
                string playerTurnString = (board.turnP1) ? "Player 1(Red/O)" : "Player 2(Black/X)";

                Player currPlayer = getCurrentPlayer();
                if (currPlayer.isHuman)
                //get human player's move.
                //(print the board, ask them for move, then execute it.)
                {
                    string promptText = playerTurnString + "\nMove?(0-" + (Board.columns - 1) + ", or 'q' to exit) : ";
                    Console.Write(promptText);
                    choice = Console.ReadLine();
                    if (choice == "q")
                    {
                        exiting = true;
                    }
                    else if (Int32.TryParse(choice, out columnChoice))
                    {
                        if ((columnChoice >= 0) && (columnChoice < Board.columns))
                        {
                            if (board.fillSlot(columnChoice))
                            {
                                //player completed a valid move.   redraw the board, and check if game is over
                                exiting = processMove(playerTurnString);
                            }
                            else
                            {
                                Console.WriteLine("Error: column " + columnChoice + " is full.  Try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: column " + columnChoice + " is out of bounds.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: invalid text entered.");
                    }

                }
                else
                {
                    //AI player *BLEEP BLOOP* calculate and execute best move *BLEEP BLOOP*
                    stopWatch.Restart();
                    int boardValue = 0;
                    columnChoice = getAImove(currPlayer, ref boardValue);

                    Console.WriteLine(playerTurnString + " has moved: " + columnChoice);
                    Console.WriteLine("Board state value = " + boardValue);

                    stopWatch.Stop();
                    Console.WriteLine("Elapsed time: approximately " + stopWatch.ElapsedMilliseconds + " ms.");
                    exiting = processMove(playerTurnString);
                }
            }
            while (!exiting);
        }

        //return true if game over, return false otherwise.
        //also output whether it was a win or a draw to the screen.   
        //if the game is not over, switch turns.
        private static Boolean processMove(string playerTurnString)
        {
            Boolean gameOver = false;
            board.printBoard();

            int result = board.TerminalTest();
            if (result == Board.WIN)
            {
                Console.WriteLine("\n" + playerTurnString + " won the game!");
                gameOver = true;
            }
            else if (result == Board.DRAW)
            {
                Console.WriteLine("\nBoard is full.  It's a draw!");
                gameOver = true;
            }
            return gameOver;
        }


        //debugging method.
        //read in a connectR gameboard state from a file and start playing from that point.
        public static bool LoadStateFromFile(string filename)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(filename);
            string lineOfText;

            Stack<string> boardStack = new Stack<string>();

            while ((lineOfText = sr.ReadLine()) != null)
            {
                boardStack.Push(lineOfText);
            }
            sr.Close();

            //need to read and set columns, rows, winReq, P1isRed, turnP1.
            Board.rows = boardStack.Count;
            Board.columns = boardStack.Peek().Length;

            initMainBoard();
            int currRow = 0;

            while (boardStack.Count != 0)
            {
                int currCol = 0;
                lineOfText = boardStack.Pop();
                foreach (char c in lineOfText)
                {
                    if (c == '.')
                        board.arr[currRow, currCol] = Board.EMPTY;
                    else if (c == 'O')
                        board.arr[currRow, currCol] = Board.RED;
                    else if (c == 'X')
                        board.arr[currRow, currCol] = Board.BLACK;
                    else
                    {
                        Console.WriteLine("Error reading the State file.");
                        return false;
                    }
                    currCol++;
                }
                currRow++;
            }

            //calculate and update the column heights - must be done when a board is loaded from a file.
            for (int i = 0; i < Board.columns; i++)
            {
                int j = 0;
                byte currHeight = 0;
                while ((j < Board.rows) && (board.arr[j, i] != Board.EMPTY))
                {
                    currHeight++;
                    j++;
                }
                board.height[i] = currHeight;
            }
            return true;
        }


    }
}
