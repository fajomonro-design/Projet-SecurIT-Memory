using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SecurIT_Memory
{
    // Il ne reste plus que le thème Jojo
    public enum Theme
    {
        Jojo
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

            var images = CreerJeuDImages(PairesTotal);
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

        private static List<(string nom, Image image)> CreerJeuDImages(int paires)
        {
            // On charge directement le thème Jojo
            var source = CreerDefinitionsJojo();

            if (paires > source.Count)
            {
                throw new InvalidOperationException($"Pas assez d'images pour le thème. Il faut {paires} images uniques.");
            }

            return source.Take(paires)
                         .Select(info => (info.nom, ChargerImage(info.fichier)))
                         .ToList();
        }

        // --- THÈME JOJO (18 images en JPG nécessaires pour la grille 6x6) ---
        private static IReadOnlyList<(string nom, string fichier)> CreerDefinitionsJojo()
        {
            return new[]
            {
                ("Jojo 1", "jojo1.jpg"), ("Jojo 2", "jojo2.jpg"), ("Jojo 3", "jojo3.jpg"),
                ("Jojo 4", "jojo4.jpg"), ("Jojo 5", "jojo5.jpg"), ("Jojo 6", "jojo6.jpg"),
                ("Jojo 7", "jojo7.jpg"), ("Jojo 8", "jojo8.jpg"), ("Jojo 9", "jojo9.jpg"),
                ("Jojo 10", "jojo10.jpg"), ("Jojo 11", "jojo11.jpg"), ("Jojo 12", "jojo12.jpg"),
                ("Jojo 13", "jojo13.jpg"), ("Jojo 14", "jojo14.jpg"), ("Jojo 15", "jojo15.jpg"),
                ("Jojo 16", "jojo16.jpg"), ("Jojo 17", "jojo17.jpg"), ("Jojo 18", "jojo18.jpg")
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
                // Si l'image n'est pas trouvée, on affiche un carré d'erreur
                var bitmap = new Bitmap(140, 140);
                using var g = Graphics.FromImage(bitmap);
                g.Clear(Color.DarkRed);
                g.DrawString($"Manquant:\n{nomFichier}", new Font("Arial", 8), Brushes.White, new RectangleF(0, 50, 140, 40), new StringFormat { Alignment = StringAlignment.Center });
                return bitmap;
            }
        }
    }
}
