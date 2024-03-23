using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> lstCarreras = new List<Carrera>
       {
           new Carrera
           { 
               Id = 1, Codigo = "I04-2-14", Nombre = "ANALISIS DE SISTEMAS"
           }
       };
        public int ActualizarCarrera(int id, Carrera carrera)
        {
            try
            {
                int indice = lstCarreras.FindIndex(tmp => tmp.Id == id);
                lstCarreras[indice] = carrera;
                return id;
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
                if (lstCarreras.Count > 0)
                {
                    carrera.Id = lstCarreras.Last().Id + 1;
                }
                lstCarreras.Add(carrera);
                return carrera.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int id)
        {
            try
            {
                int indice = lstCarreras.FindIndex(tmp => tmp.Id == id);
                lstCarreras.RemoveAt(indice);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carrera ObtenerCarreraPorID(int id)
        {
            try
            {
                Carrera carrera = lstCarreras.FirstOrDefault(tmp => tmp.Id == id);
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
                return lstCarreras;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
