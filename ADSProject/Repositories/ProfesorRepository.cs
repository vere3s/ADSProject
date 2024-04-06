using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> lstProfesores = new List<Profesor>
        {
           new Profesor
           {
               IdProfesor = 1, NombresProfesor = "José Dimas",
               ApellidosProfesor = "Carabantes García", Email="josedimas@gmail.com"
           }
        };
        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                int indice = lstProfesores.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesores[indice] = profesor;
                return idProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                if (lstProfesores.Count > 0)
                {
                    profesor.IdProfesor = lstProfesores.Last().IdProfesor + 1;
                }
                lstProfesores.Add(profesor);
                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                int indice = lstProfesores.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesores.RemoveAt(indice);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {
                Profesor profesor = lstProfesores.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);
                return profesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return lstProfesores;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
