using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Classe
    {
        public string nomClasse {  get; private set; }
        public List<Eleve> eleves;
        public List<string> matieres;
        //Constructeur
        public Classe(string nomClasse) 
        { 
            this.nomClasse = nomClasse;
            eleves = new List<Eleve>();
            matieres = new List<string>();
        }
        //Ajout d'un eleve a la classe
        public void ajouterEleve(string prenom, string nom)
        {
            if (this.eleves.Count < 30)
            {
                this.eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                throw new Exception("Une classe ne peut pas avoir plus de 30 eleves");
            }
        }
        //Ajout d'une matiere
        public void ajouterMatiere(string matiere)
        {
            if (this.matieres.Count < 10)
            {
                this.matieres.Add(matiere);
            }
            else
            {
                throw new Exception("Une classe ne peut pas enseigner plus de 10 matieres");
            }
        }
        //Calcul de la moyenne de chaque eleve sur une matiere
        public double moyenneMatiere(int i)
        {
            double total = 0;
            foreach (Eleve eleve in this.eleves)
            {
                total += eleve.moyenneMatiere(i);
            }
            return Math.Round(total/eleves.Count, 2);
        }
        //Calcul de la moyenne des moyennes generales de chaque eleves
        public double moyenneGeneral()
        {
            double total = 0;
            foreach (Eleve eleve in this.eleves)
            {
                total += eleve.moyenneGeneral();
            }
            return Math.Round(total/ eleves.Count, 2);
        }

    }
}
