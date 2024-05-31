using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        /*private List<Materia> lstMaterias = new List<Materia>
        {
           new Materia
           {
               IdMateria = 1, NombreMateria = "ANALISIS DE SISTEMAS"
           }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                //int indice = lstMaterias.FindIndex(tmp => tmp.IdMateria == idMateria);
                //lstMaterias[indice] = materia;
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);

                if (item == null)
                {
                    throw new InvalidOperationException($"La materia con Id {idMateria} no existe.");
                }

                // Actualiza solo las propiedades que pueden ser modificadas.
                item.NombreMateria = materia.NombreMateria;

                applicationDbContext.SaveChanges();
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
                /*if (lstMaterias.Count > 0)
                {
                    materia.IdMateria = lstMaterias.Last().IdMateria + 1;
                }
                lstMaterias.Add(materia);*/
                applicationDbContext.Materias.Add(materia);
                applicationDbContext.SaveChanges();
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
                //int indice = lstMaterias.FindIndex(tmp => tmp.IdMateria == idMateria);
                //lstMaterias.RemoveAt(indice);
                var iteam = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDbContext.Materias.Remove(iteam);
                applicationDbContext.SaveChanges();
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
                //Materia materia = lstMaterias.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
                var materia = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
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
                //return lstMaterias;
                return applicationDbContext.Materias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
