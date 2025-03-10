using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Maxit
{
    public partial class MainForm : Form
    {
        private enum PlayerMode
        {
            Player,
            Computer
        }

        private const int ButtonSize = 32;
        private const byte MaxCalcLevel = 0;
        private const byte DefaultFieldSize = 10;
        private const byte MaxButtonValue = 10;
        private readonly Color PlayerOneBtnForeColor = Color.Blue;
        private readonly Color PlayerOneBtnBackColor = Color.Yellow;
        private readonly Color PlayerTwoBtnForeColor = Color.Red;
        private readonly Color PlayerTwoBtnBackColor = Color.DarkGray;

        private bool _firstPlayerMove = true;
        private readonly PlayerMode _firstPlayerMode;
        private readonly PlayerMode _secondPlayerMode;

        private Button[,] _buttons;
        private int _score1;
        private int _score2;
        private byte _fieldSize;
        private Point _currentPosition;

        public bool PlayerOneMove
        {
            get { return _firstPlayerMove; }
            set 
            { 
                _firstPlayerMove = value;
                if (value)
                {
                    lblScore1.BackColor = Color.LightSalmon;
                    lblScore2.BackColor = DefaultBackColor;
                }
                else
                {
                    lblScore1.BackColor = DefaultBackColor;
                    lblScore2.BackColor = Color.LightSalmon;
                }

            }
        }

        public Point CurrentPosition
        {
            get { return _currentPosition; }
            set { _currentPosition = value; ShowCurrentPosition(); }
        }

        public int Score1
        {
            get { return _score1; }
            set { _score1 = value; lblScore1.Text = string.Format("Player 1: {0}", value); }
        }

        public int Score2
        {
            get { return _score2; }
            set { _score2 = value; lblScore2.Text = string.Format("Player 2: {0}", value); }
        }

        public byte FieldSize
        {
            get { return _fieldSize; }
            set { _fieldSize = value; CreateNewField(); }
        }

        public MainForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            _firstPlayerMode = PlayerMode.Player;
            _secondPlayerMode = PlayerMode.Computer;
            FieldSize = DefaultFieldSize;
        }

        private void ShowCurrentPosition()
        {
            for (byte x = 0; x < FieldSize; x++)
                for (byte y = 0; y < FieldSize; y++)
                {
                    if (CurrentPosition.X != x && CurrentPosition.Y != y || string.IsNullOrEmpty(_buttons[x, y].Text))
                    {
                        _buttons[x, y].ForeColor = DefaultForeColor;
                        _buttons[x, y].BackColor = DefaultBackColor;
                    }
                    else
                    {
                        if (CurrentPosition.X == x)
                        {
                            _buttons[x, y].ForeColor = PlayerTwoBtnForeColor;
                            _buttons[x, y].BackColor = PlayerTwoBtnBackColor;
                        }
                        else
                        {
                            _buttons[x, y].ForeColor = PlayerOneBtnForeColor;
                            _buttons[x, y].BackColor = PlayerOneBtnBackColor;
                        }
                    }
                }
        }

        private void CreateNewField()
        {
            //clear game field
            panField.Controls.Clear();
            //clear score
            Score1 = Score2 = 0;
            PlayerOneMove = true;
            //set form size to fit all buttons
            this.Size = new Size(FieldSize * ButtonSize + 40, FieldSize * ButtonSize + 115);
            
            //create new game field
            Random rnd = new Random(); 
            _buttons = new Button[FieldSize, FieldSize];
            for (byte x = 0; x < FieldSize; x++)
                for (byte y = 0; y < FieldSize; y++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(ButtonSize, ButtonSize);
                    btn.Location = new Point(x * ButtonSize + 5, y * ButtonSize + 5);
                    _buttons[x, y] = btn;
                    btn.Font = new Font(FontFamily.GenericSansSerif, ButtonSize / 2, FontStyle.Bold);
                    btn.Tag = new Point(x, y);
                    btn.Click += btn_Click;
                    //set button value here
                    //btn.Text = string.Format("{0}{1}", x, y);
                    btn.Text = rnd.Next(1, MaxButtonValue).ToString();
                    panField.Controls.Add(btn);
                }
            CurrentPosition = new Point(FieldSize / 2, FieldSize / 2);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ProcessMove(sender as Button);
        }

        private void StartNewGame()
        {
            //if this is a old game not finished - show results
            if (Score1 != 0 || Score2 != 0)
            {
                if (Score1 > Score2)
                    MessageBox.Show("First player win!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    if (Score1 < Score2)
                        MessageBox.Show("Second player win!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("NOBODY wins", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (
                    MessageBox.Show("Start another game?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No)
                {
                    Close();
                    return;
                }
            }
            //start new game
            FieldSize = FieldSize;
        }

        private bool IsComputerMoveNow()
        {
            return PlayerOneMove
                   ? _firstPlayerMode == PlayerMode.Computer
                   : _secondPlayerMode == PlayerMode.Computer;
        }

        private byte[,] GetItemsFromField()
        {
            byte[,] itemsArr = new byte[FieldSize, FieldSize];
            for (byte x = 0; x < FieldSize; x++)
                for (byte y = 0; y < FieldSize; y++)
                {
                    string value = _buttons[x, y].Text;
                    if (string.IsNullOrEmpty(value))
                        itemsArr[x, y] = 0;
                    else
                        itemsArr[x, y] = byte.Parse(value);
                }
            return itemsArr;
        }

        private bool ChangeCurrentPlayer()
        {
            byte[,] itemsArr = GetItemsFromField();
            //check, does any move exists
            bool noMoves = true;
            for (int i = 0; i < FieldSize; i++)
                if (itemsArr[i, CurrentPosition.Y] != 0 || itemsArr[CurrentPosition.X, i] != 0)
                {
                    noMoves = false;
                    break;
                }
            //if no - finish game
            if (noMoves)
                return false;

            noMoves = true;
            for (byte i = 0; i < FieldSize; i++)
            {
                byte value = PlayerOneMove ? itemsArr[CurrentPosition.X, i] : itemsArr[i, CurrentPosition.Y];
                if (value != 0)
                {
                    noMoves = false;
                    break;
                }
            }
            if (noMoves)
            {
                MessageBox.Show(string.Format("{0} has no moves available! Skipping...", PlayerOneMove ? "First player" : "Second player"), "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return true;
            }

            PlayerOneMove = !PlayerOneMove;
            return true;
        }

        private void ProcessMove(Button btn)
        {
            if (btn == null) return;
            if (PlayerOneMove && btn.ForeColor != PlayerOneBtnForeColor ||
                !PlayerOneMove && btn.ForeColor != PlayerTwoBtnForeColor || 
                string.IsNullOrEmpty(btn.Text))
            {
                MessageBox.Show("Wrong move! Try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //process move
            if (!(btn.Tag is Point))
                return;
            Point pos = (Point)btn.Tag;
            if (PlayerOneMove)
                Score1 = Score1 + byte.Parse(btn.Text);
            else
                Score2 = Score2 + byte.Parse(btn.Text);
            btn.Text = string.Empty;
            CurrentPosition = pos;

            if (!ChangeCurrentPlayer())
            {
                StartNewGame();
                return;
            }

            //check is it time to computer move
            if (IsComputerMoveNow())
            {
                ProcessComputerMove(0, CurrentPosition.X, CurrentPosition.Y);
            }
        }

        private void ProcessComputerMove(int calcLevel, int posX, int posY)
        {
            //calculate next step
            byte[,] items = GetItemsFromField();
            int maxScore = 0;
            byte bestPos = 0;
            if (PlayerOneMove)
            {
                for (byte x = 0; x < FieldSize; x++)
                {
                    //skip unavailable moves
                    if (items[x, posY] == 0) continue;
                    //find best pos
                    int tmpScore = calcLevel <= MaxCalcLevel ? 
                        CalcBestScore(!PlayerOneMove, x, (byte)posY, items, calcLevel + 1) : 
                        items[x, posY];
                    if (tmpScore <= maxScore || tmpScore == 0) continue;
                    bestPos = x;
                    maxScore = tmpScore;
                }
                //use calculated pos
                ProcessMove(_buttons[bestPos, posY]);
            }
            else
            {
                for (byte y = 0; y < FieldSize; y++)
                {
                    //skip unavailable moves
                    if (items[posX, y] == 0) continue;
                    //find best pos
                    int tmpScore = calcLevel < MaxCalcLevel ?
                        CalcBestScore(!PlayerOneMove, (byte)posX, y, items, calcLevel + 1) :
                        items[posX, y];
                    if (tmpScore <= maxScore || tmpScore == 0) continue;
                    bestPos = y;
                    maxScore = tmpScore;
                }
                //use calculated pos
                ProcessMove(_buttons[posX, bestPos]);
            }
        }

        private int CalcBestScore(bool player1Move, byte x, byte y, byte[,] items, int calcLevel)
        {
            return 0;
        }
    }
}
