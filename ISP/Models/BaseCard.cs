using System.ComponentModel.DataAnnotations;

namespace ISP.Models
{
    public class BaseCard
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Укажите фамилию")]
        public string SecondName { get; set; } = "";

        [Required(ErrorMessage = "Укажите отчество")]
        public string MiddleName { get; set; } = "";

        [Required(ErrorMessage = "Укажите общество")]
        public string Company { get; set; } = "ООО \"Интеллектуальные системы\"";

        [Required(ErrorMessage = "Укажите подразделение")]
        public string Department { get; set; } = "";

        [Required(ErrorMessage = "Укажите должность")]
        public string Position { get; set; } = "";

        public string FullName => $"{SecondName} {FirstName} {MiddleName}";
        public string ShortName
        {
            get
            {
                if (FirstName.Count() > 0 && MiddleName.Count() > 0)
                    return $"{SecondName} {(FirstName[0])}.{MiddleName[0]}.";
                else return "NoName";
            }
        }

        public string CardType { get; } = "";

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public BaseCard(string cardType)
        {
            CardType = cardType;
        }
    }
}
