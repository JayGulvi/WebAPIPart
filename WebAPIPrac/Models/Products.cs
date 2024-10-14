using System.ComponentModel.DataAnnotations;

namespace WebAPIPrac.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Pname {  get; set; }
        public string Pcat {  get; set; }
        public string Price { get; set; }   
    }
}
