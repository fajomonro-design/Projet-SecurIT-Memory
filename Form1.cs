using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SecurIT_Memory
{
    public partial class FormJeu : Form
    {
        private readonly JeuMemory jeu;
        private readonly System.Windows.Forms.Timer timerRetour;
        private readonly System.Windows.Forms.Timer chronoJeu;
        private PictureBox premiereSelection;
        private PictureBox deuxiemeSelection;
        private bool attenteRetournement;
        private Image dosCarteImage;
        private int tempsEcoule;
        
        // Variables transmises par le menu
        private int tailleGrille;
        private Theme themeJeu;
        private string nomJ1;
        private string nomJ2;
        private int scoreJ1 = 0;
        private int scoreJ2 = 0;
        private bool tourJoueur1 = true;

        // UI
        private Panel panelStatus;
        private Label lblChrono;
        private Label lblScoreJ1;
        private Label lblScoreJ2;
        private TableLayoutPanel grilleTable;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public FormJeu(string joueur1, string joueur2, int taille, Theme theme)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            nomJ1 = joueur1;
            nomJ2 = joueur2;
            tailleGrille = taille;
            themeJeu = theme;

            jeu = new JeuMemory();
            timerRetour = new System.Windows.Forms.Timer { Interval = 1500 };
            chronoJeu = new System.Windows.Forms.Timer { Interval = 1000 };

            InitializeComponentUI();
            
            // CORRECTION ICI : Appel simple sans paramètre invalide
            InitialiserTimers(); 
            
            CreerImagesDos();
            DemarrerPartie();
        }

        private void InitializeComponentUI()
        {
            Text = "Memory SecurIT - En Jeu";
            ClientSize = new Size(980, 700);
            BackColor = Color.FromArgb(245, 245, 245);
            StartPosition = FormStartPosition.CenterScreen;

            panelStatus = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.FromArgb(34, 45, 62) };
            
            lblChrono = new Label { Text = "Temps : 0 s", ForeColor = Color.White, Font = new Font("Segoe UI", 12F, FontStyle.Bold), Location = new Point(20, 25), AutoSize = true };
            lblScoreJ1 = new Label { Text = $"{nomJ1} : 0", ForeColor = Color.White, Font = new Font("Segoe UI", 16F, FontStyle.Bold), Location = new Point(200, 25), AutoSize = true };
            lblScoreJ2 = new Label { Text = $"{nomJ2} : 0", ForeColor = Color.Gray, Font = new Font("Segoe UI", 16F, FontStyle.Bold), Location = new Point(500, 25), AutoSize = true };

            panelStatus.Controls.AddRange(new Control[] { lblChrono, lblScoreJ1, lblScoreJ2 });
            Controls.Add(panelStatus);

            grilleTable = new TableLayoutPanel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Padding = new Padding(20) };
            Controls.Add(grilleTable);
            grilleTable.BringToFront(); 
        }

        private void DemarrerPartie()
        {
            jeu.Initialiser(tailleGrille, tailleGrille, themeJeu);
            scoreJ1 = 0;
            scoreJ2 = 0;
            tempsEcoule = 0;
            GenererGrille();
            UpdateLabels();
            chronoJeu.Start();
        }

        private void GenererGrille()
        {
            grilleTable.Controls.Clear(); grilleTable.ColumnStyles.Clear(); grilleTable.RowStyles.Clear();
            grilleTable.ColumnCount = tailleGrille; grilleTable.RowCount = tailleGrille;

            for (int c = 0; c < tailleGrille; c++) grilleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / tailleGrille));
            for (int r = 0; r < tailleGrille; r++) grilleTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / tailleGrille));

            int index = 0;
            foreach (var carte in jeu.Cartes)
            {
                var pictureBox = new PictureBox { Dock = DockStyle.Fill, Margin = new Padding(8), SizeMode = PictureBoxSizeMode.Zoom, Cursor = Cursors.Hand, Tag = carte, Image = dosCarteImage };
                pictureBox.Click += Carte_Click;
                grilleTable.Controls.Add(pictureBox, index % tailleGrille, index / tailleGrille);
                index++;
            }
        }

        // CORRECTION ICI : La méthode GetV a été supprimée et InitialiserTimers est réparée.
        private void InitialiserTimers()
        {
            timerRetour.Tick += TimerRetour_Tick;
            chronoJeu.Tick += ChronoJeu_Tick;
        }

        private void CreerImagesDos()
        {
            const int taille = 140;
            var bitmap = new Bitmap(taille, taille);
            using var g = Graphics.FromImage(bitmap);
            g.Clear(Color.FromArgb(48, 55, 84));
            g.DrawString("SECURIT", new Font("Segoe UI", 12F, FontStyle.Bold), Brushes.White, new RectangleF(0, 0, taille, taille), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            dosCarteImage = bitmap;
        }

        private void Carte_Click(object sender, EventArgs e)
        {
            if (attenteRetournement || sender is not PictureBox pictureBox || pictureBox.Tag is not Carte carte || carte.Etat != EtatCarte.Cachee) return;

            carte.Etat = EtatCarte.Revelee;
            pictureBox.Image = carte.ImageFace;

            if (premiereSelection == null) { premiereSelection = pictureBox; return; }
            if (pictureBox == premiereSelection) return;

            deuxiemeSelection = pictureBox;
            bool paire = jeu.VerifierPaire((Carte)premiereSelection.Tag, (Carte)deuxiemeSelection.Tag);

            if (paire)
            {
                if (tourJoueur1) scoreJ1++; else scoreJ2++;
                ((Carte)premiereSelection.Tag).Etat = EtatCarte.Trouvee;
                ((Carte)deuxiemeSelection.Tag).Etat = EtatCarte.Trouvee;
                premiereSelection = null; deuxiemeSelection = null;

                UpdateLabels();

                if (jeu.EstTermine)
                {
                    chronoJeu.Stop();
                    string gagnant = scoreJ1 == scoreJ2 ? "Égalité !" : (scoreJ1 > scoreJ2 ? nomJ1 : nomJ2);
                    int scoreGagnant = Math.Max(scoreJ1, scoreJ2);
                    
                    // Affiche le nouveau menu de victoire !
                    FormVictoire fv = new FormVictoire(gagnant, scoreGagnant, tempsEcoule);
                    fv.ShowDialog(); // Bloque la fenêtre de jeu tant que la victoire est affichée
                    this.Close(); // Ferme le jeu pour revenir au menu principal
                }
            }
            else
            {
                tourJoueur1 = !tourJoueur1;
                UpdateLabels();
                attenteRetournement = true;
                timerRetour.Start();
            }
        }

        private void TimerRetour_Tick(object sender, EventArgs e)
        {
            timerRetour.Stop();
            if (premiereSelection != null && deuxiemeSelection != null)
            {
                ((Carte)premiereSelection.Tag).Etat = EtatCarte.Cachee;
                ((Carte)deuxiemeSelection.Tag).Etat = EtatCarte.Cachee;
                premiereSelection.Image = dosCarteImage;
                deuxiemeSelection.Image = dosCarteImage;
            }
            premiereSelection = null; deuxiemeSelection = null;
            attenteRetournement = false;
        }

        private void ChronoJeu_Tick(object sender, EventArgs e)
        {
            tempsEcoule++;
            lblChrono.Text = $"Temps : {tempsEcoule} s";
        }

        private void UpdateLabels()
        {
            lblScoreJ1.Text = $"{nomJ1} : {scoreJ1}";
            lblScoreJ2.Text = $"{nomJ2} : {scoreJ2}";
            lblScoreJ1.ForeColor = tourJoueur1 ? Color.Yellow : Color.Gray;
            lblScoreJ2.ForeColor = !tourJoueur1 ? Color.Yellow : Color.Gray;
        }
    }
}
