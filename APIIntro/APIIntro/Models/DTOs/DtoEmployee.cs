using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntro.Models.DTOs
{
    public class DtoEmployee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        public byte Age { get; set; }
        public bool IsMarried { get; set; }
        [ForeignKey("Position")]
        public int PositinId { get; set; }
        public object Position { get; set; }
    }
}
