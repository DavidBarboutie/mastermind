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
		public void affichage(){}
		//verifie les caracteres
		public static bool caractValide(char caract, bool joueur1){
		
		}
		//compte le nombre de bien et mauvais placé
		public static void calculBpMp(ref int bp, ref int mp, char[] combinaison, char[] essaie, char[] combinaisonEssaie){
		
		}
		//fonction qui fait fonctionner la partie du joueur 2
		public static void Joueur2(ref int nbE, char[] ombinaison, char[] essaie){
		
		}
		
		//permet d'ecrire le message de victoire en fonction du nombre d'essaies
		public static void Bilan(int nbE){
			if (nbE <=5) {
				Console.WriteLine(" Bravo ! "):
			}
			else{
			if (nbE <= 10) {
				Console.WriteLine(" Correct ");
			}
				else{
					Console.WriteLine(" Décevant ");
				}
			}
		}
		
		public static void Main(string[] args)
		{
			char[] combinaison = new char[5]; //tableau réponse
			char[] essaie = new Char[5];	  //tableau d'essaie
			char saisie;					  //indice de aprcour des tableaux
			Console.ReadKey(true);
		}
	}
}