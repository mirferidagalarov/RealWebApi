using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Announcement:BaseEntity<int>
    {
        public string Title {  get; set; }
        public int Type {  get; set; }
        public int CategoryId {  get; set; }    
        public int CityId {  get; set; }
        public string Address {  get; set; }    
        public string Description {  get; set; }    
        public string Phone {  get; set; }  
        public string Email {  get; set; }
        public decimal Price {  get; set; }
        public int PriceUnit {  get; set; }
        public bool FromAgent {  get; set; }    

    }
}
