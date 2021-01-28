using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRazorGoNet.Models
{
    interface IPrototype<T>
    {
        T DeepCopy();
    }
    public class Estudiante : IPrototype<Estudiante>
    {
        [Display(Name = "Numero Matricula:")]
        public string NumMatricula { get; set; }
        [Display(Name = "Nombre:          ")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno:")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno:")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Carrera:         ")]
        public string Carrera { get; set; }
        [Display(Name = "Edad:            ")]
        public int? Edad { get; set; }
        public Estudiante()
        {
        }
        public Estudiante(string numMatricula, string nombre, string apellidoPaterno, string apellidoMaterno, string carrera, int? edad)
        {
            this.NumMatricula = numMatricula;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.Carrera = carrera;
            this.Edad = edad;
        }
        public Estudiante DeepCopy()
        {
            return new Estudiante(NumMatricula, Nombre, ApellidoPaterno, ApellidoMaterno, Carrera, Edad);
        }
    }
}