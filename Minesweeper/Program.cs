using System;

namespace Minesweeper
{
    class Program
    {
        static void Show(int[,] tab2D)
        {
            for (int i = 0; i < tab2D.GetLength(0); i++)
            {
                for (int j = 0; j < tab2D.GetLength(1); j++)
                {
                    Console.Write(tab2D[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void ChoixLevel(string choix, ref int nbrLignes, ref int nbrColonnes, ref int nbrBombes, out int[,] tab2D)
        {
            if (choix == "1")
            {
                nbrLignes = 8;
                nbrColonnes = 10;
                nbrBombes = 10;
            }

            else if (choix == "2")
            {
                nbrLignes = 14;
                nbrColonnes = 18;
                nbrBombes = 40;
            }

            else if (choix == "3")
            {
                nbrLignes = 20;
                nbrColonnes = 24;
                nbrBombes = 99;
            }

            tab2D = new int[nbrLignes, nbrColonnes];
            nbrLignes = tab2D.GetLength(0);
            nbrColonnes = tab2D.GetLength(1);
            for (int i = 0; i < nbrLignes; i++)
            {
                for (int j = 0; j < nbrColonnes; j++)
                {
                    Console.Write(tab2D[i, j] = 0);
                }
                Console.WriteLine();
            }
        }


        static void PlacementBombes(int nbrLignes, int nbrColonnes, int nbrBombes, ref int[,] tab2D)
        {
            Random rd = new Random();
            for (int i = 0; i < nbrBombes; i++)
            {

                int randomLigne = rd.Next(0, nbrLignes - 1);
                int randomColonne = rd.Next(0, nbrColonnes - 1);

                tab2D[randomLigne, randomColonne] = 9;
            }
            Console.WriteLine();
        }

        static void ChiffresLigneHaut(int[,] tab2D, int nbrLignes)
        {
            int j = nbrLignes;

            for (int i = 1; i < nbrLignes - 1; i++)
            {
                if (tab2D[i, j] != nbrLignes)
                {
                    if (tab2D[i - 1, j] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i + 1, j] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i - 1, j + 1] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i, j + 1] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i + 1, j + 1] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }
                }
            }
        }
        static void ChiffresColonneGauche(int[,] tab2D, int nbrColonnes)
        {
            int i = nbrColonnes;

            for (int j = 1; j < nbrColonnes - 1; j++)
            {
                if (tab2D[i, j] != nbrColonnes)
                {
                    if (tab2D[i, j - 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i, j + 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i + 1, j - 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i + 1, j] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i + 1, j + 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }
                }
            }
        }
        static void ChiffresColonneDroit(int[,] tab2D, int nbrColonnes)
        {
            int i = nbrColonnes;

            for (int j = 1; j < nbrColonnes - 1; j++)
            {

                if (tab2D[i, j] != nbrColonnes)
                {
                    if (tab2D[i, j - 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i, j + 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i - 1, j - 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i - 1, j] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }

                    if (tab2D[i - 1, j + 1] == nbrColonnes)
                    {
                        tab2D[i, j]++;
                    }
                }
            }
        }
        static void ChiffresLigneBas(int[,] tab2D, int nbrLignes)
        {
            int j = nbrLignes;

            for (int i = 1; i < nbrLignes - 1; i++)
            {
                if (tab2D[i, j] != 9)
                {
                    if (tab2D[i - 1, j] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }
                    if (tab2D[i + 1, j] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }
                    if (tab2D[i - 1, j - 1] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }
                    if (tab2D[i, j - 1] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }
                    if (tab2D[i + 1, j - 1] == nbrLignes)
                    {
                        tab2D[i, j]++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string choix;
            char restart;
            int nbrLignes = 0;
            int nbrColonnes = 0;
            int nbrBombes = 0;
            int[,] tab2D;
            do
            {
                Console.Clear();
                Console.WriteLine("Minesweeper \n Menu :\n Débutant : 80 Champs & 10 Mines - 1 \n Intermédiaire : 252 Champs & 40 Mines - 2 \n Expert : 480 Champs & 99 Mines - 3");
                choix = Console.ReadLine();
                ChoixLevel(choix, ref nbrLignes, ref nbrColonnes, ref nbrBombes, out tab2D);

                if (choix == "1")
                {
                    PlacementBombes(nbrLignes, nbrColonnes, nbrBombes, ref tab2D);
                    Show(tab2D);
                    ChiffresLigneHaut(tab2D, nbrLignes);
                    ChiffresColonneGauche(tab2D, nbrColonnes);
                    ChiffresColonneDroit(tab2D, nbrColonnes);
                    ChiffresLigneBas(tab2D, nbrLignes);

                }

                else if (choix == "2")
                {
                    PlacementBombes(nbrLignes, nbrColonnes, nbrBombes, ref tab2D);
                    Show(tab2D);
                }

                else if (choix == "3")
                {
                    PlacementBombes(nbrLignes, nbrColonnes, nbrBombes, ref tab2D);
                    Show(tab2D);
                }


                Console.WriteLine("Voulez-vous recommencer ?");
                Console.WriteLine("Oui - 1 \nNon - 2");
                restart = char.Parse(Console.ReadLine());


            } while (restart == '1');

        }
    }
}
