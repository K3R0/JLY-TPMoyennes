using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;

namespace HNI_TPmoyennes
{
    internal class Eleve
    {
        public string prenom {  get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }
        //Constructeur
        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();
        }
        //Ajout d'une Note
        public void ajouterNote(Note note)
        {
            if (notes.Count <= 200)
            {
                this.notes.Add(note);
            } else {
                throw new Exception("Un eleve ne peut pas avoir plus de 200 notes");
                    }
        }
        //Calcul de la moyenne d'une matière
        public double moyenneMatiere(int i)
        {
            float total = 0;
            int count = 0;
            foreach (Note note in notes)
            {
                if (note.matiere == i)
                {
                    total += note.note;
                    count++;
                }
            }
            return Math.Round(total / count, 2);
        }
        //Methode pour recuperer le nombre de matière que un eleve suit
        private int nombreMatiere()
        {
            int max = 0;
            foreach (Note note in notes)
            {
                if (note.matiere > max)
                {
                    max = note.matiere;
                }
            }
            return max;
        }
        //Calcul de la moyenne des moyennes de chaque matières
        public double moyenneGeneral()
        {
            int nombreMatiere = this.nombreMatiere();
            double total = 0;
            for (int i = 0; i < nombreMatiere; i++)
            {
                total += this.moyenneMatiere(i);
            }
            return Math.Round(total / nombreMatiere, 2);
        }
    }
}
