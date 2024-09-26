using System.Windows.Forms;

namespace Game
{
    public partial class MainMenu : Form
    {
        private static MainMenu? _instance;
        public static MainMenu Instance => _instance ??= new MainMenu();

        public ComboBox ModeSelected { get; internal set; }
        public string GoesFirst { get; internal set; } = string.Empty;

        public MainMenu()
        {
            InitializeComponent();
            _instance = this;

            ModeSelected = modeSelection;
            ModeSelected.SelectedIndexChanged += SelectionsHandler;

            goesFirst1.Visible = false;
            goesFirst2.Visible = false;
        }

        private void MenuHandler(object sender, EventArgs e)
        {
            if (sender == playGame)
            {
                if (ModeSelected?.SelectedItem?.ToString() == "(CHOOSE MODE!)")
                {
                    MessageBox.Show("You need to select a mode before you can play.", "Mode not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!goesFirst1.Checked && !goesFirst2.Checked)
                {
                    MessageBox.Show("You need to choose who goes first before playing.", "Who goes first not chosen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    GoesFirst = goesFirst1.Checked ? goesFirst1.Text : goesFirst2.Text;
                    var ticTacToe = new TicTacToe();
                    Hide();
                    ticTacToe.ShowDialog();
                }
            }
            else if (sender == exitGame)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Aleksandar Haralanov", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SelectionsHandler(object? sender, EventArgs? e)
        {
            if (ModeSelected.SelectedIndex != 0)
            {
                if (ModeSelected.Items.Contains("(CHOOSE MODE!)"))
                {
                    ModeSelected.Items.RemoveAt(0);
                }
            }

            switch (ModeSelected.SelectedIndex)
            {
                case 0:
                    goesFirst1.Text = "Player 1";
                    goesFirst2.Text = "Player 2";
                    goesFirst1.Visible = true;
                    goesFirst2.Visible = true;
                    break;
                case 1:
                case 2:
                    goesFirst1.Text = "Player";
                    goesFirst2.Text = "AI";
                    goesFirst1.Visible = true;
                    goesFirst2.Visible = true;
                    break;
                default:
                    goesFirst1.Visible = false;
                    goesFirst2.Visible = false;
                    break;
            }
        }

    }
}
