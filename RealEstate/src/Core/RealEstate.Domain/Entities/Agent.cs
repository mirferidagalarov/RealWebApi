using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Agent:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email {  get; set; }  
        public string Phone { get; set; }
        public string ImagePath {  get; set; }
        public decimal Rate {  get; set; }
        public DateTime? AnsweredAt { get; set; }
        public int? AnsweredBy { get; set; }
    }
}
