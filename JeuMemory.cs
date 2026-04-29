using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SecurIT_Memory
{
    // On met à jour l'énumération avec tes nouveaux thèmes
    public enum Theme
    {
        Jojo,
        Plus18
    }

    public class JeuMemory
    {
        private static readonly Random Randomizer = new();

        public List<Carte> Cartes { get; private set; } = new();
        public int PairesTotal { get; private set; }
        public int Essais { get; private set; }
        public int PairesTrouvees { get; private set; }
        public int Lignes { get; private set; }
        public int Colonnes { get; private set; }
        public Theme ThemeSelectionne { get; private set; }

        public bool EstTermine => PairesTrouvees >= PairesTotal;

        public void Initialiser(int lignes, int colonnes, Theme theme)
        {
            Lignes = lignes;
            Colonnes = colonnes;
            ThemeSelectionne = theme;
            Essais = 0;
            PairesTrouvees = 0;
            PairesTotal = (lignes * colonnes) / 2;

            var images = CreerJeuDImages(theme, PairesTotal);
            Cartes = new List<Carte>(PairesTotal * 2);

            for (var id = 0; id < PairesTotal; id++)
            {
                var item = images[id];
                Cartes.Add(new Carte(id, item.nom, item.image));
                Cartes.Add(new Carte(id, item.nom, item.image));
            }

            Cartes = Cartes.OrderBy(_ => Randomizer.Next()).ToList();
        }

        public void EnregistrerEssai() => Essais++;

        public bool VerifierPaire(Carte carte1, Carte carte2)
        {
            EnregistrerEssai();
            if (carte1.ID != carte2.ID) return false;
            
            PairesTrouvees++;
            return true;
        }

        private static List<(string nom, Image image)> CreerJeuDImages(Theme theme, int paires)
        {
            var source = theme switch
            {
                Theme.Plus18 => CreerDefinitionsPlus18(),
                _ => CreerDefinitionsJojo()
            };

            if (paires > source.Count)
            {
                throw new InvalidOperationException($"Pas assez d'images pour le thème. Il faut {paires} images uniques.");
            }

            return source.Take(paires)
                         .Select(info => (info.nom, ChargerImage(info.fichier)))
                         .ToList();
        }

        // --- THÈME JOJO (18 images nécessaires pour la grille 6x6) ---
        private static IReadOnlyList<(string nom, string fichier)> CreerDefinitionsJojo()
        {
            return new[]
            {
                ("Jojo 1", "jojo1.png"), ("Jojo 2", "jojo2.png"), ("Jojo 3", "jojo3.png"),
                ("Jojo 4", "jojo4.png"), ("Jojo 5", "jojo5.png"), ("Jojo 6", "jojo6.png"),
                ("Jojo 7", "jojo7.png"), ("Jojo 8", "jojo8.png"), ("Jojo 9", "jojo9.png"),
                ("Jojo 10", "jojo10.png"), ("Jojo 11", "jojo11.png"), ("Jojo 12", "jojo12.png"),
                ("Jojo 13", "jojo13.png"), ("Jojo 14", "jojo14.png"), ("Jojo 15", "jojo15.png"),
                ("Jojo 16", "jojo16.png"), ("Jojo 17", "jojo17.png"), ("Jojo 18", "jojo18.png")
            };
        }

        // --- THÈME +18 (18 images nécessaires pour la grille 6x6) ---
        private static IReadOnlyList<(string nom, string fichier)> CreerDefinitionsPlus18()
        {
            return new[]
            {
                ("Image 1", "18_1.png"), ("Image 2", "18_2.png"), ("Image 3", "18_3.png"),
                ("Image 4", "18_4.png"), ("Image 5", "18_5.png"), ("Image 6", "18_6.png"),
                ("Image 7", "18_7.png"), ("Image 8", "18_8.png"), ("Image 9", "18_9.png"),
                ("Image 10", "18_10.png"), ("Image 11", "18_11.png"), ("Image 12", "18_12.png"),
                ("Image 13", "18_13.png"), ("Image 14", "18_14.png"), ("Image 15", "18_15.png"),
                ("Image 16", "18_16.png"), ("Image 17", "18_17.png"), ("Image 18", "18_18.png")
            };
        }

        private static Image ChargerImage(string nomFichier)
        {
            string chemin = Path.Combine("Images", nomFichier);
            try
            {
                return Image.FromFile(chemin);
            }
            catch
            {
                // Si l'image n'est pas trouvée dans ton dossier, on affiche un carré d'erreur
                var bitmap = new Bitmap(140, 140);
                using var g = Graphics.FromImage(bitmap);
                g.Clear(Color.DarkRed);
                g.DrawString($"Manquant:\n{nomFichier}", new Font("Arial", 8), Brushes.White, new RectangleF(0, 50, 140, 40), new StringFormat { Alignment = StringAlignment.Center });
                return bitmap;
            }
        }
    }
}