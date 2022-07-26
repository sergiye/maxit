using System.ComponentModel;

namespace Maxit {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.gameBoard = new System.Windows.Forms.PictureBox();
      this.panelControls = new System.Windows.Forms.Panel();
      this.btnRestart = new System.Windows.Forms.Button();
      this.lblCurrentMove = new System.Windows.Forms.Label();
      this.lblPlayer2Score = new System.Windows.Forms.Label();
      this.lblPlayer1Score = new System.Windows.Forms.Label();
      this.lblPlayer2 = new System.Windows.Forms.Label();
      this.lblPlayer1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
      this.panelControls.SuspendLayout();
      this.SuspendLayout();
      // 
      // gameBoard
      // 
      this.gameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gameBoard.Location = new System.Drawing.Point(0, 115);
      this.gameBoard.Name = "gameBoard";
      this.gameBoard.Size = new System.Drawing.Size(584, 546);
      this.gameBoard.TabIndex = 0;
      this.gameBoard.TabStop = false;
      // 
      // panelControls
      // 
      this.panelControls.BackColor = System.Drawing.Color.MidnightBlue;
      this.panelControls.Controls.Add(this.btnRestart);
      this.panelControls.Controls.Add(this.lblCurrentMove);
      this.panelControls.Controls.Add(this.lblPlayer2Score);
      this.panelControls.Controls.Add(this.lblPlayer1Score);
      this.panelControls.Controls.Add(this.lblPlayer2);
      this.panelControls.Controls.Add(this.lblPlayer1);
      this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControls.Location = new System.Drawing.Point(0, 0);
      this.panelControls.Name = "panelControls";
      this.panelControls.Size = new System.Drawing.Size(584, 115);
      this.panelControls.TabIndex = 1;
      // 
      // btnRestart
      // 
      this.btnRestart.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnRestart.ForeColor = System.Drawing.Color.LimeGreen;
      this.btnRestart.Location = new System.Drawing.Point(253, 67);
      this.btnRestart.Name = "btnRestart";
      this.btnRestart.Size = new System.Drawing.Size(94, 42);
      this.btnRestart.TabIndex = 5;
      this.btnRestart.Text = "Restart";
      this.btnRestart.UseVisualStyleBackColor = false;
      this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
      // 
      // lblCurrentMove
      // 
      this.lblCurrentMove.AutoSize = true;
      this.lblCurrentMove.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblCurrentMove.ForeColor = System.Drawing.Color.Crimson;
      this.lblCurrentMove.Location = new System.Drawing.Point(255, -15);
      this.lblCurrentMove.Name = "lblCurrentMove";
      this.lblCurrentMove.Size = new System.Drawing.Size(83, 84);
      this.lblCurrentMove.TabIndex = 4;
      this.lblCurrentMove.Text = "←";
      this.lblCurrentMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer2Score
      // 
      this.lblPlayer2Score.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer2Score.ForeColor = System.Drawing.Color.Yellow;
      this.lblPlayer2Score.Location = new System.Drawing.Point(475, 59);
      this.lblPlayer2Score.Name = "lblPlayer2Score";
      this.lblPlayer2Score.Size = new System.Drawing.Size(97, 50);
      this.lblPlayer2Score.TabIndex = 3;
      this.lblPlayer2Score.Text = "0";
      this.lblPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer1Score
      // 
      this.lblPlayer1Score.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer1Score.ForeColor = System.Drawing.Color.Yellow;
      this.lblPlayer1Score.Location = new System.Drawing.Point(12, 59);
      this.lblPlayer1Score.Name = "lblPlayer1Score";
      this.lblPlayer1Score.Size = new System.Drawing.Size(97, 50);
      this.lblPlayer1Score.TabIndex = 2;
      this.lblPlayer1Score.Text = "0";
      this.lblPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer2
      // 
      this.lblPlayer2.AutoSize = true;
      this.lblPlayer2.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer2.ForeColor = System.Drawing.Color.Gold;
      this.lblPlayer2.Location = new System.Drawing.Point(475, 21);
      this.lblPlayer2.Name = "lblPlayer2";
      this.lblPlayer2.Size = new System.Drawing.Size(97, 33);
      this.lblPlayer2.TabIndex = 1;
      this.lblPlayer2.Text = "Player 2";
      // 
      // lblPlayer1
      // 
      this.lblPlayer1.AutoSize = true;
      this.lblPlayer1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer1.ForeColor = System.Drawing.Color.Gold;
      this.lblPlayer1.Location = new System.Drawing.Point(12, 21);
      this.lblPlayer1.Name = "lblPlayer1";
      this.lblPlayer1.Size = new System.Drawing.Size(97, 33);
      this.lblPlayer1.TabIndex = 0;
      this.lblPlayer1.Text = "Player 1";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(584, 661);
      this.Controls.Add(this.gameBoard);
      this.Controls.Add(this.panelControls);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Text = "Maxit";
      ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
      this.panelControls.ResumeLayout(false);
      this.panelControls.PerformLayout();
      this.ResumeLayout(false);

    }

    private System.Windows.Forms.PictureBox gameBoard;
    private System.Windows.Forms.Panel panelControls;

    #endregion

    private System.Windows.Forms.Label lblPlayer2Score;
    private System.Windows.Forms.Label lblPlayer1Score;
    private System.Windows.Forms.Label lblPlayer2;
    private System.Windows.Forms.Label lblPlayer1;
    private System.Windows.Forms.Label lblCurrentMove;
    private System.Windows.Forms.Button btnRestart;
  }
}