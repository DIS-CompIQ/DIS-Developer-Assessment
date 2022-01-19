using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using FugaziImporter.Models;


namespace FugaziImporter.Controllers;


[ApiController]
[Route("[controller]")]

public class UploadController : ControllerBase {
    public readonly ILogger<UploadController> _logger;

    public UploadController(ILogger<UploadController> logger){
        _logger = logger;
    }

    [HttpPost] 
    public ActionResult Upload(IFormFile file ){

        try{
            //
            using (var connection = new SqliteConnection("Data Source= @..\\..\\Data\\fugazi.db"))
            {

            if (file != null){
                connection.Open();
                using(var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line != null){
                            var values = line.Split(' ');
                            var patient_name = values[0];
                            var address = values[1];
                            var phone_num = values[2];
                            var injury = values[3];
                            var treatment = values[4];
                            var amount = values[5];
                            var status = values[6]; 
                            
                            var sql = @"INSERT INTO FugaziImport (PatientName, Address, PhoneNumber, Injury, Treatment, Amount, Status) VALUES ($patient_name,$address,$phone_num,$injury,$treatment,$amount,$status)";
                            //var sql = @"INSERT INTO FugaziImport (PatientName) VALUES ($patient_name)";

                            var cmd = connection.CreateCommand();
                            cmd.Parameters.AddWithValue("$patient_name", patient_name);
                            cmd.Parameters.AddWithValue("$address", address);
                            cmd.Parameters.AddWithValue("$phone_num", phone_num);
                            cmd.Parameters.AddWithValue("$injury", injury);
                            cmd.Parameters.AddWithValue("$treatment", treatment);
                            cmd.Parameters.AddWithValue("$amount", amount);
                            cmd.Parameters.AddWithValue("$status", status);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
                connection.Close();
            }

            
            else{

                return BadRequest($"Empty File");
                
            }

            }


        } 
        catch (Exception ex)
        {
            return StatusCode (500, $"Internal server error:{ex}");
        }

        

        return BadRequest($"Not implemented: {file.FileName} - {file.Length}");
    }

   

}