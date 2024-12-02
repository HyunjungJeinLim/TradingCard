using System.Windows.Forms;
using System.Xml.Linq;

namespace TradingCard
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.ComboBox cmbTeams;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Draws a custom border for the panel based on the selected player's team.
        /// </summary>


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Get the currently selected player
            var selectedPlayer = players.FirstOrDefault(p => p.Name == listBox1.SelectedItem?.ToString());
            if (selectedPlayer != null)
            {
                // Default colors
                Color borderColor = Color.Black;
                Color backgroundColor = Color.White;
                Color teamTextColor = Color.Black;

                // Set colors based on the player's team
                if (selectedPlayer.Team.Contains("Blue Jays"))
                {
                    borderColor = Color.RoyalBlue;
                    backgroundColor = Color.LightBlue;
                    teamTextColor = Color.RoyalBlue;
                }
                else if (selectedPlayer.Team.Contains("Padres"))
                {
                    borderColor = Color.SaddleBrown;
                    backgroundColor = Color.BurlyWood;
                    teamTextColor = Color.SaddleBrown;
                }
                else if (selectedPlayer.Team.Contains("Pirates"))
                {
                    borderColor = Color.Gold;
                    backgroundColor = Color.LightYellow;
                    teamTextColor = Color.Gold;
                }

                // Update panel background color
                panel1.BackColor = backgroundColor;

                // Update team label color
                lblTeam.ForeColor = teamTextColor;

                // Draw the border
                using (Pen pen = new Pen(borderColor, 4))
                {
                    e.Graphics.DrawRectangle(pen, panel1.Location.X - 2, panel1.Location.Y - 2, panel1.Width + 4, panel1.Height + 4);
                }
            }
        }


        /// <summary>
        /// Initializes the components of the form.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblName = new Label();
            lblTeam = new Label();
            lblStats = new Label();
            cmbTeams = new ComboBox();
            lblComboBox = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(20, 20);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(200, 379);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(lblTeam);
            panel1.Controls.Add(lblStats);
            panel1.Location = new Point(240, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(320, 453);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            lblName.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(10, 220);
            lblName.Name = "lblName";
            lblName.Size = new Size(300, 35);
            lblName.TabIndex = 1;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTeam
            // 
            lblTeam.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTeam.ForeColor = Color.DarkBlue;
            lblTeam.Location = new Point(10, 260);
            lblTeam.Name = "lblTeam";
            lblTeam.Size = new Size(300, 30);
            lblTeam.TabIndex = 2;
            lblTeam.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStats
            // 
            lblStats.Font = new Font("Arial", 11F);
            lblStats.ForeColor = Color.Black;
            lblStats.Location = new Point(10, 300);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(300, 120);
            lblStats.TabIndex = 3;
            lblStats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbTeams
            // 
            cmbTeams.Location = new Point(20, 448);
            cmbTeams.Name = "cmbTeams";
            cmbTeams.Size = new Size(200, 33);
            cmbTeams.TabIndex = 3;
            cmbTeams.SelectedIndexChanged += cmbTeams_SelectedIndexChanged;
            // 
            // lblComboBox
            // 
            lblComboBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblComboBox.Location = new Point(20, 418);
            lblComboBox.Name = "lblComboBox";
            lblComboBox.Size = new Size(100, 23);
            lblComboBox.TabIndex = 2;
            lblComboBox.Text = "Select a Team:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(237, 497);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 39);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(347, 497);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 39);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(457, 497);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 39);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(600, 558);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(lblComboBox);
            Controls.Add(cmbTeams);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}
