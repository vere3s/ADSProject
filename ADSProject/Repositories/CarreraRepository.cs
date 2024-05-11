using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*private List<Carrera> lstCarreras = new List<Carrera>
       {
           new Carrera
           { 
               IdCarrera = 1, CodigoCarrera = "I04", NombreCarrera = "INGENIERIA EN SISTEMAS"
           }
       };*/
        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                //int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                //lstCarreras[indice] = carrera;
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                applicationDbContext.SaveChanges();
                return idCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                /*if (lstCarreras.Count > 0)
                {
                    carrera.IdCarrera = lstCarreras.Last().IdCarrera + 1;
                }
                lstCarreras.Add(carrera);*/
                applicationDbContext.Carreras.Add(carrera);
                applicationDbContext.SaveChanges();
                return carrera.IdCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                //int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                //lstCarreras.RemoveAt(indice);
                var iteam = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Carreras.Remove(iteam);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carrera ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                //Carrera carrera = lstCarreras.FirstOrDefault(tmp => tmp.IdCarrera == idCarrera);
                var carrera = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                return carrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerTodasLasCarreras()
        {
            try
            {
                //return lstCarreras;
                return applicationDbContext.Carreras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
