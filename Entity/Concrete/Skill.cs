using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string SkillName { get; set; }
        public int Range { get; set; }
    }
}
