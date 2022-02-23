using System.ComponentModel.DataAnnotations;
using System;

namespace Backend.Demo.Entidades
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public string Identificacion { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string TelefonoOtros { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }
        //yyyy-MM-dd
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaAfiliacion { get; set; }

        [Required]
    
        public char Sexo { get; set; }

        [Required]
        [StringLength(200)]
        public string ResenaPersonal { get; set; }
        
        public string Imagen { get; set; }

        [Required]
        public char Intereses { get; set; }


    }
}
