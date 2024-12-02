using System.Windows.Forms;
using TradingCard;

namespace TradingCard
{
    public partial class Form1 : Form
    {
        private List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
            LoadPlayers();
            PopulateComboBox();
        }

        private void LoadPlayers()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFolderPath = Path.Combine(baseDirectory, "Source");

            players = new List<Player>
            {
                new Player("Hyun Jin Ryu", "Toronto Blue Jays", Path.Combine(imageFolderPath, "RYU.jpg"), 30, 0, 5, 0.000),
                new Player("Vladimir Guerrero Jr.", "Toronto Blue Jays", Path.Combine(imageFolderPath, "GUERRERO.jpg"), 160, 32, 97, 0.274),
                new Player("Bo Bichette", "Toronto Blue Jays", Path.Combine(imageFolderPath, "BICHETTE.jpg"), 159, 24, 93, 0.298),
                new Player("George Springer", "Toronto Blue Jays", Path.Combine(imageFolderPath, "SPRINGER.jpg"), 140, 22, 75, 0.275),
                new Player("Ha-seong Kim", "San Diego Padres", Path.Combine(imageFolderPath, "KIM.jpg"), 150, 17, 60, 0.260),
                new Player("Manny Machado", "San Diego Padres", Path.Combine(imageFolderPath, "MACHADO.jpg"), 139, 25, 90, 0.278),
                new Player("Juan Soto", "San Diego Padres", Path.Combine(imageFolderPath, "SOTO.jpg"), 151, 35, 109, 0.280),
                new Player("Ji-man Choi", "Pittsburgh Pirates", Path.Combine(imageFolderPath, "CHOI.jpg"), 80, 10, 35, 0.225),
                new Player("Bryan Reynolds", "Pittsburgh Pirates", Path.Combine(imageFolderPath, "REYNOLDS.jpg"), 145, 25, 80, 0.271),
                new Player("Ke'Bryan Hayes", "Pittsburgh Pirates", Path.Combine(imageFolderPath, "HAYES.jpg"), 130, 15, 65, 0.268)
            };

            listBox1.DataSource = players.Select(p => p.Name).ToList();
        }

        private void PopulateComboBox()
        {
            cmbTeams.Items.Add("All Teams");
            cmbTeams.Items.AddRange(players.Select(p => p.Team).Distinct().ToArray());
            cmbTeams.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            var selectedPlayer = players.FirstOrDefault(p => p.Name == listBox1.SelectedItem.ToString());
            if (selectedPlayer != null)
            {
                lblName.Text = $"{selectedPlayer.Name}";
                lblTeam.Text = $"Team: {selectedPlayer.Team}";
                lblStats.Text = $"Games Played: {selectedPlayer.GamesPlayed}\n" +
                                $"Home Runs: {selectedPlayer.HomeRuns}\n" +
                                $"RBIs: {selectedPlayer.RBIs}\n" +
                                $"Batting Average: {selectedPlayer.BattingAverage:F3}";

                pictureBox1.ImageLocation = selectedPlayer.PhotoUrl;

                // team color
                if (selectedPlayer.Team.Contains("Blue Jays"))
                {
                    panel1.BackColor = Color.LightBlue;
                }
                else if (selectedPlayer.Team.Contains("Padres"))
                {
                    panel1.BackColor = Color.LightGoldenrodYellow;
                }
                else if (selectedPlayer.Team.Contains("Pirates"))
                {
                    panel1.BackColor = Color.LightGray;
                }
                else
                {
                    panel1.BackColor = Color.White;
                }

                Invalidate();
            }
        }


        private void cmbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTeam = cmbTeams.SelectedItem.ToString();

            if (selectedTeam == "All Teams")
            {
                listBox1.DataSource = players.Select(p => p.Name).ToList();
            }
            else
            {
                listBox1.DataSource = players
                    .Where(p => p.Team == selectedTeam)
                    .Select(p => p.Name)
                    .ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] labels = { "Enter Name:", "Enter Team:", "Enter Games Played:", "Enter Home Runs:", "Enter RBIs:", "Enter Batting Average:", "Enter Photo Path:" };
            string[] defaultValues = { "", "", "0", "0", "0", "0.000", "source/default.jpg" };
            string[] inputs = Prompt.ShowDialog(labels, "Add Player", defaultValues);

            if (inputs.Length == labels.Length)
            {
                var newPlayer = new Player(
                    inputs[0],
                    inputs[1],
                    inputs[6], // Photo path
                    int.Parse(inputs[2]),
                    int.Parse(inputs[3]),
                    int.Parse(inputs[4]),
                    double.Parse(inputs[5])
                );
                players.Add(newPlayer);

                listBox1.DataSource = players.Select(p => p.Name).ToList();
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a player to update.");
                return;
            }

            var selectedPlayer = players.FirstOrDefault(p => p.Name == listBox1.SelectedItem.ToString());
            if (selectedPlayer != null)
            {
                string[] labels = { "Update Name:", "Update Team:", "Update Games Played:", "Update Home Runs:", "Update RBIs:", "Update Batting Average:", "Update Photo Path:" };
                string[] defaultValues = {
                    selectedPlayer.Name,
                    selectedPlayer.Team,
                    selectedPlayer.GamesPlayed.ToString(),
                    selectedPlayer.HomeRuns.ToString(),
                    selectedPlayer.RBIs.ToString(),
                    selectedPlayer.BattingAverage.ToString("F3"),
                    selectedPlayer.PhotoUrl 
            };
                string[] inputs = Prompt.ShowDialog(labels, "Update Player", defaultValues);

                if (inputs.Length == labels.Length)
                {
                    selectedPlayer.Name = inputs[0];
                    selectedPlayer.Team = inputs[1];
                    selectedPlayer.GamesPlayed = int.Parse(inputs[2]);
                    selectedPlayer.HomeRuns = int.Parse(inputs[3]);
                    selectedPlayer.RBIs = int.Parse(inputs[4]);
                    selectedPlayer.BattingAverage = double.Parse(inputs[5]);
                    selectedPlayer.PhotoUrl = inputs[6]; 

                    listBox1.DataSource = players.Select(p => p.Name).ToList();
                }

            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a player to delete.");
                return;
            }

            var selectedPlayer = players.FirstOrDefault(p => p.Name == listBox1.SelectedItem.ToString());
            if (selectedPlayer != null)
            {
                var confirmResult = MessageBox.Show($"Are you sure to delete {selectedPlayer.Name}?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    players.Remove(selectedPlayer);

                    listBox1.DataSource = players.Select(p => p.Name).ToList();
                }
            }
        }
    }
}
