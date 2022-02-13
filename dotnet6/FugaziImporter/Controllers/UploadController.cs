using FugaziImporter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FugaziImporter.Controllers;

[ApiController]
[Route("[controller]")]
public class UploadController : ControllerBase {
    // public readonly ILogger<UploadController> _logger;

    // public UploadController(ILogger<UploadController> logger){
    //     _logger = logger;
    // }

    private readonly FugaziContext _context;

    public UploadController(FugaziContext context)
    {
        _context = context;
    }

    [HttpPost] 
    public async Task<ActionResult> Upload(IFormFile file){
        // open file
        // read and parse file
        try
        {
            if (file != null)
            {
                using (StreamReader reader = new StreamReader(file.OpenReadStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // find data field and remove whitespace
                        Regex pattern = new Regex(@"\s\s+");

                        string patientNameLong = line.Substring(0, 25);
                        string patientName = pattern.Replace(patientNameLong, "");

                        string addressLong = line.Substring(25, 50);
                        string address = pattern.Replace(addressLong, "");

                        string phoneLong = line.Substring(75, 10);
                        string phone = pattern.Replace(phoneLong, "");

                        string injuryLong = line.Substring(85, 30);
                        string injury = pattern.Replace(injuryLong, "");

                        string treatmentLong = line.Substring(115, 30);
                        string treatment = pattern.Replace(treatmentLong, "");

                        string amountLong = line.Substring(145, 15);
                        string amount = pattern.Replace(amountLong, "");

                        string statusLong = line.Substring(160, 10);
                        string status = pattern.Replace(statusLong, "");


                        // build json object/payload
                        FugaziImport import = new FugaziImport()
                        {
                            PatientName = patientName,
                            Address = address,
                            PhoneNumber = Double.Parse(phone),
                            Injury = injury,
                            Treatment = treatment,
                            Amount = Decimal.Parse(amount),
                            Status = status
                        };

                        Console.WriteLine(import);
                        // post to db
                        await _context.FugaziImport.AddAsync(import);
                        await _context.SaveChangesAsync();
                    }
                    // return some sort of success message
                    return StatusCode(201, "Successfully uploaded fugazi records");
                }
            }
            else
            {
                return BadRequest($"File is empty");
            }
        }
        catch (Exception exception)
        {
            return StatusCode(500, $"Internal server error: {exception}");
        }
    }
}