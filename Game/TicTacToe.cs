using System.Windows.Forms;

namespace Game
{
    public partial class TicTacToe : Form
    {
        private readonly int? mode = MainMenu.Instance.ModeSelected.SelectedIndex;
        private readonly string goesFirst = MainMenu.Instance.GoesFirst;
        private bool currentTurn;
        private int xScore = 0;
        private int oScore = 0;

        public TicTacToe()
        {
            InitializeComponent();
            ResetGame();
        }

        private void ResetGame()
        {
            foreach (Control control in Controls)
            {
                if (control is Button slot && slot.Name.StartsWith("slot"))
                {
                    slot.ResetText();
                    slot.BackColor = Color.White;
                    slot.Enabled = true;
                }
            }

            switch (mode)
            {
                case 0:
                    SetInitialTurn(goesFirst == "Player 1", "Player 1 (X)", "Player 2 (X)");
                    break;
                case 1:
                case 2:
                    if (goesFirst == "AI")
                    {
                        if (mode == 1) MarkSlotEasyAI();
                        else MarkSlotHardAI();
                    }
                    displayTurn.Text = "VERSUS\nAI";
                    displayScore.Text = $"SCORE\nP {xScore} | {oScore} AI";
                    break;
                default:
                    break;
            }
        }

        private void SetInitialTurn(bool isFirstPlayer, string playerOneTurnText, string playerTwoTurnText)
        {
            if (isFirstPlayer)
            {
                displayTurn.Text = $"TURN\n{playerOneTurnText}";
                currentTurn = true;
            }
            else
            {
                displayTurn.Text = $"TURN\n{playerTwoTurnText}";
                currentTurn = false;
            }
            displayScore.Text = $"SCORE\nP1 {xScore} | {oScore} P2";
        }

        private void MarkSlotHandler(object sender, EventArgs e)
        {
            if (sender is Button slot)
            {
                switch (mode)
                {
                    case 0:
                        MarkSlotPlayers(slot);
                        HandleGameResult(CheckForWinner());
                        break;
                    case 2:
                        slot.Text = "X";
                        slot.Enabled = false;
                        MarkSlotHardAI();
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleGameResult(int result)
        {
            DialogResult dialogResult;
            switch (result)
            {
                case 1:
                    dialogResult = MessageBox.Show("Winner: Player 1. New game?", "Game Over", MessageBoxButtons.YesNoCancel);
                    HandleDialogResult(dialogResult);
                    break;
                case 2:
                    dialogResult = MessageBox.Show("Winner: Player 2. New game?", "Game Over", MessageBoxButtons.YesNoCancel);
                    HandleDialogResult(dialogResult);
                    break;
                case 3:
                    dialogResult = MessageBox.Show("It's a draw. New game?", "Draw", MessageBoxButtons.YesNoCancel);
                    HandleDialogResult(dialogResult);
                    break;
            }
        }

        private void HandleDialogResult(DialogResult result)
        {
            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
            else if (result == DialogResult.No)
            {
                ReturnToMainMenu(this, EventArgs.Empty);
            }
            else if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private int CheckForWinner()
        {
            Button[,] slots = { { slot1, slot4, slot7 }, { slot2, slot5, slot8 }, { slot3, slot6, slot9 } };
            int winner = 0, openSlots = 0;

            for (int i = 0; i < 3; i++)
            {
                if (AllEqual(slots[i, 0].Text, slots[i, 1].Text, slots[i, 2].Text))
                {
                    winner = slots[i, 0].Text == "X" ? 1 : 2;
                }
                if (AllEqual(slots[0, i].Text, slots[1, i].Text, slots[2, i].Text))
                {
                    winner = slots[0, i].Text == "X" ? 1 : 2;
                }
            }

            if (AllEqual(slots[0, 0].Text, slots[1, 1].Text, slots[2, 2].Text))
            {
                winner = slots[0, 0].Text == "X" ? 1 : 2;
            }
            else if (AllEqual(slots[2, 0].Text, slots[1, 1].Text, slots[0, 2].Text))
            {
                winner = slots[2, 0].Text == "X" ? 1 : 2;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(slots[i, j].Text))
                    {
                        openSlots++;
                    }
                }
            }

            return (winner == 0 && openSlots == 0) ? 3 : winner;
        }

        private static bool AllEqual(string a, string b, string c)
        {
            return a == b && b == c && !string.IsNullOrEmpty(a);
        }

        private void MarkSlotPlayers(Button slot)
        {
            slot.Text = currentTurn ? "X" : "O";
            slot.Enabled = false;
            displayTurn.Text = currentTurn ? "TURN\nPlayer 2 (O)" : "TURN\nPlayer 1 (X)";
            currentTurn = !currentTurn;
        }

        private void ReturnToMainMenu(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Return to main menu?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MainMenu mainMenu = new();
                Hide();
                mainMenu.ShowDialog();
            }
        }

        private void ApplicationExit(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MarkSlotHardAI()
        {
            Button[] slots = { slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9 };
            int bestScore = int.MinValue;
            int markSlot = 0;

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].Text == "")
                {
                    slots[i].Text = "O";
                    int score = Minimax(false);
                    slots[i].ResetText();
                    if (score > bestScore)
                    {
                        bestScore = score;
                        markSlot = i;
                    }
                }
            }

            slots[markSlot].Enabled = false;
            slots[markSlot].Text = "O";
            HandleGameResult(CheckForWinner());
        }

        private int Minimax(bool isMaximizing)
        {
            Button[] slots = { slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9 };
            int result = CheckForWinner();
            if (result != 0)
            {
                return result;
            }

            if (isMaximizing)
            {
                int maxScore = int.MinValue;
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].Text == "")
                    {
                        slots[i].Text = "O";
                        int score = Minimax(false);
                        slots[i].ResetText();
                        maxScore = Math.Max(score, maxScore);
                    }
                }
                return maxScore;
            }
            else
            {
                int minScore = int.MaxValue;
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].Text == "")
                    {
                        slots[i].Text = "X";
                        int score = Minimax(true);
                        slots[i].ResetText();
                        minScore = Math.Min(score, minScore);
                    }
                }
                return minScore;
            }
        }

        private void MarkSlotEasyAI()
        {
            Button[] slots = { slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9 };

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].Text == "")
                {
                    slots[i].Text = "O";
                    slots[i].Enabled = false;
                    break;
                }
            }
            HandleGameResult(CheckForWinner());
        }
    }
}
