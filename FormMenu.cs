using System;
using System.Drawing;
using System.Windows.Forms;

namespace SecurIT_Memory
{
    public class FormMenu : Form
    {
        private TextBox txtJoueur1;
        private TextBox txtJoueur2;
        private ComboBox comboGrille;
        private ComboBox comboTheme;
        private Button btnLancer;

        public FormMenu()
        {
            InitializeComponentUI();
        }

        private void InitializeComponentUI()
        {
            Text = "SecurIT Memory - Menu Principal";
            Size = new Size(500, 480); // Fenêtre légèrement rétrécie car on a enlevé le titre
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(20, 48, 77); // Bleu nuit
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // Titre SÉCURIT MEMORY complètement supprimé

            // Configuration Joueurs (remontée vers le haut)
            Label lblJ1 = new Label { Text = "Nom du Joueur 1 :", ForeColor = Color.White, Font = new Font("Segoe UI", 12F), Location = new Point(100, 40), AutoSize = true };
            txtJoueur1 = new TextBox { Text = "Joueur 1", Location = new Point(100, 70), Width = 280, Font = new Font("Segoe UI", 12F) };

            Label lblJ2 = new Label { Text = "Nom du Joueur 2 :", ForeColor = Color.White, Font = new Font("Segoe UI", 12F), Location = new Point(100, 120), AutoSize = true };
            txtJoueur2 = new TextBox { Text = "Joueur 2", Location = new Point(100, 150), Width = 280, Font = new Font("Segoe UI", 12F) };

            // Options de Jeu
            Label lblGrille = new Label { Text = "Taille de la Grille :", ForeColor = Color.White, Font = new Font("Segoe UI", 12F), Location = new Point(100, 200), AutoSize = true };
            comboGrille = new ComboBox { Location = new Point(100, 230), Width = 280, Font = new Font("Segoe UI", 12F), DropDownStyle = ComboBoxStyle.DropDownList };
            comboGrille.Items.AddRange(new object[] { "Classique (4x4)", "Expert (6x6)" });
            comboGrille.SelectedIndex = 0;

            // NOUVEAUX THÈMES : Jojo et +18
            Label lblTheme = new Label { Text = "Thème :", ForeColor = Color.White, Font = new Font("Segoe UI", 12F), Location = new Point(100, 280), AutoSize = true };
            comboTheme = new ComboBox { Location = new Point(100, 310), Width = 280, Font = new Font("Segoe UI", 12F), DropDownStyle = ComboBoxStyle.DropDownList };
            comboTheme.Items.AddRange(new object[] { "Jojo", "+18" });
            comboTheme.SelectedIndex = 0;

            // Boutons
            btnLancer = new Button { Text = "LANCER LA PARTIE", Font = new Font("Segoe UI", 12F, FontStyle.Bold), Size = new Size(280, 50), Location = new Point(100, 370), BackColor = Color.FromArgb(72, 133, 237), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLancer.FlatAppearance.BorderSize = 0;
            btnLancer.Click += BtnLancer_Click;

            Controls.AddRange(new Control[] { lblJ1, txtJoueur1, lblJ2, txtJoueur2, lblGrille, comboGrille, lblTheme, comboTheme, btnLancer });
        }

        private void BtnLancer_Click(object sender, EventArgs e)
        {
            this.Hide(); 

            int taille = comboGrille.SelectedIndex == 1 ? 6 : 4;
            Theme themeChoisi = (Theme)comboTheme.SelectedIndex;

            FormJeu fenetreJeu = new FormJeu(txtJoueur1.Text, txtJoueur2.Text, taille, themeChoisi);
            fenetreJeu.FormClosed += (s, args) => this.Show(); 
            fenetreJeu.Show();
        }
    }
}