using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Maxit {
  
  public partial class MainForm : Form {
    
    #region Paint colors

    private static readonly Color boardBackColor = Color.MidnightBlue;
    private static readonly Color borderColor = Color.Aqua;
    private static readonly Color numberColor = Color.Gold;
    private static readonly Color currentNumberColor = Color.Blue;
    private static readonly Color currentCellColor = Color.Gold;
    private static readonly Color currentColumnColor = Color.CornflowerBlue;
    private static readonly Color currentRowColor = Color.DodgerBlue;

    #endregion Paint colors

    #region paint tools

    private readonly Pen borderPen = new Pen(borderColor, 3);
    private readonly Font drawFont = new Font("Verdana", 24);
    private readonly SolidBrush numberBrush = new SolidBrush(numberColor);
    private readonly SolidBrush currentNumberBrush = new SolidBrush(currentNumberColor);
    private readonly SolidBrush currentCellBrush = new SolidBrush(currentCellColor);
    private readonly SolidBrush currentColumnBrush = new SolidBrush(currentColumnColor);
    private readonly SolidBrush currentRowBrush = new SolidBrush(currentRowColor);
    private readonly StringFormat drawFormat = new StringFormat {
      Alignment = StringAlignment.Center,
      LineAlignment = StringAlignment.Center
    };

    #endregion paint tools
    
    #region game data

    private readonly Random random = new Random();
    private const int fieldSize = 10;
    private const int columns = fieldSize;
    private const int rows = fieldSize;
    
    private byte[,] gameValues;
    
    private bool firstMove;

    private bool player1Move;
    public bool Player1Move {
      get { return player1Move; }
      set {
        if (value == player1Move) return;
        player1Move = value;
        lblCurrentMove.Text = value ? "←" : "→";
      }
    }

    private int player1Score;
    public int Player1Score {
      get { return player1Score; }
      set {
        if (value == player1Score ) return;
        player1Score = value;
        lblPlayer1Score.Text = player1Score.ToString();
      }
    }

    private int player2Score;
    public int Player2Score {
      get { return player2Score; }
      set {
        if (value == player2Score ) return;
        player2Score = value;
        lblPlayer2Score.Text = player2Score.ToString();
      }
    }

    private int currentColumn;
    public int CurrentColumn {
      get { return currentColumn; }
      set {
        if (value == currentColumn) return;
        currentColumn = value;
        RedrawBoard();
        PlayWhipSound();
      }
    }

    private int currentRow;
    public int CurrentRow {
      get => currentRow;
      private set {
        if (value == currentRow) return;
        currentRow = value;
        RedrawBoard();
        PlayWhipSound();
      }
    }

    #endregion game data

    public MainForm() {
      
      InitializeComponent();
      
      this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
      this.StartPosition = FormStartPosition.CenterScreen;

      this.Width = 600;
      this.Height = 700;

      gameBoard.Paint += GameBoardOnPaint;
      gameBoard.SizeChanged += (sender, args) => RedrawBoard(); //redraw on panel resize
      gameBoard.MouseMove += GameBoardOnMouseMove;
      gameBoard.MouseClick += GameBoardOnMouseClick;
      
      StartNewGame();
    }

    private void StartNewGame() {

      gameValues = new byte[columns, rows];
      for (var i = 0; i < columns; i++) {
        for (var j = 0; j < rows; j++) {
          gameValues[i, j] = (byte)(random.Next(9) + 1); 
        }
      }

      firstMove = true;
      Player1Move = true;
      Player1Score = 0;
      Player2Score = 0;
      
      RedrawBoard();
    }

    #region paint
    
    private void RedrawBoard() {
      gameBoard.Invalidate();
    }
    
    private void GameBoardOnPaint(object sender, PaintEventArgs e) {

      var g = e.Graphics;
      g.Clear(boardBackColor);
      
      var cellSize = new Size(gameBoard.Width / columns, gameBoard.Height / rows);

      g.FillRectangle(currentColumnBrush, cellSize.Width * CurrentColumn, 0, cellSize.Width, gameBoard.Height);
      g.FillRectangle(currentRowBrush, 0, cellSize.Height * CurrentRow, gameBoard.Width, cellSize.Height);
        
      for (var i = 0; i < columns; i++) {

        for (var j = 0; j < rows ; j++) {

          g.DrawRectangle(borderPen, cellSize.Width * i, cellSize.Height * j, cellSize.Width, cellSize.Height);

          string cellText;
          if (gameValues[i, j] == 0)
            cellText = "";
          else
            cellText = gameValues[i, j].ToString();
          
          
          var cellCenter = new PointF(cellSize.Width * i + cellSize.Width / 2, cellSize.Height * j + cellSize.Height / 2);
          // var textSize = g.MeasureString(cellText, drawFont, cellCenter, drawFormat);

          if (CurrentColumn == i && CurrentRow == j) {
            g.FillRectangle(currentCellBrush, cellSize.Width * i, cellSize.Height * j, cellSize.Width, cellSize.Height);
            g.DrawString(cellText, drawFont, currentNumberBrush, cellCenter.X, cellCenter.Y, drawFormat);
          }
          else {
            g.DrawString(cellText, drawFont, numberBrush, cellCenter.X, cellCenter.Y, drawFormat);
          }

        }
      }
    }

    #endregion paint

    #region UI events

    private void btnRestart_Click(object sender, EventArgs e) {
      StartNewGame();
    }

    private void GameBoardOnMouseMove(object sender, MouseEventArgs e) {
      if (firstMove || Player1Move)
        CurrentColumn = e.Location.X / (gameBoard.Width / columns);
      if (firstMove || !Player1Move)
        CurrentRow = e.Location.Y / (gameBoard.Height / rows);
    }

    private void GameBoardOnMouseClick(object sender, MouseEventArgs e) {

      if (e.Button == MouseButtons.Left) {

        var clickColumn = e.Location.X / (gameBoard.Width / columns);
        var clickRow = e.Location.Y / (gameBoard.Height / rows);
        if (clickColumn != CurrentColumn || clickRow != CurrentRow) {
          PlayErrorSound();
          return;
        }

        var value = gameValues[currentColumn, currentRow];
        if (value == 0) {
          PlayErrorSound();
          return;
        }

        gameValues[currentColumn, currentRow] = 0; //todo: update game statistics
        firstMove = false;
        if (Player1Move)
          Player1Score += value;
        else
          Player2Score += value;

        if (PlayerCanMove(Player1Move))
          Player1Move = !Player1Move;
        else {
          //todo: check game over
          if (!PlayerCanMove(!Player1Move)) {
            var winner = Player1Score > Player2Score ? "Player 1" : "Player 2";
            MessageBox.Show($"Congratulations, {winner} win!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartNewGame();
          }
        }

        RedrawBoard();
        PlayTakeSound();
      }
    }

    #endregion

    #region sounds

    private Stream GetResource(string name) {
      var type = this.GetType();
      //var all = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceNames();
      var assembly = Assembly.GetAssembly(type);
      var scriptsPath = $"{type.Namespace}.{name}";
      var result = assembly.GetManifestResourceStream(scriptsPath);
      if (result == null)
        throw new Exception($"Resource {name} is not found.");
      return result;
    }

    private void PlayWhipSound() {
      using (var p = new System.Media.SoundPlayer(GetResource("sounds.whip.wav"))) {
        p.Play();
      }
    }

    private void PlayErrorSound() {
      //todo:
      System.Media.SystemSounds.Hand.Play();
      //using (var p = new System.Media.SoundPlayer(GetResource("sounds.error.wav"))) {
      //  p.Play();
      //}
    }

    private void PlayTakeSound() {
      //todo:
      System.Media.SystemSounds.Beep.Play();
      //using (var p = new System.Media.SoundPlayer(GetResource("sounds.take.wav"))) {
      //  p.Play();
      //}
    }

    #endregion

    #region logic

    private bool PlayerCanMove(bool firstPlayer) {
      if (firstPlayer) {
        for (var i = 0; i < rows; i++)
          if (gameValues[currentColumn, i] != 0)
            return true;
      }
      else {
        for (var i = 0; i < columns; i++)
          if (gameValues[i, currentRow] != 0)
            return true;
      }

      return false;
    }

    private const byte MaxCalcLevel = 0;

    private Point ProcessComputerMove(int calcLevel, int posX, int posY) {
      //calculate next step
      byte[,] items = gameValues;
      int maxScore = 0;
      int bestPos = 0;
      if (Player1Move) {
        for (int x = 0; x < fieldSize; x++) {
          //skip unavailable moves
          if (items[x, posY] == 0) continue;
          //find best pos
          int tmpScore = calcLevel <= MaxCalcLevel ?
              CalcBestScore(!Player1Move, x, (byte)posY, items, calcLevel + 1) :
              items[x, posY];
          if (tmpScore <= maxScore || tmpScore == 0) continue;
          bestPos = x;
          maxScore = tmpScore;
        }
        return new Point(bestPos, posY);
      }
      else {
        for (int y = 0; y < fieldSize; y++) {
          //skip unavailable moves
          if (items[posX, y] == 0) continue;
          //find best pos
          int tmpScore = calcLevel < MaxCalcLevel ?
              CalcBestScore(!Player1Move, (byte)posX, y, items, calcLevel + 1) :
              items[posX, y];
          if (tmpScore <= maxScore || tmpScore == 0) continue;
          bestPos = y;
          maxScore = tmpScore;
        }
        return new Point(posX, bestPos);
      }
    }

    private int CalcBestScore(bool player1Move, int x, int y, byte[,] items, int calcLevel) {
      return 0;
    }

    #endregion
  }
}