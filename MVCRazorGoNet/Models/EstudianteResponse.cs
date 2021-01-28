using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRazorGoNet.Models
{
    public class EstudianteResponse
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public int TotalElements { get; set; }
        public ICollection<Estudiante> ListEstudiante { get; set; }
    }
}