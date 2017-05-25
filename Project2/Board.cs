using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Board
    {


        ///***************** BEGIN CONSTANTS AND STATIC VARIABLES ***********************

        public const byte EMPTY = 0;
        public const byte RED = 1;
        public const byte BLACK = 2;

        //possible results for terminal test
        public const int WIN = 0;        
        public const int DRAW = 1;       
        public const int CONTINUE = 2;   

        public const int P1WINSCORE =  1000000;  //p1 seeks to maximize P1's utility
        public const int P2WINSCORE = -1000000;  //p2 seeks to minimize P1's utiltiy

        public static int columns;
        public static int rows;
        public static int winReq;

        //do this ONCE at the start of every game
        //move ordering makes alpha-beta pruning more effective; we know intuitively (or from experience) that moves in the middle should
        //be evaluated first.  NOTE: ALL MOVES WILL STILL BE EVALUATED (unless pruned by alpha-beta).  we are just adding the moves to the tree in this order :)  
        public static int[] colOrder;

        public static Diagonals backwardDiags;    //track information about the Diagonals.  we set these up ONCE before the game starts.
        public static Diagonals forwardDiags;     //track information about the Diagonals.  we set these up ONCE before the game starts.

        //public static int[,] slotWeights;         //used by BetterRateBoard to weight the center slots more.  we set this up ONCE before the game starts.

        ///***************** END CONSTANTS AND STATIC VARIABLES ***********************


        public Boolean turnP1 = true;  //is it P1's turn to make a move?  tracking who goes *next*

        public int terminalTestResults; //store results of terminal test here (WIN, DRAW, CONTINUE)

        public byte[,] arr;
        public byte[] height;        //tracks how many chips are currently entered in each column     

        //track the action that got us here from the previous state
        public int action = -1;  //-1 for root  

        //if still going, have state value... or statevalue = 1000000 for win, -1000000 for loss, 0 for draw.
        public int stateValue;       
        public int nextAction = -1;  //action we should take *next* to get to the desired state

        public List<Board> children;


        /////////////// BEGIN Diagonals Subclass ////////////
        public class Diagonals    //records 1) number of diagonals to check
                                  //        2) length of each diagonal in diagLength array
                                  //        3) xCoord of each diagonal in xStart array
                                  //        4) yCoord of each diagonal in yStart array
                                  //        this is the information we need to easily traverse diagonals in the terminal test.          
        {
            public int numDiags;
            public int[] xStart;
            public int[] yStart;
            public int[] diagLength;

            public Diagonals(int numDiags)
            {
                this.numDiags = numDiags;
                xStart = new int[numDiags];
                yStart = new int[numDiags];
                diagLength = new int[numDiags];
            }
        }
        /////////////// END Diagonals Subclass //////////////




        public Board()
        {
            arr = new byte[rows, columns];
            height = new byte[columns];            
        }

        //primitive move ordering: evaluate the moves towards the middle first.
        //to do this, assign the columns in the middle higher priority than the other columns.
        //do this ONCE at the start of every game
        //move ordering makes alpha-beta pruning more effective; we know intuitively (or from experience) that moves in the middle should
        //be evaluated first.  Note: all moves will still be evaluated (unless pruned by alpha-beta) :) just changing the order they are added to the tree!
        //(0 is highest priority.)
        //examples:
        //if columns = 7, colOrder = [5,3,1,0,2,4,6]
        //if columns = 6, colOrder = [5,3,1,0,2,4]       
        public static void setColumnPriorities()
        {
            colOrder = new int [columns];
            //slots 0 - columns-1..
            int middle = columns / 2;
            int sign = 1;
            for (int i = 0; i < columns; i ++)
            {
                colOrder[middle + sign * (int) Math.Ceiling((double)i/2)] = i;               
                sign = -sign;
            }
            //System.Console.WriteLine(string.Join(",", colOrder));
        }

        //used by BetterRateBoard to weight the center slots more.  we set this up ONCE before the game starts.
        /*
        public static void setSlotWeights()
        {
            slotWeights = new int [rows, columns];

            for (int i = 0; i < rows; i++)
            { 
                for (int j = 0; j < columns; j++)
                {
                    slotWeights[i, j] = Math.Min(i, rows - i) + Math.Min(j, columns - j);
                    //System.Console.Write(slotWeights[i, j] + ",");
                }
                //System.Console.WriteLine();
            }
        }
        */

        //set up the diagonals - we do this ONCE for each game, at the start.    
        //we only need to check diagonals which have enough slots to meet WinReq.
        //records 1) number of diagonals to check
        //        2) length of each diagonal in diagLength array
        //        3) xCoord of each diagonal in xStart array
        //        4) yCoord of each diagonal in yStart array
        //        this is the information we need to easily traverse diagonals in the terminal test.          
        public static void setupDiagonals()
        {
            int numDiagonals = Board.rows + Board.columns - 1;
            int xStart = Board.winReq - 1;

            //if xStart >= columns, board is too narrow for diagonal win
            int yStart = 0;
            int xEnd = Math.Min(Board.columns - 1, numDiagonals - Board.winReq + 1);
            //if yEnd < 0, board is too short for diagonal win
            int yEnd = numDiagonals - Board.winReq - xEnd;

            if ((xStart < Board.columns) && (yEnd >= 0))
            {
                int numDiagsToCheck = numDiagonals - (Board.winReq - 1) * 2;
                backwardDiags = new Diagonals(numDiagsToCheck);
                forwardDiags = new Diagonals(numDiagsToCheck);

                int xB, yB;     //temp variables, backward diagonals

                //follow each diagonal until we fall off the board.
                for (int i = 0; i < numDiagsToCheck; i++)
                {
                    if ((Board.columns - 1) >= (xStart + i))
                    {
                        xB = xStart + i;
                        yB = 0;
                    }
                    else
                    {
                        xB = Board.columns - 1;
                        yB = (xStart + i) - (Board.columns - 1) + yStart;
                    }
                    backwardDiags.xStart[i] = xB;
                    forwardDiags.xStart[i] = Board.columns - 1 - xB;  //forwardDiags mirrors backwardDiags.

                    backwardDiags.yStart[i] = yB;
                    forwardDiags.yStart[i] = backwardDiags.yStart[i]; //forwardDiags mirrors backwardDiags.
                    backwardDiags.diagLength[i] = 0;
                    while ((xB >= 0) && (yB < Board.rows))
                    {
                        backwardDiags.diagLength[i]++;
                        xB--;
                        yB++;
                    }
                    forwardDiags.diagLength[i] = backwardDiags.diagLength[i];
                }
                /*
                Console.WriteLine("total number of diagonals: " + numDiagonals);
                Console.WriteLine("number of diagonals to check: " + numDiagsToCheck);
                for (int i = 0; i < backwardDiags.numDiags; i++)
                {
                    Console.WriteLine("Backward Diagonal number: " + i + ", Length: " + backwardDiags.diagLength[i] +
                        ", xStart: " + backwardDiags.xStart[i] + ", yStart: " + backwardDiags.yStart[i]);
                    Console.WriteLine("Forward Diagonal number: " + i + ", Length: " + forwardDiags.diagLength[i] +
                        ", xStart: " + forwardDiags.xStart[i] + ", yStart: " + forwardDiags.yStart[i]);
                }
                */
            }
            else
            {
                backwardDiags = new Diagonals(0);
                forwardDiags = new Diagonals(0);
            }
        }
           
        //output a board to the screen.
        public void printBoard()
        {
            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch (arr[i, j])
                    {
                        case EMPTY:
                            Console.Write(".");
                            break;
                        case RED:
                            Console.Write("O");
                            break;
                        case BLACK:
                            Console.Write("X");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        //drops a chip in a slot
        //returns true if chip added to board successfully.
        //returns false if the column was full.
        //if slot filled, flip turnP1 (change the turn)

        public bool fillSlot(int col)
        {
            if (height[col] != rows)    
            {
                byte chip = (turnP1) ? RED : BLACK;
                arr[height[col], col] = chip;
                height[col]++;
                turnP1 = !turnP1;
                return true;
            }
            else
            {   //column is full, can't add any more chips to this column
                return false;
            }

        }

        //checks horizontals -, verticals |, backwards diags \, and forwards diags /  for winning lines.
        //returns WIN, DRAW, or CONTINUE.
        //also set the terminalTestResults variable to record this knowledge.
        public int TerminalTest()
        {
            int chip = (turnP1) ? BLACK : RED;  //if it's P1's turn now, P2 just moved.  we are only checking victory conditions for the player who just moved.
            int boardHeight = height.Max();
            int counter, i, j;

            //check for horizontal win.
            for (i = 0; i < boardHeight; i++)
            {
                counter = 0;
                for (j = 0; j < columns; j++)
                {
                    if (arr[i, j] == chip)
                    {
                        counter++;
                        if (counter >= winReq)
                        {
                            terminalTestResults = WIN;
                            return WIN;
                        }
                    }
                    else
                    {
                        counter = 0;  //start counting again
                    }
                }
            }

            //don't bother checking verticals or diagonals unless boardHeight >= winReq.
            if (boardHeight >= winReq)
            {
                //check for vertical win.          
                for (i = 0; i < columns; i++)
                {
                    counter = 0;
                    for (j = 0; j < height[i]; j++)
                    {
                        if (arr[j, i] == chip)
                        {
                            counter++;
                            if (counter >= winReq)
                            {
                                terminalTestResults = WIN;
                                return WIN;
                            }
                        }
                        else
                        {
                            counter = 0; //start counting again.
                        }
                    }
                }

                //check for \ backwards-diagonal win
                for (i = 0; i < backwardDiags.numDiags; i++)
                {
                    counter = 0;
                    for (j = 0; j < backwardDiags.diagLength[i]; j++)
                    {
                        if (arr[backwardDiags.yStart[i] + j, backwardDiags.xStart[i] - j] == chip)
                        {
                            counter++;
                            if (counter >= winReq)
                            {
                                terminalTestResults = WIN;
                                return WIN;
                            }
                        }
                        else
                        {
                            counter = 0; //start counting again
                        }
                    }
                }

                //check for / forwards-diagonal win
                //if 
                for (i = 0; i < forwardDiags.numDiags; i++)
                {
                    counter = 0;
                    for (j = 0; j < forwardDiags.diagLength[i]; j++)
                    {
                        if (arr[forwardDiags.yStart[i] + j, forwardDiags.xStart[i] + j] == chip)
                        {
                            counter++;
                            if (counter >= winReq)
                            {
                                terminalTestResults = WIN;
                                return WIN;
                            }
                        }
                        else
                        {
                            counter = 0; //start counting again
                        }
                    }
                }
            }
            //is the board full? 
            for (i = 0; i < columns; i++)  //columns = height.Length
            {
                if (height[i] < rows)
                {
                    terminalTestResults = CONTINUE;
                    return CONTINUE;
                }
            }

            terminalTestResults = DRAW;
            return DRAW;
        }



        //drop a chip in the first available slot
        //return the slot chosen.
        //also return the boardValue... sadly for herpderp, all boards have the same value.
        public int herpderp(ref int boardValue)
        {
            int chip = (this.turnP1) ? RED : BLACK;
            int i = 0;
            while (!this.fillSlot(i))   //keep trying until we find an available slot.
            {
                i++;
            }
            boardValue = 1;
            return i;
        }

        //create a child board from the current board by dropping in a chip.
        public Board createChildBoard(int i)
        {
            Board newChild = new Board();
            Array.Copy(arr, newChild.arr, rows * columns);
            Array.Copy(height, newChild.height, height.Length);
            byte chipColor = turnP1 ? RED : BLACK;
            newChild.action = i;
            newChild.arr[height[i], i] = chipColor;
            newChild.height[i]++;
            newChild.turnP1 = !turnP1;

            return newChild;
        }

        /*
        //recursive function that takes in a board state and generates all possible states given the valid moves/
        //rules of the game, to the depth requested.
        //also the rates the boards of the leaf nodes.
        public void buildTree(int depth)
        {
            //stop recursion when depth = 0, or reached a full board, or reached a win.
            if ((TerminalTest() == CONTINUE) && (depth > 0))
            {
                for (int i = 0; i < columns; i++)
                {
                    if (height[colOrder[i]] < rows)
                    {
                        if (children == null)
                            children = new List<Board>();
                        Board newChild = createChildBoard(colOrder[i]);
                        children.Add(newChild);
                        newChild.buildTree(depth - 1);
                    }
                }
            }
        }
        */

        //drop a chip in a slot picked by MiniMax
        //return the slot chosen.
        //also return the calculated board value parameter (boardValue)
        public int MiniMaxStart(ref int boardValue, int depth)
        {
            //buildTree(depth * 2);           //*2 because doing two moves (player 1 and player 2) per depth.

            int alpha = P2WINSCORE - 1;  //highest value found so far for Max
            int beta = P1WINSCORE + 1;   //lowest value found so far for Min

            if (turnP1)
            {
                MaxiRateNodes(alpha, beta, depth*2);
            }
            else
            {
                MiniRateNodes(alpha, beta, depth*2);
            }

            this.fillSlot(nextAction);
            boardValue = stateValue;

            children = null;
            return nextAction;
        }


        public void MaxiRateNodes(int alpha, int beta, int depth)
        {
            //if node is a leaf, rate it
            if ((TerminalTest() != CONTINUE) || (depth == 0))
            {
                if (ConnectR.getCurrentPlayer().algorithm == ConnectR.MINIMAX1)
                {
                    stateValue = RateBoard1();
                }
                else
                {
                    stateValue = BetterRateBoard();
                }
                //Console.WriteLine("Rated Value: " + board.stateValue);
                //board.printBoard();
            }
            else 
            {
                stateValue = alpha;  //any choice is better than this rating, for P1!

                for (int i = 0; i < columns; i++)
                {
                    if (height[colOrder[i]] < rows)
                    {
                        //foreach (Board child in children)
                        //{
                        if (children == null)
                            children = new List<Board>();
                        Board child = createChildBoard(colOrder[i]);
                        children.Add(child);
                        child.MiniRateNodes(alpha, beta, depth - 1);

                        //if (child.stateValue > stateValue)
                        if (child.stateValue > alpha)
                        {
                            alpha = child.stateValue;
                            stateValue = child.stateValue;
                            nextAction = child.action;
                        }

                        if (stateValue >= beta)
                        {
                            break;
                        }

                    }
                }
            }
        }

        public void MiniRateNodes(int alpha, int beta, int depth)
        {
            //if node is a leaf, rate it
            if ((TerminalTest() != CONTINUE) || (depth == 0))
            {
                if (ConnectR.getCurrentPlayer().algorithm == ConnectR.MINIMAX1)
                {
                    stateValue = RateBoard1();
                }
                else
                {
                    stateValue = BetterRateBoard();
                }
                //Console.WriteLine("Rated Value: " + board.stateValue);
                //board.printBoard();
            }
            else             {
                stateValue = beta;  //any choice is better than this rating, for P2!

                for (int i = 0; i < columns; i++)
                {
                    if (height[colOrder[i]] < rows)
                    {
                        //foreach (Board child in children)
                        //{
                        if (children == null)
                            children = new List<Board>();
                        Board child = createChildBoard(colOrder[i]);
                        children.Add(child);
                        child.MaxiRateNodes(alpha, beta, depth - 1);

                        if (child.stateValue < beta)
                        {
                            beta = child.stateValue;
                            stateValue = child.stateValue;
                            nextAction = child.action;
                        }

                        if (stateValue <= alpha)
                        {
                            break;
                        }
                    }
                }

            }
        }



        ///********************************************************************************************************************* 
        /// 
        /// HEURISTIC ALGORITHM SECTION BELOW
        /// HEURISTIC ALGORITHM SECTION BELOW
        /// HEURISTIC ALGORITHM SECTION BELOW
        /// 
        ///********************************************************************************************************************* 


        public class Band
        {
            //bands: contiguous collections of chips and open spaces, blocked by boundaries or by opposing chips.
            public int totalLength;
            //each band has a totalLength.  totalLength >= winReq.
            //if totalLength < winReq, useless. can't win with it.

            //if total length is too large, the pieces will be too spread out...
            //but spread out pieces will inherently mean less bands on a medium-small board (since corners have fewer diagonals) - less points.
            
            public int chips;
            //how many chips are filled in in this space?  
            //obviously, the more chips the better.

            //e.g. OO_OO_O  totalLength = 7, chips = 5.
            //problem:
            // values O.....O same as ...OO..
            
            public Band (int totalLength, int chips)
            {
                this.totalLength = totalLength;
                this.chips = chips;
            }
        }

        //A better heuristic function that takes in a state and player and generates a numeric value denoting
        //the quality of the state for the player.
        //assigns positive values for P1 (Max) 
        //assigns negative values for P2 (Min)
        //then estimated utility = P1 points - P2 points
        public int BetterRateBoard()
        {
            //first check wonFlag and drawFlag.  
            //rate P1 win as   1000000.    
            //rate P2 loss as -1000000.
            //rate draw as  0.
            int result = 0;

            if (terminalTestResults == DRAW)
            {
                result = 0;
            }
            else if (terminalTestResults == WIN)
            {
                if (turnP1)         //P2 just went; victory resulted from P2's move
                {
                    result = P2WINSCORE;
                }
                else                //P1 just went; victory resulted from P1's move
                {
                    result = P1WINSCORE;
                }
            }
            else
            {
                List<Band> redBands = new List<Band>();     //P1             
                List<Band> blackBands = new List<Band>();   //P2

                //rate horizontals.
                int boardHeight = height.Max();
                int i, j;
                int redBandLength, redChips;
                int blackBandLength, blackChips;

                //find horizontal bands
                for (i = 0; i < boardHeight; i++)
                {
                    redBandLength = 0;
                    redChips = 0;
                    blackBandLength = 0;
                    blackChips = 0;

                    for (j = 0; j < columns; j++)
                    {
                        if (arr[i, j] == RED)
                        {
                            redBandLength++;
                            redChips++;

                            if (blackChips != 0)
                            {
                                if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    blackBands.Add(new Band(blackBandLength, blackChips));
                                }
                                blackChips = 0;
                            }
                            blackBandLength = 0;
                        }
                        else if (arr[i, j] == BLACK)
                        {
                            blackBandLength++;
                            blackChips++;

                            if (redChips != 0)
                            {
                                if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    redBands.Add(new Band(redBandLength, redChips));
                                }
                                redChips = 0;
                            }
                            redBandLength = 0;
                        }
                        else //else if (arr[i, j] == EMPTY)
                        {
                            redBandLength++;
                            blackBandLength++;
                        }
                    }

                    //reached end of row
                    if (redChips != 0)
                    {
                        if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            redBands.Add(new Band(redBandLength, redChips));
                        }
                        redChips = 0;
                    }
                    redBandLength = 0;
                    if (blackChips != 0)
                    {
                        if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            blackBands.Add(new Band(blackBandLength, blackChips));
                        }
                        blackChips = 0;
                    }
                    blackBandLength = 0;

                }

                //find vertical lines
                for (i = 0; i < boardHeight; i++)
                {
                    redBandLength = 0;
                    redChips = 0;
                    blackBandLength = 0;
                    blackChips = 0;

                    for (j = 0; j < rows; j++)
                    {
                        if (arr[j, i] == RED)
                        {
                            redBandLength++;
                            redChips++;

                            if (blackChips != 0)
                            {
                                if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    blackBands.Add(new Band(blackBandLength, blackChips));
                                }
                                blackChips = 0;
                            }
                            blackBandLength = 0;
                        }
                        else if (arr[j, i] == BLACK)
                        {
                            blackBandLength++;
                            blackChips++;

                            if (redChips != 0)
                            {
                                if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    redBands.Add(new Band(redBandLength, redChips));
                                }
                                redChips = 0;
                            }
                            redBandLength = 0;
                        }
                        else //else if (arr[j, i] == EMPTY)
                        {
                            redBandLength++;
                            blackBandLength++;
                        }
                    }

                    //reached end of col
                    if (redChips != 0)
                    {
                        redBandLength += rows - boardHeight;    //because we stopped at rowHeight (above that is blank)
                        if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                        {                            
                            redBands.Add(new Band(redBandLength, redChips));
                        }
                        redChips = 0;
                    }
                    redBandLength = 0;
                    if (blackChips != 0)
                    {
                        blackBandLength += rows - boardHeight;    //because we stopped at rowHeight (above that is blank)
                        if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            blackBands.Add(new Band(blackBandLength, blackChips));
                        }
                        blackChips = 0;
                    }
                    blackBandLength = 0;
                }

                //find \ backwards-diagonal lines
                for (i = 0; i < backwardDiags.numDiags; i++)
                {
                    redBandLength = 0;
                    redChips = 0;
                    blackBandLength = 0;
                    blackChips = 0;

                    for (j = 0; j < backwardDiags.diagLength[i]; j++)
                    {

                        if (arr[backwardDiags.yStart[i] + j, backwardDiags.xStart[i] - j] == RED)
                        {
                            redBandLength++;
                            redChips++;

                            if (blackChips != 0)
                            {
                                if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    blackBands.Add(new Band(blackBandLength, blackChips));
                                }
                                blackChips = 0;
                            }
                            blackBandLength = 0;
                        }
                        else if (arr[backwardDiags.yStart[i] + j, backwardDiags.xStart[i] - j] == BLACK)
                        {
                            blackBandLength++;
                            blackChips++;

                            if (redChips != 0)
                            {
                                if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    redBands.Add(new Band(redBandLength, redChips));
                                }
                                redChips = 0;
                            }
                            redBandLength = 0;
                        }
                        else //else if (arr[j, i] == EMPTY)
                        {
                            redBandLength++;
                            blackBandLength++;
                        }
                    }

                    //reached end of diag
                    if (redChips != 0)
                    {
                        if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            redBands.Add(new Band(redBandLength, redChips));
                        }
                        redChips = 0;
                    }
                    redBandLength = 0;
                    if (blackChips != 0)
                    {
                        if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            blackBands.Add(new Band(blackBandLength, blackChips));
                        }
                        blackChips = 0;
                    }
                    blackBandLength = 0;
                }

                //find / forward-diagonal lines
                for (i = 0; i < forwardDiags.numDiags; i++)
                {
                    redBandLength = 0;
                    redChips = 0;
                    blackBandLength = 0;
                    blackChips = 0;

                    for (j = 0; j < forwardDiags.diagLength[i]; j++)
                    {
                        if (arr[forwardDiags.yStart[i] + j, forwardDiags.xStart[i] + j] == RED)
                        {
                            redBandLength++;
                            redChips++;

                            if (blackChips != 0)
                            {
                                if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    blackBands.Add(new Band(blackBandLength, blackChips));
                                }
                                blackChips = 0;
                            }
                            blackBandLength = 0;
                        }
                        else if (arr[forwardDiags.yStart[i] + j, forwardDiags.xStart[i] + j] == BLACK)
                        {
                            blackBandLength++;
                            blackChips++;

                            if (redChips != 0)
                            {
                                if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                                {
                                    redBands.Add(new Band(redBandLength, redChips));
                                }
                                redChips = 0;
                            }
                            redBandLength = 0;
                        }
                        else //else if (arr[i, j] == EMPTY)
                        {
                            redBandLength++;
                            blackBandLength++;
                        }
                    }

                    //reached end of diag
                    if (redChips != 0)
                    {
                        if (redBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            redBands.Add(new Band(redBandLength, redChips));
                        }
                        redChips = 0;
                    }
                    redBandLength = 0;
                    if (blackChips != 0)
                    {
                        if (blackBandLength >= winReq)      //bands smaller than winReq can't win.
                        {
                            blackBands.Add(new Band(blackBandLength, blackChips));
                        }
                        blackChips = 0;
                    }
                    blackBandLength = 0;

                }

                //score the bands...
                int bandScore;
                foreach (Band band in redBands)
                {
                    //value higher number of chips
                    bandScore = band.chips * band.chips;
                    result += bandScore;
                    //Console.WriteLine("red chips: " + band.chips + ", totalLength: " + band.totalLength + ", score: " + bandScore);
                }
                foreach (Band band in blackBands)
                {
                    //value higher number of chips
                    bandScore = band.chips * band.chips;
                    result -= bandScore;
                    //Console.WriteLine("black chips: " + band.chips + ", totalLength: " + band.totalLength + ", score: " + bandScore);
                }

                /*
                //finally, add weight for center squares...
                //we value center squares more.
                //actually lets hold off on this - already biased towards middle because middle produces more bands naturally.
                for (i = 0; i < rows; i++)
                {
                    for (j = 0; j < columns; j++)
                    {
                        //RED = +1, BLACK = -1.
                        result += arr[i, j] * slotWeights[i, j];
                    }
                }
                */

            }
            return result;
        }


        //A primitive heuristic function that takes in a state and player and generates a numeric value denoting
        //the quality of the state for the player.
        //assigns positive values for P1 (Max) 
        //assigns negative values for P2 (Min)
        public int RateBoard1 ()
        {
            //first check wonFlag and drawFlag.  
            //rate P1 win as   1000000.    
            //rate P2 loss as -1000000.
            //rate draw as  0.
            int result = 0;
            if (terminalTestResults == WIN)
            {
                if (turnP1)         //P2 just went; victory resulted from P2's move
                {
                    result = P2WINSCORE;
                }
                else                //P1 just went; victory resulted from P1's move
                {
                    result = P1WINSCORE;
                }
            }
            else if (terminalTestResults == DRAW)
            {
                result = 0;
            }
            else
            {
                //rate horizontals.

                int boardHeight = height.Max();
                //Console.WriteLine("board height is " + boardHeight);

                int i, j;
                int counter = 0;
                int chipResult;

                for (int CHIP = RED; CHIP <= BLACK; CHIP ++)
                {
                    chipResult = 0;

                    //score horizontal lines
                    for (i = 0; i < boardHeight; i++)
                    {
                        chipResult += counter * counter;
                        counter = 0;
                        for (j = 0; j < columns; j++)
                        {
                            if (arr[i, j] == CHIP)
                            {
                                counter++;
                            }
                            else
                            {
                                chipResult += counter * counter;
                                counter = 0;  //start counting again
                            }
                        }                        
                    }
                   
                    //score vertical lines
                    for (i = 0; i < columns; i++)
                    {
                        chipResult += counter * counter;
                        counter = 0;
                        for (j = 0; j < height[i]; j++)
                        {
                            if (arr[j, i] == CHIP)
                            {
                                counter++;
                            }
                            else
                            {
                                chipResult += counter * counter;
                                counter = 0;  //start counting again
                            }
                        }
                    }

                    //score \ backwards-diagonal lines
                    for (i = 0; i < backwardDiags.numDiags; i++)
                    {
                        chipResult += counter * counter;
                        counter = 0;
                        for (j = 0; j < backwardDiags.diagLength[i]; j++)
                        {
                            if (arr[backwardDiags.yStart[i] + j, backwardDiags.xStart[i] - j] == CHIP)
                            {
                                counter++;
                            }
                            else
                            {
                                chipResult += counter * counter;
                                counter = 0;  //start counting again
                            }
                        }
                    }

                    //score / forward-diagonal lines
                    for (i = 0; i < forwardDiags.numDiags; i++)
                    {
                        chipResult += counter * counter;
                        counter = 0;
                        for (j = 0; j < forwardDiags.diagLength[i]; j++)
                        {
                            if (arr[forwardDiags.yStart[i] + j, forwardDiags.xStart[i] + j] == CHIP)
                            {
                                counter++;
                            }
                            else
                            {
                                chipResult += counter * counter;
                                counter = 0;  //start counting again
                            }
                        }
                    }
                    chipResult += counter * counter;
                    counter = 0;                

                    if (CHIP == RED)
                    {
                        result += chipResult;
                    }
                    else
                    {
                        result -= chipResult;
                    }

                }
            }
            return result;
        }
    }
}
