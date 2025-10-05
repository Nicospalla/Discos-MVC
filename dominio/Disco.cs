using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El titulo del disco es requerido")]
        public string Titulo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        [DisplayName("Imagen"), Required(ErrorMessage ="Debe insertar una imagen para el disco")]
        public string UrlTapa { get; set; }
        public Estilo Estilo { get; set; }
        [DisplayName("Edicion")]
        public TipoEdicion TipoEdicion { get; set; }
    }
}
