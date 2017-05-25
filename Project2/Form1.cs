using System;
using System.Windows.Forms;


namespace Project2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Application.StartupPath;

            InitComboBoxes();
            ConnectR.initPlayers();

        }

        private void InitComboBoxes()
        {
            string[] algorithms = new string[] {"HerpDerp", "MiniMax1", "BetterMiniMax"};
            comboBoxAlgP1.Items.AddRange(algorithms);
            comboBoxAlgP2.Items.AddRange(algorithms);
            comboBoxAlgP1.SelectedIndex = 1;
            comboBoxAlgP2.SelectedIndex = 2;
        }

        //reads and sets columns, rows, winReq, P1isRed, turnP1.
        //sets up the board and starts the game.
        private void StartButton_Click(object sender, EventArgs e)
        {
            Board.columns = (int)numericUpDown_Col.Value;
            Board.rows = (int)numericUpDown_Row.Value;
            Board.winReq = (int)numericUpDown_WinReq.Value;

            if (Board.winReq > Math.Max(Board.columns, Board.rows))
            {
                MessageBox.Show("Invalid win requirement.  Either columns or rows *must* be >= Win-req.");
            }
            else
            {
                ConnectR.initMainBoard();
                ConnectR.board.turnP1 = true;

                ConnectR.player1.isHuman = radioButtonHuman1.Checked;
                ConnectR.player2.isHuman = radioButtonHuman2.Checked;

                if (!ConnectR.player1.isHuman)
                {
                    ConnectR.player1.algorithm = comboBoxAlgP1.SelectedIndex;
                    ConnectR.player1.depth = (int)numericUpDown_P1Depth.Value;
                    //ConnectR.setRatingAlg(ConnectR.player1);  //experimenting with delegates
                }

                if (!ConnectR.player2.isHuman)
                {
                    ConnectR.player2.algorithm = comboBoxAlgP2.SelectedIndex;
                    ConnectR.player2.depth = (int)numericUpDown_P2Depth.Value;
                    //ConnectR.setRatingAlg(ConnectR.player2);  //experimenting with delegates
                }

                //this.Hide();
                Program.ShowConsole();
                ConnectR.MainLoop();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Close();
            }
        }

        //debugging method to load a state from a file.
        private void loadStateButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //careful - some fields not created yet.  example: ConnectR.board has not yet been created.
                Board.winReq = (int)numericUpDown_WinReq.Value;

                if (ConnectR.LoadStateFromFile(openFileDialog1.FileName))
                {
                    if (Board.winReq > Math.Max(Board.columns, Board.rows))
                    {
                        MessageBox.Show("Invalid win requirement.  Either columns or rows *must* be >= Win-req.");
                    }
                    else
                    {
                        ConnectR.board.turnP1 = true;
                        ConnectR.player1.isHuman = false;
                        ConnectR.player1.algorithm = comboBoxAlgP1.SelectedIndex;
                        ConnectR.player1.depth = (int)numericUpDown_P1Depth.Value;
                        numericUpDown_Col.Value = Board.columns;
                        numericUpDown_Row.Value = Board.rows;

                        //Program.ShowConsole();
                        //ConnectR.board.printBoard();
                        //this.Hide();
                        //MainLoop();

                        ConnectR.board.printBoard();

                        //Console.WriteLine("Heights are: " + string.Join(",", board.height));

                        ConnectR.board.TerminalTest();
                        int rating = ConnectR.board.BetterRateBoard();
                        Console.WriteLine("Rating is : " + rating);
                        //Board newBoard = board.createChildBoard(4);
                        //newBoard.printBoard();
                        //Console.WriteLine("New Heights are: " + string.Join(",", newBoard.height));
                    }
                }
                else
                {
                    MessageBox.Show("Error reading the state file.");
                }
               
            }
        }

        private void radioButtonHuman1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHuman1.Checked)
            {
                numericUpDown_P1Depth.Enabled = false;
                comboBoxAlgP1.Enabled = false;
            }
            else
            {
                numericUpDown_P1Depth.Enabled = true;
                comboBoxAlgP1.Enabled = true;
            }
        }

        private void radioButtonHuman2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHuman2.Checked)
            {
                numericUpDown_P2Depth.Enabled = false;
                comboBoxAlgP2.Enabled = false;
            }
            else
            {
                numericUpDown_P2Depth.Enabled = true;
                comboBoxAlgP2.Enabled = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
