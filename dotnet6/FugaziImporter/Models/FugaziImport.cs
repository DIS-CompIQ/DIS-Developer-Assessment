using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FugaziImporter.Models;

    public class FugaziImport
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get;set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 30 Characters")]
        [MinLength(3, ErrorMessage ="This field must contain between 3 and 30 Characters")]

        public string PatientName {get;set;}

        [MaxLength(1024, ErrorMessage = "This field can contain up to 1024 Characters")]
        

        public int PhoneNumber {get;set;}

        [MaxLength(10, ErrorMessage = "This field must contain between 7 and 10 Characters")]
        [MinLength(7, ErrorMessage ="This field must contain between 7 and 10 Characters")]

        public string Injury {get;set;}

        [MaxLength(1024, ErrorMessage = "This field can contain up to 1024 Characters")]

        public int Treatment {get;set;}

        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 30 Characters")]
        [MinLength(3, ErrorMessage ="This field must contain between 3 and 30 Characters")]

        public int Amount {get;set;}

        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 30 Characters")]
        [MinLength(3, ErrorMessage ="This field must contain between 3 and 30 Characters")]

        public string Status {get;set;}

    
    }

        

    
    
