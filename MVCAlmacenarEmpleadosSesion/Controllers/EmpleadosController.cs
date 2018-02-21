using MVCAlmacenarEmpleadosSesion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlmacenarEmpleadosSesion.Controllers
{
    public class EmpleadosController : Controller
    {
        ModeloHospital modelo;
        public EmpleadosController()
        {
            modelo = new ModeloHospital();
        }
        
        public ActionResult AlmacenarEmpleados(int? empno)
        {
            IQueryable<EMP> empleados = modelo.GetEmpleados();
            if (empno != null)
            {
                List<int> listaempleados;
                if (Session["EMPLEADOS"] == null)
                {
                    listaempleados = new List<int>();
                }
                else
                {
                    listaempleados = (List<int>)Session["EMPLEADOS"];
                }
                listaempleados.Add(empno.GetValueOrDefault());
                Session["EMPLEADOS"] = listaempleados;
                ViewBag.Mensaje = "Empleados almacenados: " + listaempleados.Count();
            }
            return View(empleados);
        }
        public ActionResult MostrarEmpleados()
        {
            if (Session["EMPLEADOS"] == null)
            {
                return View();
            }
            else
            {
                List<int> lista = (List<int>)Session["EMPLEADOS"];
                IQueryable empleados =
                    this.modelo.GetEmpleadosSession(lista);
                return View(empleados);
            }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}