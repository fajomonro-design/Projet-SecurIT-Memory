using System.Drawing;

namespace SecurIT_Memory
{
    public enum EtatCarte
    {
        Cachee,
        Revelee,
        Trouvee
    }

    public class Carte
    {
        public int ID { get; }
        public string Nom { get; }
        public Image ImageFace { get; }
        public EtatCarte Etat { get; set; }

        public Carte(int id, string nom, Image imageFace)
        {
            ID = id;
            Nom = nom;
            ImageFace = imageFace ?? throw new System.ArgumentNullException(nameof(imageFace));
            Etat = EtatCarte.Cachee;
        }
    }
}