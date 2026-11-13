using Core.Interfaces;

namespace Core.Models
{
    // Model adrese (#adresa)
    public class Adresa : ISerijalizacija
    {
        public string Ulica { get; set; } = "";
        public string Broj { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Drzava { get; set; } = "";

        public Adresa() { }

        public Adresa(string ulica, string broj, string grad, string drzava)
        {
            Ulica = ulica;
            Broj = broj;
            Grad = grad;
            Drzava = drzava;
        }

        public string[] ToCSV()
        {
            string[] vrednosti = new string[4];
            vrednosti[0] = Ulica;
            vrednosti[1] = Broj;
            vrednosti[2] = Grad;
            vrednosti[3] = Drzava;
            return vrednosti;
        }

        public void FromCSV(string[] values)
        {
            Ulica = values[0];
            Broj = values[1];
            Grad = values[2];
            Drzava = values[3];
        }

        public override string ToString()
        {
            return Ulica + " " + Broj + ", " + Grad + ", " + Drzava;
        }
    }
}