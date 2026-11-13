using System.Collections.Generic;
using Core.Models;
using Core.Utils;

namespace Core.DAO
{
    // Čuva listu knjiga, učitava je iz fajla i snima u fajl
    public class KnjigaDao
    {
        private const string ImeFajla = "knjige.csv";
        private List<Knjiga> _knjige = new List<Knjiga>();

        // Pri pravljenju DAO-a učitavamo knjige iz fajla
        public KnjigaDao()
        {
            List<string[]> redovi = Serializer.Ucitaj(ImeFajla);
            foreach (string[] red in redovi)
            {
                Knjiga knjiga = new Knjiga();
                knjiga.FromCSV(red);
                _knjige.Add(knjiga);
            }
        }

        public List<Knjiga> GetAll()
        {
            return _knjige;
        }

        // Traži knjigu po ISBN-u. Ako je nema, vraća null.
        public Knjiga GetByIsbn(string isbn)
        {
            foreach (Knjiga knjiga in _knjige)
            {
                if (knjiga.Isbn == isbn)
                {
                    return knjiga;
                }
            }
            return null;
        }

        public void Add(Knjiga knjiga)
        {
            _knjige.Add(knjiga);
            Save();
        }

        // Zamenjuje postojeću knjigu (isti ISBN) izmenjenom
        public void Update(Knjiga knjiga)
        {
            for (int i = 0; i < _knjige.Count; i++)
            {
                if (_knjige[i].Isbn == knjiga.Isbn)
                {
                    _knjige[i] = knjiga;
                    Save();
                    return;
                }
            }
        }

        public void Delete(string isbn)
        {
            Knjiga zaBrisanje = GetByIsbn(isbn);
            if (zaBrisanje != null)
            {
                _knjige.Remove(zaBrisanje);
                Save();
            }
        }

        // Pretvara sve knjige u redove teksta i upisuje ih u fajl
        public void Save()
        {
            List<string[]> redovi = new List<string[]>();
            foreach (Knjiga knjiga in _knjige)
            {
                redovi.Add(knjiga.ToCSV());
            }
            Serializer.Snimi(ImeFajla, redovi);
        }
    }
}