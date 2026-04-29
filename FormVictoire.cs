using System;
using System.Drawing;
using System.Windows.Forms;

namespace SecurIT_Memory
{
    public class FormVictoire : Form
    {
        public FormVictoire(string nomGagnant, int scoreGagnant, int tempsEcoule)
        {
            Text = "Victoire !";
            Size = new Size(400, 300);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(34, 45, 62);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // CORRECTION : Ajout de "Height = 40" pour que la grosse police ne soit pas coupée
            Label lblFelicitation = new Label { 
                Text = "FIN DE LA PARTIE !", 
                ForeColor = Color.FromArgb(255, 215, 0), 
                Font = new Font("Segoe UI", 18F, FontStyle.Bold), 
                AutoSize = false, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(0, 30), 
                Width = 400, 
                Height = 40 
            };
            
            // CORRECTION : Ajout de "Height = 40" ici aussi
            Label lblVainqueur = new Label { 
                Text = $"🏆 Vainqueur : {nomGagnant} 🏆", 
                ForeColor = Color.White, 
                Font = new Font("Segoe UI", 16F, FontStyle.Bold), 
                AutoSize = false, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(0, 75), 
                Width = 400, 
                Height = 40 
            };
            
            Label lblDetails = new Label { 
                Text = $"Score : {scoreGagnant} paires\nTemps total : {tempsEcoule} secondes", 
                ForeColor = Color.LightGray, 
                Font = new Font("Segoe UI", 12F), 
                AutoSize = false, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(0, 130), 
                Width = 400, 
                Height = 60 
            };

            Button btnFermer = new Button { 
                Text = "Retour au Menu", 
                Font = new Font("Segoe UI", 12F), 
                Size = new Size(200, 45), 
                Location = new Point(100, 200), 
                BackColor = Color.FromArgb(72, 133, 237), 
                ForeColor = Color.White, 
                FlatStyle = FlatStyle.Flat 
            };
            btnFermer.FlatAppearance.BorderSize = 0;
            btnFermer.Click += (s, e) => this.Close();

            Controls.AddRange(new Control[] { lblFelicitation, lblVainqueur, lblDetails, btnFermer });
        }
    }
}
