using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMaterias = new List<Materia>
        {
           new Materia
           {
               IdMateria = 1, NombreMateria = "ANALISIS DE SISTEMAS"
           }
        };
        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                int indice = lstMaterias.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMaterias[indice] = materia;
                return idMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (lstMaterias.Count > 0)
                {
                    materia.IdMateria = lstMaterias.Last().IdMateria + 1;
                }
                lstMaterias.Add(materia);
                return materia.IdMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                int indice = lstMaterias.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMaterias.RemoveAt(indice);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Materia ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                Materia materia = lstMaterias.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
                return materia;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                return lstMaterias;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
