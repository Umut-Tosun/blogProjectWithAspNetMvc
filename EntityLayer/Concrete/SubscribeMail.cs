using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubscribeMail
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        public string Mail { get; set; }
        
    }
}
