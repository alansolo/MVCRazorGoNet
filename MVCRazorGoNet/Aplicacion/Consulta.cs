using MediatR;
using MVCRazorGoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVCRazorGoNet.Aplicacion
{
    public class Consulta
    {
        public class ListEstudiantes: IRequest<EstudianteResponse>
        {
            public Estudiante Estudiante { get; set; }
        }

        public class Manejador : IRequestHandler<ListEstudiantes, EstudianteResponse>
        {
            public async Task<EstudianteResponse> Handle(ListEstudiantes request, CancellationToken cancellationToken)
            {

                EstudianteResponse EstudianteRes = new EstudianteResponse();

                try
                {
                    ////////////////////////////////
                    //AGREGAR INFORMACION A LA LISTA
                    List<Estudiante> ListEstudiante = new List<Estudiante>();
                    
                    Estudiante estudiante1 = new Estudiante("2005", "", "", "", "Ingenieria", 20);
                    estudiante1.NumMatricula = estudiante1.NumMatricula + "2356";
                    estudiante1.Nombre = "Luis";
                    estudiante1.ApellidoPaterno = "Marquez";
                    estudiante1.ApellidoMaterno = "Toris";
                    ListEstudiante.Add(estudiante1);

                    Estudiante estudiante2 = estudiante1.DeepCopy();
                    estudiante2.NumMatricula = estudiante1.NumMatricula + "1189";
                    estudiante2.Nombre = "Marlen";
                    estudiante2.ApellidoPaterno = "Monarca";
                    estudiante2.ApellidoMaterno = "Montemayor";
                    ListEstudiante.Add(estudiante2);

                    Estudiante estudiante3 = estudiante1.DeepCopy();
                    estudiante3.NumMatricula = estudiante1.NumMatricula + "7800";
                    estudiante3.Nombre = "Gabriel";
                    estudiante3.ApellidoPaterno = "Gomez";
                    estudiante3.ApellidoMaterno = "Juarez";
                    ListEstudiante.Add(estudiante3);

                    Estudiante estudiante4 = new Estudiante("2006", "", "", "", "Licenciatura", 20);
                    estudiante4.NumMatricula = estudiante1.NumMatricula + "1123";
                    estudiante4.Nombre = "Nadia";
                    estudiante4.ApellidoPaterno = "Morales";
                    estudiante4.ApellidoMaterno = "Campos";
                    ListEstudiante.Add(estudiante4);

                    Estudiante estudiante5 = estudiante4.DeepCopy();
                    estudiante5.NumMatricula = estudiante1.NumMatricula + "0156";
                    estudiante5.Nombre = "Carlos";
                    estudiante5.ApellidoPaterno = "Camarena";
                    estudiante5.ApellidoMaterno = "Lugo";
                    ListEstudiante.Add(estudiante5);


                    ////////////////////////////
                    //REALIZAR FILTRO
                    if (!string.IsNullOrEmpty(request.Estudiante.NumMatricula))
                    {
                        ListEstudiante = ListEstudiante.Where(n => n.NumMatricula.ToUpper() == request.Estudiante.NumMatricula.ToUpper()).ToList();
                    }
                    if(!string.IsNullOrEmpty(request.Estudiante.Nombre))
                    {
                        ListEstudiante = ListEstudiante.Where(n => n.Nombre.ToUpper() == request.Estudiante.Nombre.ToUpper()).ToList();
                    }
                    if(!string.IsNullOrEmpty(request.Estudiante.ApellidoPaterno))
                    {
                        ListEstudiante = ListEstudiante.Where(n => n.ApellidoPaterno.ToUpper() == request.Estudiante.ApellidoPaterno.ToUpper()).ToList();
                    }
                    if(!string.IsNullOrEmpty(request.Estudiante.ApellidoMaterno))
                    {
                        ListEstudiante = ListEstudiante.Where(n => n.ApellidoMaterno.ToUpper() == request.Estudiante.ApellidoMaterno.ToUpper()).ToList();
                    }
                    if(!string.IsNullOrEmpty(request.Estudiante.Carrera))
                    {
                        ListEstudiante = ListEstudiante.Where(n => n.Carrera.ToUpper() == request.Estudiante.Carrera.ToUpper()).ToList();
                    }
                    if(request.Estudiante.Edad > 0)
                    {
                        ListEstudiante = ListEstudiante.Where(n => n.Edad == request.Estudiante.Edad).ToList();
                    }

                    EstudianteRes.ListEstudiante = ListEstudiante;
                    EstudianteRes.TotalElements = ListEstudiante.Count();
                    EstudianteRes.Success = true;
                    EstudianteRes.ErrorCode = 200;
                    EstudianteRes.ErrorMsg = string.Empty;
                }
                catch (Exception ex)
                {
                    EstudianteRes.ListEstudiante = new List<Estudiante>();
                    EstudianteRes.TotalElements = 0;
                    EstudianteRes.Success = false;
                    EstudianteRes.ErrorCode = 500;
                    EstudianteRes.ErrorMsg = "Server Error";
                }

                return EstudianteRes;
            }
        }
    }
}