using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Administrateur
    {
        
        /// <summary>
        /// Reactivate client's account
        /// </summary>
        public string ResetState() => Etat.ACTIVE.ToString();

        public void RemettreGuichet()
        {
            if (ResetState().Equals("DEACTIVE"))
            {
                Console.WriteLine("Entrer votre nom");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrer votre nip");
                string nip = Console.ReadLine();

            }
        }

        public void DeposerArgent() { }

        public void VoirSolde() { }

        public void afficherListClient()
        {
            foreach(Client c in Guichet.clients)
            {
                Console.WriteLine(value: $"\tNom: {c.Nom}, CompteEpargne: {c.CompteEpargne}, CompteCheck: {c.CompteCheck}, Etat: {c.Etat}");
            }


        }

        public void MainMenu() { }


    }
}
