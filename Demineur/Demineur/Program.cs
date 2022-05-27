using System;

namespace Minesweeper
{
    class Program
    {
        static void ShowIndexAbstractTable(string[,] abstractTable) // Afficher le tableau avec les #; FOR = mettre les espaces correctement
        {
            Console.Write(" ");
            Console.Write(" ");
            if (abstractTable.GetLength(0) >= 10)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < abstractTable.GetLength(1); i++)
            {

                if (abstractTable.GetLength(0) >= 10 || i >= 10)
                {
                    if (i > 10)
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write(" ");
                Console.Write(i);
                Console.Write(" ");

            }

            for (int j = 0; j < abstractTable.GetLength(0); j++)
            {
                Console.WriteLine();
                Console.WriteLine();

                Console.Write(j);
                Console.Write(" ");
                if (abstractTable.GetLength(0) >= 10 && j < 10)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < abstractTable.GetLength(1); k++)
                {

                    Console.Write(" ");
                    Console.Write(abstractTable[j, k]);
                    if (k >= 10)
                    {
                        Console.Write(" ");
                        if (k >= 10) { Console.Write(" "); }
                    }
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        static void ShowIndexTab2D(int[,] tab2D) // Afficher le tableaux avec les bombes (solution)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("SOLUTION:");
            Console.Write(" ");
            Console.Write(" ");
            if (tab2D.GetLength(0) >= 10)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < tab2D.GetLength(1); i++)
            {

                if (tab2D.GetLength(0) >= 10 || i >= 10)
                {
                    if (i > 10)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(" ");
                Console.Write(i);
                Console.Write(" ");
            }

            for (int j = 0; j < tab2D.GetLength(0); j++)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(j);
                Console.Write(" ");
                if (tab2D.GetLength(0) >= 10 && j < 10)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < tab2D.GetLength(1); k++)
                {
                    Console.Write(" ");
                    Console.Write(tab2D[j, k]);
                    if (k >= 10)
                    {
                        Console.Write(" ");
                        if (k >= 10) { Console.Write(" "); }
                    }
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        static void ChoixLevel(string choix, ref int nbrLignes, ref int nbrColonnes, ref int nbrBombes, out int[,] tab2D, out string[,] abstractTable) // Choisir le niveau desire
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
            abstractTable = new string[nbrLignes, nbrColonnes];
            nbrLignes = tab2D.GetLength(0);
            nbrColonnes = tab2D.GetLength(1);

        }

        static void PlacementBombes(int nbrLignes, int nbrColonnes, int nbrBombes, ref int[,] tab2D) // Placer les bombes dans la matrice
        {
            Random rd = new Random();
            for (int i = 0; i < nbrBombes; i++)
            {

                int randomLigne = rd.Next(0, nbrLignes - 1);
                int randomColonne = rd.Next(0, nbrColonnes - 1);
                if (tab2D[randomLigne, randomColonne] != 9)
                {
                    tab2D[randomLigne, randomColonne] = 9;
                }
                else
                {
                    i--;
                }
            }

            Console.WriteLine();
        }

        static void ChiffresLigneHaut(int[,] tab2D, int nbrColonnes) // Ajouter chiffres voisins Ligne Haut
        {

            for (int j = 1; j < nbrColonnes - 1; j++)
            {
                if (tab2D[0, j] != 9)
                {
                    int value = 0;
                    if (tab2D[0, j - 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[1, j - 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[1, j] == 9)
                    {
                        value++;
                    }
                    if (tab2D[1, j + 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[0, j + 1] == 9)
                    {
                        value++;
                    }
                    tab2D[0, j] = value;
                }
            }
        }

        static void ChiffresLigneBas(int[,] tab2D, int nbrColonnes, int nbrLignes) // Ajouter chiffres voisins Ligne Bas
        {
            int i = nbrLignes - 1;

            for (int j = 1; j < nbrColonnes - 1; j++)
            {
                if (tab2D[i, j] != 9)
                {
                    int value = 0;
                    if (tab2D[nbrLignes - 1, j - 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[nbrLignes - 2, j - 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[nbrLignes - 2, j] == 9)
                    {
                        value++;
                    }
                    if (tab2D[nbrLignes - 2, j + 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[nbrLignes - 1, j + 1] == 9)
                    {
                        value++;
                    }

                    tab2D[i, j] = value;
                }

            }
        }

        static void ChiffresColonneGauche(int[,] tab2D, int nbrLignes) // Ajouter chiffres voisins Colonne Gauche
        {
            for (int i = 1; i < nbrLignes - 1; i++)
            {
                if (tab2D[i, 0] != 9)
                {
                    int value = 0;
                    if (tab2D[i - 1, 0] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i - 1, 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i, 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i + 1, 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i + 1, 0] == 9)
                    {
                        value++;
                    }
                    tab2D[i, 0] = value;
                }
            }
        }

        static void ChiffresColonneDroit(int[,] tab2D, int nbrLignes, int nbrColonnes) // Ajouter chiffres voisins Colonne Droit
        {
            int j = nbrColonnes - 1;

            for (int i = 1; i < nbrLignes - 1; i++)
            {
                if (tab2D[i, j] != 9)
                {
                    int value = 0;
                    if (tab2D[i - 1, nbrColonnes - 1] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i - 1, nbrColonnes - 2] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i, nbrColonnes - 2] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i + 1, nbrColonnes - 2] == 9)
                    {
                        value++;
                    }
                    if (tab2D[i + 1, nbrColonnes - 1] == 9)
                    {
                        value++;
                    }

                    tab2D[i, j] = value;
                }

            }
        }

        static void ChiffresCornerHautGauche(int[,] tab2D) // Ajouter chiffres voisins Coin HG
        {
            if (tab2D[0, 0] != 9)
            {
                int value = 0;
                if (tab2D[1, 0] == 9)
                {
                    value++;
                }
                if (tab2D[0, 1] == 9)
                {
                    value++;
                }
                if (tab2D[1, 1] == 9)
                {
                    value++;
                }
                tab2D[0, 0] = value;
            }
        }

        static void ChiffresCornerBasGauche(int[,] tab2D, int nbrLignes) // Ajouter chiffres voisins Coin BG
        {
            if (tab2D[nbrLignes - 1, 0] != 9)
            {
                int value = 0;
                if (tab2D[nbrLignes - 2, 0] == 9)
                {
                    value++;
                }
                if (tab2D[nbrLignes - 1, 1] == 9)
                {
                    value++;
                }
                if (tab2D[nbrLignes - 2, 1] == 9)
                {
                    value++;
                }
                tab2D[nbrLignes - 1, 0] = value;
            }
        }

        static void ChiffresCornerHautDroit(int[,] tab2D, int nbrColonnes) // Ajouter chiffres voisins Coin HD
        {
            if (tab2D[0, nbrColonnes - 1] != 9)
            {
                int value = 0;
                if (tab2D[0, nbrColonnes - 2] == 9)
                {
                    value++;
                }
                if (tab2D[1, nbrColonnes - 1] == 9)
                {
                    value++;
                }
                if (tab2D[1, nbrColonnes - 2] == 9)
                {
                    value++;
                }
                tab2D[0, nbrColonnes - 1] = value;
            }
        }

        static void ChiffresCornerBasDroit(int[,] tab2D, int nbrColonnes, int nbrLignes) // Ajouter chiffres voisins Coin HD
        {
            if (tab2D[nbrLignes - 1, nbrColonnes - 1] != 9)
            {
                int value = 0;
                if (tab2D[nbrLignes - 1, nbrColonnes - 2] == 9)
                {
                    value++;
                }
                if (tab2D[nbrLignes - 2, nbrColonnes - 1] == 9)
                {
                    value++;
                }
                if (tab2D[nbrLignes - 2, nbrColonnes - 2] == 9)
                {
                    value++;
                }
                tab2D[nbrLignes - 1, nbrColonnes - 1] = value;
            }
        }

        static void ChiffresMid(int[,] tab2D, int nbrColonnes, int nbrLignes) // Ajouter chiffres voisins au Centre
        {
            for (int j = 1; j < nbrColonnes - 1; j++)
            {
                for (int i = 1; i < nbrLignes - 1; i++)
                {
                    if (tab2D[i, j] != 9)
                    {
                        if (tab2D[i - 1, j - 1] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i, j - 1] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i + 1, j - 1] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i - 1, j] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i + 1, j] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i - 1, j + 1] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i, j + 1] == 9)
                        {
                            tab2D[i, j]++;
                        }
                        if (tab2D[i + 1, j + 1] == 9)
                        {
                            tab2D[i, j]++;
                        }
                    }
                }
            }
        }

        static void AbstractTable(int[,] tab2D, string[,] abstractTable) // Remplacer les chiffres par des #
        {
            for (int i = 0; i < tab2D.GetLength(0); i++)
            {
                for (int j = 0; j < tab2D.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(abstractTable[i, j] = "#");
                }
                Console.WriteLine();
            }
            Console.Clear();
        }

        static bool VerifyWinOrLose(string[,] abstractTable, int nbrBombes) // Verifier si le joueur a perdu ou gagne
        {
            int counterCard = 0;
            int counterF = 0;
            int counterNonBombe = 0;
            int tam = abstractTable.Length;
            for (int i = 0; i < abstractTable.GetLength(0); i++)
            {
                for (int j = 0; j < abstractTable.GetLength(1); j++)
                {
                    if (abstractTable[i, j] != "#" && abstractTable[i, j] != "F")
                    {
                        counterNonBombe++;
                    }
                    if (abstractTable[i, j] == "#")
                    {
                        counterCard++;
                    }
                    if (abstractTable[i, j] == "F")
                    {
                        counterF++;
                    }
                }
            }

            if (counterCard <= 10 && counterF <= 10 && counterCard + counterF == nbrBombes && tam == counterNonBombe + counterCard + counterF)
            {
                return true;
            }
            else
                return false;
        }

        static void AskAndRevealBox(int[,] tab2D, string[,] abstractTable, int nbrBombes) // Demander a l'utilisateur d'entrer les coordonnes et de suite les afficher
        {
            int counter = 0;
            int l = 0;
            int c = 0;
            int save;

            do
            {
                //ShowIndexTab2D(tab2D);
                int sizeC = abstractTable.GetLength(1);
                int sizeL = abstractTable.GetLength(0);
                string stringNumber;
                string helpFlag;
                bool trueOrFalse;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n RAPPEL!");
                Console.WriteLine("Si vous voulez introduire un drapeau, veuillez écrire un F au moment que vous le désirez \n");
                do
                {


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Quelle est la LIGNE de la box que vous voulez révéler : ");
                    stringNumber = Console.ReadLine();
                    helpFlag = stringNumber;
                    trueOrFalse = VerifyIsNumber(stringNumber);
                    if (counter < nbrBombes)
                    {
                        if (stringNumber == "f" || stringNumber == "F")
                        {
                            DropFlag(abstractTable);
                            counter++;
                            trueOrFalse = true;
                            helpFlag = stringNumber;
                            stringNumber = "1";
                        }
                    }
                    else
                        Console.WriteLine("Vous avez utilisé touts les drapeaux ");


                } while (trueOrFalse == false || ReturnNumber(stringNumber) >= sizeL);

                if (helpFlag != "f" && helpFlag != "F")
                {

                    l = ReturnNumber(stringNumber);
                    do
                    {
                        Console.WriteLine("Quelle est la COLONNE de la box que vous voulez révéler : ");
                        stringNumber = Console.ReadLine();
                        trueOrFalse = VerifyIsNumber(stringNumber);

                    } while (trueOrFalse == false || ReturnNumber(stringNumber) >= sizeC);


                    c = ReturnNumber(stringNumber);
                    save = tab2D[l, c];
                    abstractTable[l, c] = save.ToString();

                }
                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                ShowIndexAbstractTable(abstractTable);

            } while (tab2D[l, c] != 9 && VerifyWinOrLose(abstractTable, nbrBombes) != true);

            if (tab2D[l, c] == 9)
            {
                Console.WriteLine("\n  Vous avez touché une Bombe, vous avez perdu! \n ");
            }
            else
            {
                Console.WriteLine("\n  Vous avez gagné!  \n ");
            }
        }

        static void DropFlag(string[,] abstractTable) // Poser un drapeau
        {
            int l;
            int c;
            string stringNumber;
            bool trueOrFalse;
            do
            {
                Console.WriteLine("Quelle est la LIGNE de la box que vous voulez poser un drapeau : ");
                stringNumber = Console.ReadLine();
                trueOrFalse = VerifyIsNumber(stringNumber);

            } while (trueOrFalse == false || ReturnNumber(stringNumber) > abstractTable.GetLength(0) || ReturnNumber(stringNumber) < 0);
            l = ReturnNumber(stringNumber);
            do
            {
                Console.WriteLine("Quelle est la COLONNE de la box que vous voulez poser un drapeau : ");
                stringNumber = Console.ReadLine();
                trueOrFalse = VerifyIsNumber(stringNumber);

            } while (trueOrFalse == false || ReturnNumber(stringNumber) > abstractTable.GetLength(1) || ReturnNumber(stringNumber) < 0); ;
            c = ReturnNumber(stringNumber);

            if (abstractTable[l, c] != "F" && abstractTable[l, c] != "1" && abstractTable[l, c] != "0")
            {
                abstractTable[l, c] = "F";
            }
            else
            {
                Console.WriteLine("Il existe déja un Drapeau/Chiffre dans cette position");
                stringNumber = Console.ReadLine();
            }
        }

        static bool VerifyIsNumber(string choix) // Verification
        {
            int verifyValue;
            bool isNumber = int.TryParse(choix, out verifyValue);
            return isNumber;
        }
        static int ReturnNumber(string choix) // Verification
        {
            int verifyValue;
            bool isNumber = int.TryParse(choix, out verifyValue);
            if (isNumber)
            {
                return verifyValue;
            }
            else
                return 0;
        }
        static void PrintMinesweeper() // Afficher Menu
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  __  __ ___ _   _ _____ ______        _______ _____ ____  _____ ____  
 |  \/  |_ _| \ | | ____/ ___\ \      / / ____| ____|  _ \| ____|  _ \
 | |\/| || ||  \| |  _| \___ \\ \ /\ / /|  _| |  _| | |_) |  _| | |_) |
 | |  | || || |\  | |___ ___) |\ V  V / | |___| |___|  __/| |___|  _ <
 |_|  |_|___|_| \_|_____|____/  \_/\_/  |_____|_____|_|   |_____|_| \_\
                                                                       ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Menu Difficulté : ");
            Console.WriteLine("\n Débutant : 80 Champs & 10 Mines - 1 \n Intermédiaire : 252 Champs & 40 Mines - 2 \n Expert : 480 Champs & 99 Mines - 3 \n");
        }

        static void Main()
        {
            string choix;
            bool trueOrFalse;
            char restart = '1';
            int flagPrintMinesweeper = 0;
            int nbrLignes = 0;
            int nbrColonnes = 0;
            int nbrBombes = 0;
            int[,] tab2D;
            string[,] abstractTable;
            int end = 0;
            do
            {
                Console.Clear();
                PrintMinesweeper();

                if (flagPrintMinesweeper == 0)
                {
                    flagPrintMinesweeper++;
                }

                do
                {
                    choix = Console.ReadLine();
                    trueOrFalse = VerifyIsNumber(choix);
                    if (trueOrFalse == false || ReturnNumber(choix) > 3 || ReturnNumber(choix) <= 0)
                    {
                        Console.WriteLine("\n Veuillez rentrer un chiffre entre 1 et 3 ! \n");
                    }

                } while (trueOrFalse == false);

                ChoixLevel(choix, ref nbrLignes, ref nbrColonnes, ref nbrBombes, out tab2D, out abstractTable);

                if (choix == "1")
                {
                    PlacementBombes(nbrLignes, nbrColonnes, nbrBombes, ref tab2D);
                    ChiffresLigneHaut(tab2D, nbrColonnes);
                    ChiffresLigneBas(tab2D, nbrColonnes, nbrLignes);
                    ChiffresColonneGauche(tab2D, nbrLignes);
                    ChiffresColonneDroit(tab2D, nbrLignes, nbrColonnes);
                    ChiffresCornerHautGauche(tab2D);
                    ChiffresCornerBasGauche(tab2D, nbrLignes);
                    ChiffresCornerHautDroit(tab2D, nbrColonnes);
                    ChiffresCornerBasDroit(tab2D, nbrColonnes, nbrLignes);
                    ChiffresMid(tab2D, nbrColonnes, nbrLignes);
                    AbstractTable(tab2D, abstractTable);
                    ShowIndexAbstractTable(abstractTable);
                    AskAndRevealBox(tab2D, abstractTable, nbrBombes);

                    end = 1;

                }

                else if (choix == "2")
                {
                    PlacementBombes(nbrLignes, nbrColonnes, nbrBombes, ref tab2D);
                    ChiffresLigneHaut(tab2D, nbrColonnes);
                    ChiffresLigneBas(tab2D, nbrColonnes, nbrLignes);
                    ChiffresColonneGauche(tab2D, nbrLignes);
                    ChiffresColonneDroit(tab2D, nbrLignes, nbrColonnes);
                    ChiffresCornerHautGauche(tab2D);
                    ChiffresCornerBasGauche(tab2D, nbrLignes);
                    ChiffresCornerHautDroit(tab2D, nbrColonnes);
                    ChiffresCornerBasDroit(tab2D, nbrColonnes, nbrLignes);
                    ChiffresMid(tab2D, nbrColonnes, nbrLignes);
                    AbstractTable(tab2D, abstractTable);
                    ShowIndexAbstractTable(abstractTable);
                    AskAndRevealBox(tab2D, abstractTable, nbrBombes);
                    end = 1;
                }

                else if (choix == "3")
                {
                    PlacementBombes(nbrLignes, nbrColonnes, nbrBombes, ref tab2D);
                    ChiffresLigneHaut(tab2D, nbrColonnes);
                    ChiffresLigneBas(tab2D, nbrColonnes, nbrLignes);
                    ChiffresColonneGauche(tab2D, nbrLignes);
                    ChiffresColonneDroit(tab2D, nbrLignes, nbrColonnes);
                    ChiffresCornerHautGauche(tab2D);
                    ChiffresCornerBasGauche(tab2D, nbrLignes);
                    ChiffresCornerHautDroit(tab2D, nbrColonnes);
                    ChiffresCornerBasDroit(tab2D, nbrColonnes, nbrLignes);
                    ChiffresMid(tab2D, nbrColonnes, nbrLignes);
                    AbstractTable(tab2D, abstractTable);
                    ShowIndexAbstractTable(abstractTable);
                    AskAndRevealBox(tab2D, abstractTable, nbrBombes);
                    end = 1;
                }

                if (end == 1)
                {
                    Console.WriteLine("Voulez-vous recommencer ?");
                    Console.WriteLine("Oui - 1 \nNon - 2");
                    restart = char.Parse(Console.ReadLine());
                }

            } while (restart == '1');

        }
    }
}