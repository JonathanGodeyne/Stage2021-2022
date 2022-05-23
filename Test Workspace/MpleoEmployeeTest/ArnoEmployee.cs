using System;
using System.Text.Json.Serialization;

namespace MpleoEmployeeTest
{
    public class ArnoEmployee
    {
        public string BijkomendeId { get; set; }    
        public string Rijksregister { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public string WerkEmail { get; set; }
        public string PersoonlijkEmail { get; set; }       

        public static ArnoEmployee MapFrom(MpleoEmployee source)
        {
            return new ArnoEmployee
            {
                BijkomendeId = source.employeeCode,
                Rijksregister = source.nationalNumber,
                Naam = source.lastName,
                Voornaam = source.firstName,
                Geboortedatum = source.birthDate,
                WerkEmail = source.emailProfessional,
                PersoonlijkEmail = source.emailPersonal
            };
        }
    }
}
