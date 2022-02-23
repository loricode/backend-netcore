using System.ComponentModel.DataAnnotations;
using System;

namespace Backend.Demo.Entidades
{
    public class Configuracion
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string valor { get; set; }
    }
}