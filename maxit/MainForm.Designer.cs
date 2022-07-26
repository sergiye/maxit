namespace Maxit {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
      this.panScore = new System.Windows.Forms.Panel();
      this.lblScore2 = new System.Windows.Forms.Label();
      this.lblScore1 = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.panField = new System.Windows.Forms.Panel();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.panScore.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panScore
      // 
      this.panScore.Controls.Add(this.lblScore2);
      this.panScore.Controls.Add(this.lblScore1);
      this.panScore.Controls.Add(this.btnStart);
      this.panScore.Dock = System.Windows.Forms.DockStyle.Top;
      this.panScore.Location = new System.Drawing.Point(3, 3);
      this.panScore.Name = "panScore";
      this.panScore.Size = new System.Drawing.Size(278, 35);
      this.panScore.TabIndex = 0;
      // 
      // lblScore2
      // 
      this.lblScore2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblScore2.AutoSize = true;
      this.lblScore2.Location = new System.Drawing.Point(203, 12);
      this.lblScore2.Name = "lblScore2";
      this.lblScore2.Size = new System.Drawing.Size(48, 13);
      this.lblScore2.TabIndex = 2;
      this.lblScore2.Text = "Player 2:";
      // 
      // lblScore1
      // 
      this.lblScore1.AutoSize = true;
      this.lblScore1.Location = new System.Drawing.Point(5, 12);
      this.lblScore1.Name = "lblScore1";
      this.lblScore1.Size = new System.Drawing.Size(48, 13);
      this.lblScore1.TabIndex = 1;
      this.lblScore1.Text = "Player 1:";
      // 
      // btnStart
      // 
      this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnStart.Location = new System.Drawing.Point(102, 7);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 0;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(292, 306);
      this.tabControl1.TabIndex = 1;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.panField);
      this.tabPage1.Controls.Add(this.panScore);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(284, 280);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Game";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // panField
      // 
      this.panField.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panField.Location = new System.Drawing.Point(3, 38);
      this.panField.Name = "panField";
      this.panField.Size = new System.Drawing.Size(278, 239);
      this.panField.TabIndex = 1;
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(284, 280);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Options";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 306);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Maxit";
      this.panScore.ResumeLayout(false);
      this.panScore.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panScore;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Panel panField;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Label lblScore2;
    private System.Windows.Forms.Label lblScore1;
  }
}

