using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // Common Messages
        public static string MaintenanceTime = "The system is in maintenance.";
        public static string MessageListed = "Listed.";
        public static string MessageNotListed = "Not listed.";

        // JWT Authentication Messages
        public static string TokenCreated = "Token created.";
        public static string AuthorizationDenied = "Authorization denied.";
        public static string LoginSuccessful = "Logovanje uspešno.";
        public static string Registered = "Registracija.";
        public static string UserAlreadyExists = "User already exists.";
        public static string UserNotFound = "Korisnik nije pronadjen.";
        public static string NalogNijeAktivan = "Nalog nije aktivan kontaktirajte administratora.";
        public static string WrongPassword = "Pogrešno korisničko ime i lozinka.";

        // Automobil Messages
        public static string AutomobilAdded = "Automobil dodat.";
        public static string AutomobilDeleted = "Automobil obrisan.";
        public static string AutomobilUpdated = "Automobil izmenjen.";
        public static string AutomobilNameInvalid = "Automobil name is invalid.";

        // Automobil rezervacija Messages
        public static string RezervacijaAdded = "Automobil je rezervisan.";
        public static string RezervacijaDeleted = "Rezervacija je poništena.";
        public static string RezervacijaUpdated = "Automobil izmenjen.";
        public static string RezervacijaNeuspesna = "Automobil nije dostupan";
        

        // Car Images Messages
        public static string CarImageAdded = "Car image added.";
        public static string CarImageDeleted = "Car image deleted.";
        public static string CarImageUpdated = "Car image updated.";
        public static string CarImageNumberError = "A car cannot have more than 5 images.";
        public static string CarImageNotFound = "Car image not found";

        // Proizvodjac Messages 
        public static string ProizvodjacAdded = "Proizvodjac dodat.";
        public static string ProizvodjacDeleted = "Proizvodjac obrisan.";
        public static string ProizvodjacDeletedError = "Ne možete da obrišete proizvođača, jer je povezan sa modelom automobila.";
        public static string ProizvodjacUpdated = "Proizvodjac izmenjen.";
        public static string ProizvodjacNameInvalid = "Proizvodjacevo ime je pogrešno.";

        // CenaPoDanu Messages 
        public static string CenaPoDanucAdded = "Cena iznajmljivanja je dodata.";
        public static string CenaPoDanuDeleted = "Cena je obrisana";
        public static string CenaPoDanuUpdated = "Cena je izmenjena.";
     


        // ModelAutomobila Messages 
        public static string ModelAutomobilaAdded = "Model automobila dodat.";
        public static string ModelAutomobilaDeleted = "Model automobila obrisan.";
        public static string ModelAutomobilaDeletedError = "Ne možete da obrišete model automobila, jer je povezan sa automobilom.";
        public static string ModelAutomobilaUpdated = "Model automobila izmenjen.";
        public static string ModelAutomobilaNameInvalid = "Model automobila ime je pogrešno.";

        // User Messages
        public static string UserAdded = "Korisnik dodat.";
        public static string UserDeleted = "Korisnik obrisan.";
        public static string UserDeletedError = "Ne možete da obrišete korisnika, jer  je povezan sa drugim tabelama.";
        public static string UserUpdated = "Korisnik izmenjen.";
        public static string UserUpdatedStatus = "Nalog korisnika je aktivan.";
        public static string UserNameInvalid = "Korisnikovo ime nije validno.";
        public static string CurrentPasswordIsWrong = "Uneli ste pogrešnu trenutnu lozinku.";
        public static string PasswordUpdated = "Lozinka uspešno izmenjena.";
        public static string AktivanNalog = "Nalog korisnika nije aktivan";
        // Rental Messages
        public static string RentalAdded = "Iznajmljivanje uspešno.";
        public static string RentalDeleted = "Iznajmljivanje poništeno.";
        public static string RentalUpdated = "Iznajmljivanja izmenjeno.";
        public static string RentalNameInvalid = "Rental name is invalid.";
        public static string CarIsAlreadyRented = "Automobil nije dostupan.";
        public static string FindeksScoreIsNotEnough = "Your findeks score is not enough for this car.";
        public static string CarReturn = "Automobil je uspešno vrećen";
        

        // Istorija Messages
        public static string IstorijaAdded = "Istorija iznajmljivanja je dodata.";
        public static string IstorijaDeleted = "Istorija iznajmljivanja je obrisana.";
        public static string IstorijaUpdated = "Istorija iznajmljivanja je izmenjena.";
       

      
    }
}
