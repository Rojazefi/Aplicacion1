using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Alumnos", new { area = "Escuela1" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewData["Nombre"] = "Ronald Zegarra";
            ViewBag.Message = "Controlador de Contactos";


            return View();
        }

        public ActionResult ReportsAlumnos()
        {
            List<tb_Alumno > todoAlumno = new List<tb_Alumno >();
            using (EscuelaDBEntities2  dc = new EscuelaDBEntities2 ())
            {
                todoAlumno  = dc.tb_Alumno.ToList();
            }
            return View(todoAlumno );
        }

          

        public ActionResult ExportReport() {
            List<tb_Alumno> todoAlumno = new List<tb_Alumno>();
            using (EscuelaDBEntities2 dc = new EscuelaDBEntities2())
            {
                todoAlumno = dc.tb_Alumno.ToList();
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            //rd.SetDataSource(todoAlumno);
            rd.SetDataSource(todoAlumno );
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream .Seek (0,SeekOrigin.Begin);
                return File(stream ,"aplication/pdf","Alumnos.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}
