using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntro.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        public byte Age { get; set; }
        public bool IsMarried { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Position")]
        public int PositinId { get; set; }
        public Position Position { get; set; }
    }
}
