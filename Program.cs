using System;
using System.Windows.Forms;

namespace SecurIT_Memory
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // On lance maintenant FormMenu au démarrage !
            Application.Run(new FormMenu()); 
        }
    }
}