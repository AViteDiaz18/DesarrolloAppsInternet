using System;
namespace P18Listas2
{
    class Pieza
    {
        public Pieza(int id, string nom) => (Id,Nom) = (id,nom);
        public int Id{get; set;}
        public string Nom {get; set;}

        //Sobrecargamos el metodo toString
        public override string ToString() => $"{Id} - {Nom}";
    }
}