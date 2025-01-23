using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
    public class Pessoa
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set;}
    }
}