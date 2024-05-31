using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        /*private List<Grupo> lstGrupos = new List<Grupo>
        {
           new Grupo
           {
               IdGrupo = 1, IdCarrera = 1, IdMateria = 1,
               IdProfesor = 1, Ciclo = 1, Anio =2024
           }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                //int indice = lstGrupos.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                //lstGrupos[indice] = grupo;
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                if (item == null)
                {
                    throw new InvalidOperationException($"El grupo con Id {idGrupo} no existe.");
                }

                // Actualiza solo las propiedades que pueden ser modificadas.
                item.IdCarrera = grupo.IdCarrera;
                item.IdMateria = grupo.IdMateria;
                item.IdProfesor = grupo.IdProfesor;
                item.Ciclo = grupo.Ciclo;
                item.Anio = grupo.Anio;

                applicationDbContext.SaveChanges();
                return idGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                /*if (lstGrupos.Count > 0)
                {
                    grupo.IdGrupo = lstGrupos.Last().IdGrupo + 1;
                }
                lstGrupos.Add(grupo);*/
                applicationDbContext.Grupos.Add(grupo);
                applicationDbContext.SaveChanges();
                return grupo.IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                //int indice = lstGrupos.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                //lstGrupos.RemoveAt(indice);
                var iteam = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);
                applicationDbContext.Grupos.Remove(iteam);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                //Grupo grupo = lstGrupos.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);
                var grupo = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                //return lstGrupos;
                return applicationDbContext.Grupos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
