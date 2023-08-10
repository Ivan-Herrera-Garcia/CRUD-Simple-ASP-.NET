using Rotativa.AspNetCore;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SpreadsheetLight;

namespace Examen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExamenContext _dbcontext;

        public HomeController(ExamenContext _context)
        {
            _dbcontext = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PDF(int id)
        {
            Dato data = _dbcontext.Datos.Select(v => new Dato()
                {
                    Nombre = v.Nombre,
                    Altura = v.Altura,
                    ApeMaterno = v.ApeMaterno,
                    ApePaterno = v.ApePaterno,
                    Edad = v.Edad,
                    Id = v.Id,
                    Correo = v.Correo,
                    Sexo = v.Sexo,
                }).FirstOrDefault();
                    
        return new ViewAsPdf("PDF", data)
            { 

                FileName = $"Archivo_{data.Id}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        public IActionResult CVS(int id)
        {
            Dato data = _dbcontext.Datos.Select(v => new Dato()
            {
                Nombre = v.Nombre,
                Altura = v.Altura,
                ApeMaterno = v.ApeMaterno,
                ApePaterno = v.ApePaterno,
                Edad = v.Edad,
                Id = v.Id,
                Correo = v.Correo,
                Sexo = v.Sexo,
            }).FirstOrDefault();

            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "miExcel.xlsx";

            SLDocument oSLDocument = new SLDocument();

            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Ap. Paterno", typeof(string));
            dt.Columns.Add("Ap. Materno", typeof(string));
            dt.Columns.Add("Edad", typeof(string));
            dt.Columns.Add("Altura", typeof (string));
            dt.Columns.Add("Correo", typeof(string));
            dt.Columns.Add("Sexo", typeof(string));

            dt.Rows.Add(data.Id, data.Nombre, data.ApePaterno, data.ApeMaterno, data.Edad, data.Altura, data.Correo, data.Sexo);

            oSLDocument.ImportDataTable(1, 1, dt, true);
            oSLDocument.SaveAs(pathFile);

            return Index();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}