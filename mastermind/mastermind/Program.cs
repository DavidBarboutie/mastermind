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
using System.Linq; // pour .SequenceEgual()
using System.Text.RegularExpressions; //regex

namespace mastermind
{
	
	class Program
	{
		
		[DllImport("msvcrt")]
		static extern int _getche();
		
		//verifie les caracteres
		//utilise regex
		public static bool caractValide(char caract){
			
			//filtre
			Regex rx = new Regex("[BRNVJOG]");
			MatchCollection matchedCarctere = rx.Matches(caract.ToString());
			
			//verifir si le caractere rentré se trouve bien dans le filtre
			for (int count = 0; count < matchedCarctere.Count; count++) {
				if (matchedCarctere[count].Value != null) {
					return true;
				}
			}
			return false;
		}
		//compte le nombre de bien et mauvais placé
		public static void calculBpMp(ref int bp, ref int mp, char[] combinaison, char[] essaie, char[] combinaisonEssaie){
			
				//bien placé
			for (int i = 0; i < 5; i++) {
				//verifie que les elements des 2 tableaux de char aux même index pour trouver les bien placé
				if (combinaison[i] == essaie[i]) {
					bp++;
					combinaisonEssaie[i]= char.Parse("X");
					essaie[i]=char.Parse("Y");
				}
				else{
					combinaisonEssaie[i] = combinaison[i];
				}
			}
			
			//mal placé
			for (int i = 0; i < combinaisonEssaie.Length; i++) {
				for (int j = 0; j < combinaisonEssaie.Length; j++) {
					if (combinaisonEssaie[i] == essaie[j]) {
						mp++;
						combinaisonEssaie[i]=char.Parse("X");
						essaie[j]=char.Parse("Y");
					}
				}
			}
			
		}
		
		//fonction qui fait fonctionner la partie du joueur 2
		public static void Joueur2(ref int nbE, char[] combinaison, char[] essaie){
			char [] combinaisonEssaie = new char[5];
			int bp = 0;
			int mp = 0;
			//Console.SetCursorPosition(Console.CursorLeft,0);
			
			//affichage des lignes d'essaie
			Console.Write("essai :" + nbE +" ");
			
			//position du curseur
			
			
			//fin de la ligne d'eesaie
			calculBpMp(ref bp,ref mp,combinaison,essaie,combinaisonEssaie);
			Console.Write("		"+bp+"			"+mp+"\n");
		}
		
		//permet d'ecrire le message de victoire en fonction du nombre d'essaies
		public static void Bilan(int nbE){
			//si le joueur a trouver la chaine de caractere en moins de 5 essais
			if (nbE <= 5) {
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
			char[] essaie = new char[5];	  //tableau d'essaie
			char saisie;					  //indice de parcours des tableaux
			int nbE = 0;
			Console.WriteLine("1er joueur : \n");
			
			//entrée utilisateur pour la chaine de caractère solution
			//5 caracteres
			int cpt1 = 0;
			while (cpt1 < 5) {
				
				
				
				//verification de la validité du caractere entrer doit etre B,R,N,V,J,O ou G
				saisie = (char)_getche();
				while (caractValide(saisie) != true) {
					//utilisation du _getche() pour ne pas avoir a faire entrer une fois les 5 caractere entrés
					saisie = (char)_getche();
				}
				
				//ajout des caractere au tableau réponse
				combinaison[cpt1]=saisie;
				
				//incrementation pour sortir de la boucle quand les 5 caracteres sont entrés
				cpt1++;
			}
			//effacer la réponse de l'ecran
			Console.Clear();
			
			//boucle while qui se fini quand toute la chaine de caractere a ete trouver
			//boucle principale
			//tant que combinaison et essaie sont different, executé la boucle
			while (combinaison.SequenceEqual(essaie) == false) {
				
				//incrémentation du nombre d'essaies
				nbE++;
				
				//affichage de l'ecran du joueur 2
				//affichage de la ligne en haut
				if (nbE == 1) {
				Console.WriteLine("2eme Joueur :		bien place		mal place");
				}
				
				Joueur2(ref nbE,combinaison,essaie);
				
				//tentatives du joueur 2
				//compteur
				int cpt2 = 0;
				
				//5 caracteres
				while (cpt2 < 5) {
					
					//verification de la validité du caractere entrer doit etre B,R,N,V,J,O ou G
					char entrer_essaie = (char)_getche();
					//boucle while qui se termine seulement quand les 5 caracteres filtrés ont été entrer dans le tableau de char d'essaie
					while (caractValide(entrer_essaie) != true) {
						//utilisation du _getche() pour ne pas avoir a faire entrer une fois les 5 caractere entrés
						entrer_essaie = (char)_getche();
					}
					
					//ajout des caractere au tableau d'essaie
					essaie[cpt2] = entrer_essaie;
					
					//incrementation pour sortir de la boucle quand les 5 caracteres sont entrés
					cpt2++;
				}
				Console.WriteLine(" ");
			}
			
			//affichage du résultat
			Console.Write("vous avez trouver en "+nbE+" essaies");
			Bilan(nbE);
			Console.ReadKey(true);
		}
	}
}