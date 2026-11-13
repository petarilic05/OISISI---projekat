using System;
using System.Collections.Generic;
using System.Globalization;
using Core.Interfaces;
using Core.Utils;

namespace Core.Models
{
    // Model autora (#autor)
    public class Autor : ISerijalizacija
    {
        public int Id { get; set; }
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public DateTime DatumRodjenja { get; set; }
        public Adresa Adresa { get; set; } = new Adresa();
        public string Telefon { get; set; } = "";
        public string Email { get; set; } = "";
        public string BrojLicneKarte { get; set; } = "";
        public int GodineIskustva { get; set; }

        public List<string> KnjigeIsbn { get; set; } = new List<string>();

        public Autor() { }

        public string[] ToCSV()
        {
            string[] vrednosti = new string[13];
            vrednosti[0] = Id.ToString();
            vrednosti[1] = Ime;
            vrednosti[2] = Prezime;
            vrednosti[3] = DatumRodjenja.ToString("yyyy-MM-dd");
            vrednosti[4] = Adresa.Ulica;
            vrednosti[5] = Adresa.Broj;
            vrednosti[6] = Adresa.Grad;
            vrednosti[7] = Adresa.Drzava;
            vrednosti[8] = Telefon;
            vrednosti[9] = Email;
            vrednosti[10] = BrojLicneKarte;
            vrednosti[11] = GodineIskustva.ToString();
            vrednosti[12] = Serializer.ListaUTekst(KnjigeIsbn);
            return vrednosti;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Ime = values[1];
            Prezime = values[2];
            DatumRodjenja = DateTime.ParseExact(values[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Adresa = new Adresa(values[4], values[5], values[6], values[7]);
            Telefon = values[8];
            Email = values[9];
            BrojLicneKarte = values[10];
            GodineIskustva = int.Parse(values[11]);
            KnjigeIsbn = Serializer.TekstULIstu(values[12]);
        }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}