using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Utils
{
    // Pomoćna klasa: čita i piše redove teksta u fajlove.
    // Jedan red u fajlu = jedan objekat. Kolone su razdvojene znakom '|'.
    public static class Serializer
    {
        // Pravi punu putanju do fajla u folderu "Data".
        // Koristi Path.DirectorySeparatorChar, kako traži specifikacija.
        private static string NapraviPutanju(string imeFajla)
        {
            string folder = AppContext.BaseDirectory + "Data";
            return folder + Path.DirectorySeparatorChar + imeFajla;
        }

        // Čita fajl i vraća listu redova. Svaki red je niz kolona.
        public static List<string[]> Ucitaj(string imeFajla)
        {
            List<string[]> redovi = new List<string[]>();
            string putanja = NapraviPutanju(imeFajla);

            // Ako fajl ne postoji (prvo pokretanje), vraćamo praznu listu
            if (!File.Exists(putanja))
            {
                return redovi;
            }

            string[] linije = File.ReadAllLines(putanja);
            foreach (string linija in linije)
            {
                if (linija.Trim() != "")
                {
                    string[] kolone = linija.Split('|');
                    redovi.Add(kolone);
                }
            }
            return redovi;
        }

        // Upisuje listu redova u fajl. Stari sadržaj se briše.
        public static void Snimi(string imeFajla, List<string[]> redovi)
        {
            string putanja = NapraviPutanju(imeFajla);

            // Ako folder "Data" ne postoji, napravi ga
            Directory.CreateDirectory(AppContext.BaseDirectory + "Data");

            List<string> linije = new List<string>();
            foreach (string[] kolone in redovi)
            {
                // Znak '|' u tekstu bi pokvario fajl, pa ga menjamo razmakom
                for (int i = 0; i < kolone.Length; i++)
                {
                    kolone[i] = kolone[i].Replace("|", " ");
                }
                linije.Add(string.Join("|", kolone));
            }
            File.WriteAllLines(putanja, linije);
        }

        // Spaja listu tekstova u jedan tekst: ["a","b"] -> "a;b"
        public static string ListaUTekst(List<string> lista)
        {
            return string.Join(";", lista);
        }

        // Razdvaja tekst u listu: "a;b" -> ["a","b"]. Prazan tekst daje praznu listu.
        public static List<string> TekstULIstu(string tekst)
        {
            List<string> lista = new List<string>();
            if (tekst.Trim() == "")
            {
                return lista;
            }

            string[] delovi = tekst.Split(';');
            foreach (string deo in delovi)
            {
                lista.Add(deo);
            }
            return lista;
        }
    }
}