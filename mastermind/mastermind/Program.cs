/*
 * Created by SharpDevelop.
 * User: d.barboutie
 * Date: 20/10/2023
 * Time: 11:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices; // pour _getche()

namespace mastermind
{
	
	class Program
	{
		//verifie les caracteres
		//utilise regex
		public static bool caractValide(char caract, bool joueur1){
			return true;
		}
		//compte le nombre de bien et mauvais placé
		public static void calculBpMp(ref int bp, ref int mp, char[] combinaison, char[] essaie, char[] combinaisonEssaie){
		
		}
		//fonction qui fait fonctionner la partie du joueur 2
		public static void Joueur2(ref int nbE, char[] combinaison, char[] essaie){
			//
		}
		
		//permet d'ecrire le message de victoire en fonction du nombre d'essaies
		public static void Bilan(int nbE){
			//si le joueur a trouver la chaine de caractere en moins de 5 essais
			if (nbE <=5) {
				Console.WriteLine(" Bravo ! ");
			}
			else{
			//si le joueur a trouver la chaine de caractere en mois de 10 essais mais plus de 5
			if (nbE <= 10) {
				Console.WriteLine(" Correct ");
			}
			//si le joueur a trouver la chaine de caractere en plus de 10 essais
				else{
					Console.WriteLine(" Décevant ");
				}
			}
		}
		
		public static void Main(string[] args)
		{
			char[] combinaison = new char[5]; //tableau réponse
			char[] essaie = new Char[5];	  //tableau d'essaie
			char saisie;					  //indice de parcours des tableaux
			int nbE = 0;
			Console.WriteLine("1er joueur : \n");
			
			//entrée utilisateur pour la chaine de caractère solution
			string entréUtilisateur = Console.ReadLine();
			combinaison = entréUtilisateur.ToCharArray();
			//UTILISER GETCHE()
			Console.Clear();
			//boucle while qui se fini quand toute la chaine de caractere a ete trouver
			while (entréUtilisateur != essaie) {
				//incrémentation du nombre d'essaies
				nbE++;
				//tentatives du joueur 2
				string entréUtilisateur2 = Console.ReadLine();
				essaie=entréUtilisateur2.ToCharArray();
				Console.WriteLine(essaie);
				Console.WriteLine(combinaison);
				Joueur2(ref nbE,combinaison,essaie);
			}
			
			//affichage du résultat
			Bilan(nbE);
			Console.ReadKey(true);
		}
	}
}