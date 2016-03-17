using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public class User : Entities.BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }


}
