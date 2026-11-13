using System.Collections.Generic;
using Core.Models;
using Core.Utils;

namespace Core.DAO
{
    // Čuva listu autora, učitava je iz fajla i snima u fajl
    public class AutorDao
    {
        private const string ImeFajla = "autori.csv";
        private List<Autor> _autori = new List<Autor>();

        // Pri pravljenju DAO-a učitavamo autore iz fajla
        public AutorDao()
        {
            List<string[]> redovi = Serializer.Ucitaj(ImeFajla);
            foreach (string[] red in redovi)
            {
                Autor autor = new Autor();
                autor.FromCSV(red);
                _autori.Add(autor);
            }
        }

        public List<Autor> GetAll()
        {
            return _autori;
        }

        // Traži autora po Id-ju. Ako ga nema, vraća null.
        public Autor GetById(int id)
        {
            foreach (Autor autor in _autori)
            {
                if (autor.Id == id)
                {
                    return autor;
                }
            }
            return null;
        }

        public void Add(Autor autor)
        {
            // Novi Id = najveći postojeći Id + 1
            int najveciId = 0;
            foreach (Autor a in _autori)
            {
                if (a.Id > najveciId)
                {
                    najveciId = a.Id;
                }
            }
            autor.Id = najveciId + 1;

            _autori.Add(autor);
            Save();
        }

        // Zamenjuje postojećeg autora (isti Id) izmenjenim
        public void Update(Autor autor)
        {
            for (int i = 0; i < _autori.Count; i++)
            {
                if (_autori[i].Id == autor.Id)
                {
                    _autori[i] = autor;
                    Save();
                    return;
                }
            }
        }

        public void Delete(int id)
        {
            Autor zaBrisanje = GetById(id);
            if (zaBrisanje != null)
            {
                _autori.Remove(zaBrisanje);
                Save();
            }
        }

        // Pretvara sve autore u redove teksta i upisuje ih u fajl
        public void Save()
        {
            List<string[]> redovi = new List<string[]>();
            foreach (Autor autor in _autori)
            {
                redovi.Add(autor.ToCSV());
            }
            Serializer.Snimi(ImeFajla, redovi);
        }
    }
}