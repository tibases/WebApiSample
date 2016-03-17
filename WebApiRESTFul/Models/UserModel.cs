using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApiRESTFul.Models
{
    public class UserModel : BaseModel
    {

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<PhoneModel> Phones { get; set; }

    }
}