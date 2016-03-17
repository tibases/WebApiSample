using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRESTFul.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}