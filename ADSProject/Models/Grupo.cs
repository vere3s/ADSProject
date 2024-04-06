﻿using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Anio { get; set; }
    }
}
