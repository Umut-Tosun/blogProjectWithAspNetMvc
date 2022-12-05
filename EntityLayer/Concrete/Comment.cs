using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Comment
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Mail { get; set; }
        [StringLength(2000)]
        public string CommentText { get; set; }
        public DateTime DateTime { get; set; }
        public int BlogRating { get; set; }
        public bool isRead { get; set; }

        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
