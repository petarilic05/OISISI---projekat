using System.Collections.Generic;
using System.Globalization;
using Core.Interfaces;
using Core.Utils;

namespace Core.Models
{
    // Model knjige (#knjiga)
    public class Knjiga : ISerijalizacija
    {
        public string ISBN { get; set; } = "";
        public string Naziv { get; set; } = "";
        public string Zanr { get; set; } = "";
        public int GodinaIzdanja { get; set; }
        public double Cena { get; set; }
        public int BrojStrana { get; set; }

        public List<int> AutoriIds { get; set; } = new List<int>();

        public string IzdavacSifra { get; set; } = "";

        public List<string> KupciBrojeviKartica { get; set; } = new List<string>();

        public List<string> ListaZeljaBrojeviKartica { get; set; } = new List<string>();

        public Knjiga() { }

        public string[] ToCSV()
        {
            List<string> autoriKaoTekst = new List<string>();
            foreach (int id in AutoriIds)
            {
                autoriKaoTekst.Add(id.ToString());
            }

            string[] vrednosti = new string[10];
            vrednosti[0] = ISBN;
            vrednosti[1] = Naziv;
            vrednosti[2] = Zanr;
            vrednosti[3] = GodinaIzdanja.ToString();
            vrednosti[4] = Cena.ToString(CultureInfo.InvariantCulture);
            vrednosti[5] = BrojStrana.ToString();
            vrednosti[6] = Serializer.ListaUTekst(autoriKaoTekst);
            vrednosti[7] = IzdavacSifra;
            vrednosti[8] = Serializer.ListaUTekst(KupciBrojeviKartica);
            vrednosti[9] = Serializer.ListaUTekst(ListaZeljaBrojeviKartica);
            return vrednosti;
        }

        public void FromCSV(string[] values)
        {
            ISBN = values[0];
            Naziv = values[1];
            Zanr = values[2];
            GodinaIzdanja = int.Parse(values[3]);
            Cena = double.Parse(values[4], CultureInfo.InvariantCulture);
            BrojStrana = int.Parse(values[5]);

  
            AutoriIds = new List<int>();
            List<string> autoriKaoTekst = Serializer.TekstULIstu(values[6]);
            foreach (string tekst in autoriKaoTekst)
            {
                AutoriIds.Add(int.Parse(tekst));
            }

            IzdavacSifra = values[7];
            KupciBrojeviKartica = Serializer.TekstULIstu(values[8]);
            ListaZeljaBrojeviKartica = Serializer.TekstULIstu(values[9]);
        }

        public override string ToString()
        {
            return ISBN + " " + Naziv;
        }
    }
}