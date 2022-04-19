using System;
using System.Text.Json.Serialization;

namespace MpleoEmployeeTest
{
    public class ArnoEmployee
    {
        //N
        [JsonPropertyName("V100.F101")]
        public string employeeCode { get; set; }    
        //Y
        [JsonPropertyName("V100.F105")]
        public string nationalNumber { get; set; }
        //N
        [JsonPropertyName("V100.F102")]
        public string lastName { get; set; }
        //N
        [JsonPropertyName("V100.F103")]
        public string firstName { get; set; }
        //N
        [JsonPropertyName("V100.F108")]
        public DateTime? birthDate { get; set; }
        //Y
        [JsonPropertyName("V100.L9943.F101")]
        public string emailProfessional { get; set; }
        //Y
        [JsonPropertyName("V100.L9941.F101")]
        public string emailPersonal { get; set; }

        public static explicit operator ArnoEmployee(MpleoEmployee mpleoEmployee)
        {
            ArnoEmployee arnoEmployee = new ArnoEmployee();
            arnoEmployee.employeeCode = mpleoEmployee.employeeCode;
            arnoEmployee.nationalNumber = mpleoEmployee.nationalNumber;
            arnoEmployee.lastName = mpleoEmployee.lastName;
            arnoEmployee.firstName = mpleoEmployee.firstName;
            arnoEmployee.birthDate = mpleoEmployee.birthDate;
            arnoEmployee.emailProfessional = mpleoEmployee.emailProfessional;
            arnoEmployee.emailPersonal = mpleoEmployee.emailPersonal;
            return arnoEmployee;
        }
    }
}
