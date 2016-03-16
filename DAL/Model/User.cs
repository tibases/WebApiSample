
using System.Collections.Generic;
namespace DAL.Model
{
    public class User : Entities.BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
    }


}
