using System;

namespace Minesweeper
{
    class Program
    {
        static void Grille (int nbrLignes, int nbrColonnes, int nbrMines)
        {

        }

        static void Main(string[] args)
        {
            string choix;
            char restart;

            do
            {
                Console.Clear();
                Console.WriteLine("Minesweeper \n Menu :\n Débutant : 56 Champs & 10 Mines - 1 \n Intermédiaire : 256 Champs & 40 Mines - 2 \n Expert : 496 Champs & 99 Mines - 3 \n Personnalisé : x Champs & x Mines - 4");
                choix = Console.ReadLine();

                if (choix == "1")
                {
                

                }

                else if (choix == "2")
                {

                }

                else if (choix == "3")
                {

                }

                else if (choix == "4")
                {

                }

                Console.WriteLine("Voulez-vous recommencer ?");
                Console.WriteLine("Oui - 1 \nNon - 2");
                restart = char.Parse(Console.ReadLine());

            } while (restart == '1');

        }
    }
}
