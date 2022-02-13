using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FugaziImporter.Models;

  public class FugaziImport
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}

    [Required(ErrorMessage = "Required")]
    [MaxLength(25, ErrorMessage = "Patient name must not exceed 25 characters")]
    public string PatientName {get; set;}

    [MaxLength(50, ErrorMessage = "Address must not exceed 50 characters")]
    public string Address {get; set;}

    [MaxLength(10, ErrorMessage = "Phone number must not exceed 10 characters")]
    public double PhoneNumber {get; set;}

    [MaxLength(30, ErrorMessage = "Injury must not exceed 30 characters")]
    public string Injury {get; set;}

    [MaxLength(30, ErrorMessage = "Treatment must not exceed 30 characters")]
    public string Treatment {get; set;}

    [MaxLength(15, ErrorMessage = "Amount must not exceed 15 characters")]
    public decimal Amount {get; set;}

    [MaxLength(10, ErrorMessage = "Status must not exceed 10 characters")]
    public string Status {get; set;}
  }