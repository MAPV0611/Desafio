using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Desafio.Models
{
    public class Personas
    {
        public int ID_PERSONAS { get; set; }
        public string Nombre { get; set; }
        public char A_Paterno { get; set; }
        public char A_Materno { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }

    }
    public class PersonasDBContext : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
    }

    public ActionResult Create([Bind(Include = "Nombre,A_Paterno,A_Materno,Edad,Activo")] Persona)
    {
        try
        {
            if (System.Web.ModelBinding.ModelState.IsValid)
            {
                Personas.Add(Persona);
                SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.
            System.Web.ModelBinding.ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        }
        return View(Persona);
    }