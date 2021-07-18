using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace interciclolituma.Entities
{
    public class persona
    {
        [Key]
        public string id_p { get; set; }
        public string user_p { get; set; }
        public string nomb_p { get; set; }
        public string password { get; set; }
        public DateTime fecha_p { get; set; }

    }
}
