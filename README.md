# Sajam knjiga

Projektni zadatak iz predmeta Osnovi informacionih sistema i softverskog inženjerstva.

## Autori
- Student 1: Dušan Soro
- Student 2: Petar Ilić

## Podela posla

### Dušan Soro
- 

### Petar Ilić
- Modeli: Adresa, Autor, Knjiga
- DAO: AutorDao, KnjigaDao
- Zajedničko: ISerijalizacija, Serializer
- Autori: prikaz, dodavanje, izmena, brisanje (u izradi)
- Knjige: prikaz, brisanje (u izradi)

## Struktura
- `Core`: modeli, DAO klase, interfejsi i Serializer
- `WpfClient`: korisnički interfejs
- `Data`: CSV datoteke sa podacima

## Pokretanje
Otvoriti `sajam_knjiga.slnx` u Visual Studiju i pokrenuti projekat `WpfClient`.