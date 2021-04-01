using System.ComponentModel.DataAnnotations;

namespace NuevaApi.Models
{
    public class NuevaItem
    {
        public long Id { get; set; }
        
        [MaxLength(20)] 
        public string Nombre { get; set; }
       
        [MaxLength(20)] 
        public string Apellido { get; set; }

        [Range(0,9999999999)]
        public int Identificacion { get; set; }

        [Range(0,99)]
        public int edad { get; set; }
        
// Gryffindor, "Hufflepuff", "Ravenclaw", "Slytherin"
        [MaxLength(10)] 
        public string casa { get; set; }

    
    
    }


}