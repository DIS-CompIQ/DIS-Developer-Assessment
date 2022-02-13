using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FugaziImporter.Models;
using System.Text;

namespace FugaziImporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadController : ControllerBase
    {
        private readonly FugaziContext _context;

        public DownloadController(FugaziContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<FileResult> DownloadAll(){
            var allRecords = await _context.FugaziImports.ToListAsync();

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            foreach (FugaziImport fugazi in allRecords)
            {
                if (fugazi != null)
                { 
                    // build strings with json data
                    StringBuilder PatientName = new StringBuilder(fugazi.PatientName, 25);
                    PatientName.Append(' ', 25 - PatientName.Length);

                    StringBuilder Address = new StringBuilder(fugazi.Address, 50);
                    Address.Append(' ', 50 - Address.Length);

                    StringBuilder PhoneNumber = new StringBuilder(fugazi.PhoneNumber.ToString(), 10);
                    PhoneNumber.Append(' ', 10 - PhoneNumber.Length);

                    StringBuilder Injury = new StringBuilder(fugazi.Injury, 30);
                    Injury.Append(' ', 30 - Injury.Length);

                    StringBuilder Treatment = new StringBuilder(fugazi.Treatment, 30);
                    Treatment.Append(' ', 30 - Treatment.Length);

                    StringBuilder Amount = new StringBuilder(fugazi.Amount.ToString(), 15);
                    Amount.Append(' ', 15 - Amount.Length);

                    StringBuilder Status = new StringBuilder(fugazi.Status, 10);
                    Status.Append(' ', 10 - Status.Length);

                    StringBuilder line = new StringBuilder("", 170);
                    line.Append($"{PatientName}{Address}{PhoneNumber}{Injury}{Treatment}{Amount}{Status}");
                    // convert stringbuilder to string
                    string writeLine = line.ToString();
                    // write to file.fgz
                    await writer.WriteLineAsync(writeLine);
                }
            }
            // download file.fgz
            return File(stream.ToArray(), "text/plain", "records.fgz");
        }

        [HttpGet("{id}")]
        public async Task<FileResult> DownloadById(int id){
            // get information
            var fugazi = await _context.FugaziImports.FindAsync(id);

            if (fugazi != null)
            { 
                // build strings with json data
                StringBuilder PatientName = new StringBuilder(fugazi.PatientName, 25);
                PatientName.Append(' ', 25 - PatientName.Length);

                StringBuilder Address = new StringBuilder(fugazi.Address, 50);
                Address.Append(' ', 50 - Address.Length);

                StringBuilder PhoneNumber = new StringBuilder(fugazi.PhoneNumber.ToString(), 10);
                PhoneNumber.Append(' ', 10 - PhoneNumber.Length);

                StringBuilder Injury = new StringBuilder(fugazi.Injury, 30);
                Injury.Append(' ', 30 - Injury.Length);

                StringBuilder Treatment = new StringBuilder(fugazi.Treatment, 30);
                Treatment.Append(' ', 30 - Treatment.Length);

                StringBuilder Amount = new StringBuilder(fugazi.Amount.ToString(), 15);
                Amount.Append(' ', 15 - Amount.Length);

                StringBuilder Status = new StringBuilder(fugazi.Status, 10);
                Status.Append(' ', 10 - Status.Length);

                StringBuilder line = new StringBuilder("", 170);
                line.Append($"{PatientName}{Address}{PhoneNumber}{Injury}{Treatment}{Amount}{Status}");
                // convert stringbuilder to string
                string file = line.ToString();
                // write to file.fgz
                // download file.fgz
                return File(Encoding.UTF8.GetBytes(file), "text/plain", $"record{id}.fgz");
            }

            return File(Encoding.UTF8.GetBytes($"No record of given id {id}"), "text/plain", $"error.fgz");
        }
    }
}