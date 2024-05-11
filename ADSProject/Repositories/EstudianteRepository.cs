﻿using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        /*private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
               new Estudiante{ IdEstudiante = 1, NombresEstudiante = "JUAN CARLOS",
               ApellidosEstudiante = "PEREZ SOSA", CodigoEstudiante = "PS24-I04-002",
               CorreoEstudiante = "PS24I04002@usonsonate.edu.sv"
               }
         };*/
        private readonly ApplicationDbContext applicationDbContext;
        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                //int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //lstEstudiantes[indice] = estudiante;
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);
                applicationDbContext.SaveChanges();
                return idEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                /*if (lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                }
                lstEstudiantes.Add(estudiante);*/
                applicationDbContext.Estudiantes.Add(estudiante);
                applicationDbContext.SaveChanges();
                return estudiante.IdEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                /*int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                lstEstudiantes.RemoveAt(indice);*/
                var iteam = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Estudiantes.Remove(iteam);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                //Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);
                var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                return estudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                //return lstEstudiantes;
                return applicationDbContext.Estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
