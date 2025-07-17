using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class ContactPost:BaseEntity<int>
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Message {  get; set; }    
        public string Answer { get; set; }  
        public DateTime? AnsweredAt { get; set; }
        public int? AnsweredBy {  get; set; }   
    }
}
