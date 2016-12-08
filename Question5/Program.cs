using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Commentaires ?
/// 13/15
/// </summary>
namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {
            string toucheApppuyer = "";
            string souhaitezContinuer = "";
            int nombrePrise = 0;                    // nombreEssais
            int positionJoueur = 0;
            int deplacementJoueur = 0;
            int mauvaiseToucheSwitch = 0;           //  bool
            int mauvaiseToucheContinuer = 0;        //  bool
            Random rnd = new Random();              
            bool[] tabBool = new bool[100];

            //MESSAGE DE BIENVENU*E*/EXPLICATION DES RÈGLES
            Console.WriteLine("Bienvenu*e* dans le labyrinthe! Votre objectif est de vous rendre à la case 99. \nCertaines cases sont inaccessible, vous devrai donc manoeuvrer à travers \nces cases afin d'atteindre votre objectif.");
            Console.WriteLine("");
            Console.WriteLine("À chaque tentative de déplacement sur une case invalide, vous vous verrez \nattribué une prise. Suite à 4 prises la partie sera perdu et vous \ndevrai repartir du début.");
            Console.WriteLine("");

            tabBool[0] = true;
            tabBool[99] = true;
            //VALEURS DU TABLEAU
            for (int i = 1; i < (tabBool.Length - 1); i++)
            {
                int nombreRnd = rnd.Next(0, 2);
// CC : Par convention, on attribue 0 à false et 1 à true
                if (nombreRnd == 0)             
                {
                    tabBool[i] = true;
                }
                else if (nombreRnd == 1)
                {
                    tabBool[i] = false;
                }
            }
            
            //QUITTER QUAND Q EST APPUYÉ
            while (toucheApppuyer != "Q")
            {

                //EMPECHER MAUVAISE TOUCHE SWITCH
                mauvaiseToucheSwitch = 0;
                while (mauvaiseToucheSwitch == 0)
                {
                    //LIRE LA LETTRE ENTRÉ
                    Console.WriteLine("Veuillez appuyer sur une touche afin de vous déplacer. \nA = 3 cases vers la gauche \nS = 2 cases vers la gauche \nD = 1 case vers la gauche \nG = 2 cases vers la droite\nH = 4 cases vers la droite\nQ = Quitter le programme");
                    toucheApppuyer = string.Format(Console.ReadLine());
                    toucheApppuyer = toucheApppuyer.ToUpper();
                    //SWITCH POUR DÉPLACEMENT

                    switch (toucheApppuyer)
                    {
                        case "A":
                            deplacementJoueur = -3;

// CC : J'aurais fait cette ligne juste si le déplacement est possible. 
// Cela évite de le faire pour tous les cas et d'annuler l'action 
                            positionJoueur = positionJoueur + deplacementJoueur;

                            mauvaiseToucheSwitch = 1;
                            break;
                        case "S":
                            deplacementJoueur = -2;
                            positionJoueur = positionJoueur + deplacementJoueur;
                            mauvaiseToucheSwitch = 1;
                            break;
                        case "D":
                            deplacementJoueur = -1;
                            positionJoueur = positionJoueur + deplacementJoueur;
                            mauvaiseToucheSwitch = 1;
                            break;
                        case "G":
                            deplacementJoueur = 2;
                            positionJoueur = positionJoueur + deplacementJoueur;
                            mauvaiseToucheSwitch = 1;
                            break;
                        case "H":
                            deplacementJoueur = 4;
                            positionJoueur = positionJoueur + deplacementJoueur;
                            mauvaiseToucheSwitch = 1;
                            break;
                        case "Q":
// Non. Utiliser un booléen pour quitter
                            System.Environment.Exit(1);
                            break;
                        case "Y":
                            AffichageEntier(tabBool);
                            mauvaiseToucheSwitch = 1;
                            break;
                        case "P":
                            Affichage10(tabBool, positionJoueur);
                            mauvaiseToucheSwitch = 1;
                            break;
                        default:
                            Console.WriteLine("La touche entré*e* n'est pas utilisable.");
                            break;
                    }
                }
                Console.WriteLine("");
                if (positionJoueur < 0)
                {
                    Console.WriteLine("Votre déplacement est impossible puisque vous seriez positionné \nDEVANT le tableau.");
                    Console.WriteLine("");
                    positionJoueur = positionJoueur - deplacementJoueur;
                }
                else if (positionJoueur > 99)
                {
                    Console.WriteLine("Votre déplacement est impossible puisque vous dépasseriez \nla limite du tableau.");
                    Console.WriteLine("");
                    positionJoueur = positionJoueur - deplacementJoueur;
                }
                //VERIFICATION SI CASE TRUE
                else if  (tabBool[positionJoueur] == true)
                {
                    Console.WriteLine("La case où vous souhaitez vous déplacer est accessible.");
                    Console.WriteLine("");
                    Console.WriteLine("Vous êtes actuellement à la case " + positionJoueur + " du tableau.");
                    Console.WriteLine("");
                    //EMPECHER ERREUR CONTINUER
                    mauvaiseToucheContinuer = 0;
                    while (mauvaiseToucheContinuer == 0)
                    {
                        Console.WriteLine("Souhaitez-vous continuer? O/N");
                        souhaitezContinuer = string.Format(Console.ReadLine());
                        souhaitezContinuer = souhaitezContinuer.ToUpper();
                        //FONCTION CONTINUER OU NON
                        if (souhaitezContinuer == "N")
                        {
                            toucheApppuyer = "Q";
                            mauvaiseToucheContinuer = 1;
                        }
                        else if (souhaitezContinuer == "O")
                        {
                            mauvaiseToucheContinuer = 1;
                        }
                        else
                        {
                            Console.WriteLine("La touche entré*e* n'est pas utilisable.");
                        }
                    }
                }
                //VERIFICATION SI CASE FALSE
                else if (tabBool[positionJoueur] == false)
                {
                    Console.WriteLine("La case où vous souhaitez vous déplacer n'est pas accessible. Vous avez donc une prise additionnelle");
                    Console.WriteLine("");
                    positionJoueur = positionJoueur - deplacementJoueur;
                    nombrePrise = nombrePrise + 1;
                    Console.WriteLine("Vous êtes actuellement à la case " + positionJoueur + " du tableau.");
                    Console.WriteLine("");

// CC : Ce n'est pas ce qui a été demandé. Le but de cette partie est d'aviser le joueur qu'il est impossible de continuer parce qu'il n'y a plus de déplacements possibles
                    if (nombrePrise == 4)   
                    {
                        Console.WriteLine("Vous avez atteint 4 prises. La partie est perdu, \nmeilleur chance la prochaine fois!");
                        Console.WriteLine("");
                        toucheApppuyer = "Q";
                    }
                    else
                    {
                        Console.WriteLine("Nombre de prise accumulé : " + nombrePrise);
                        Console.WriteLine("");

                        //EMPECHER ERREUR CONTINUER
                        mauvaiseToucheContinuer = 0;
                        while (mauvaiseToucheContinuer == 0)
                        {
                            Console.WriteLine("Souhaitez-vous continuer? O/N");
                            souhaitezContinuer = string.Format(Console.ReadLine());
                            souhaitezContinuer = souhaitezContinuer.ToUpper();
                            //FONCTION CONTINUER OU NON
                            if (souhaitezContinuer == "N")
                            {
                                toucheApppuyer = "Q";
                                mauvaiseToucheContinuer = 1;
                            }
                            else if (souhaitezContinuer == "O")
                            {
                                mauvaiseToucheContinuer = 1;
                            }
                            else
                            {
                                Console.WriteLine("La touche entré n'est pas utilisable.");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Merci d'avoir joué!");
            Console.ReadLine();
        }

// CC : Laisser un espace et ajouter un commentaire explicite concernant la fonction
        static void AffichageEntier(bool[] tabBool)
        {
            for (int i = 0; i < tabBool.Length; i++)
            {
// CC : Représentation difficile à l'écran. Remplacer les true/false par des caratères plus adéquats
                Console.WriteLine(tabBool[i]);
            }
        }


// CC : Laisser un espace et ajouter un commentaire explicite concernant la fonction
        static void Affichage10(bool[] tabBool, int positionJoueur)
        {
            if (positionJoueur > 89)    
            {
                Console.WriteLine("Commande indisponible selon la position actuelle.");
            }
            else
            {
                for (int i = positionJoueur + 1; i <= positionJoueur + 10; i++)
                {
                    Console.WriteLine(tabBool[i]);
                }
            }
        }
    }
}
