namespace Game
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            playGame = new Button();
            exitGame = new Button();
            viewCredits = new Button();
            modeSelection = new ComboBox();
            goesFirst1 = new RadioButton();
            goesFirst2 = new RadioButton();
            SuspendLayout();
            // 
            // playGame
            // 
            playGame.Anchor = AnchorStyles.None;
            playGame.BackColor = Color.FromArgb(0, 171, 179);
            playGame.Cursor = Cursors.Hand;
            playGame.FlatAppearance.BorderSize = 3;
            playGame.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 246, 255);
            playGame.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 246, 255);
            playGame.FlatStyle = FlatStyle.Flat;
            playGame.Font = new Font("Arial", 30F, FontStyle.Bold, GraphicsUnit.Point);
            playGame.Location = new Point(92, 104);
            playGame.Margin = new Padding(5);
            playGame.Name = "playGame";
            playGame.Size = new Size(300, 75);
            playGame.TabIndex = 13;
            playGame.TabStop = false;
            playGame.Text = "PLAY";
            playGame.UseVisualStyleBackColor = false;
            playGame.Click += MenuHandler;
            // 
            // exitGame
            // 
            exitGame.Anchor = AnchorStyles.None;
            exitGame.BackColor = Color.FromArgb(178, 178, 178);
            exitGame.Cursor = Cursors.Hand;
            exitGame.FlatAppearance.BorderSize = 3;
            exitGame.FlatStyle = FlatStyle.Flat;
            exitGame.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            exitGame.Location = new Point(142, 189);
            exitGame.Margin = new Padding(5);
            exitGame.Name = "exitGame";
            exitGame.Size = new Size(200, 50);
            exitGame.TabIndex = 14;
            exitGame.TabStop = false;
            exitGame.Text = "EXIT";
            exitGame.UseVisualStyleBackColor = false;
            exitGame.Click += MenuHandler;
            // 
            // viewCredits
            // 
            viewCredits.Anchor = AnchorStyles.None;
            viewCredits.BackColor = Color.FromArgb(234, 234, 234);
            viewCredits.Cursor = Cursors.Hand;
            viewCredits.FlatAppearance.BorderSize = 2;
            viewCredits.FlatStyle = FlatStyle.Flat;
            viewCredits.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            viewCredits.Location = new Point(192, 249);
            viewCredits.Margin = new Padding(5);
            viewCredits.Name = "viewCredits";
            viewCredits.Size = new Size(100, 25);
            viewCredits.TabIndex = 15;
            viewCredits.TabStop = false;
            viewCredits.Text = "CREDITS";
            viewCredits.UseVisualStyleBackColor = false;
            viewCredits.Click += MenuHandler;
            // 
            // modeSelection
            // 
            modeSelection.Anchor = AnchorStyles.None;
            modeSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            modeSelection.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            modeSelection.FormattingEnabled = true;
            modeSelection.Items.AddRange(new object[] { "(CHOOSE MODE!)", "Player VS Player", "Player VS Easy AI", "Player VS Hard AI" });
            modeSelection.Location = new Point(163, 330);
            modeSelection.Name = "modeSelection";
            modeSelection.Size = new Size(160, 26);
            modeSelection.TabIndex = 16;
            modeSelection.TabStop = false;
            modeSelection.Tag = "";
            modeSelection.SelectedIndexChanged += SelectionsHandler;
            // 
            // goesFirst1
            // 
            goesFirst1.AutoSize = true;
            goesFirst1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            goesFirst1.Location = new Point(163, 362);
            goesFirst1.Name = "goesFirst1";
            goesFirst1.Size = new Size(14, 13);
            goesFirst1.TabIndex = 17;
            goesFirst1.TextAlign = ContentAlignment.MiddleCenter;
            goesFirst1.UseVisualStyleBackColor = true;
            goesFirst1.Visible = false;
            // 
            // goesFirst2
            // 
            goesFirst2.AutoSize = true;
            goesFirst2.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            goesFirst2.Location = new Point(163, 381);
            goesFirst2.Name = "goesFirst2";
            goesFirst2.Size = new Size(14, 13);
            goesFirst2.TabIndex = 18;
            goesFirst2.TextAlign = ContentAlignment.MiddleCenter;
            goesFirst2.UseVisualStyleBackColor = true;
            goesFirst2.Visible = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 64, 72);
            ClientSize = new Size(484, 461);
            Controls.Add(goesFirst2);
            Controls.Add(goesFirst1);
            Controls.Add(modeSelection);
            Controls.Add(viewCredits);
            Controls.Add(exitGame);
            Controls.Add(playGame);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainMenu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tic-tac-toe | Main Menu ⚙️";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button playGame;
        private Button exitGame;
        private Button viewCredits;
        private ComboBox modeSelection;
        private RadioButton goesFirst1;
        private RadioButton goesFirst2;
    }
}