using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Roles
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public List<User> Users { get; set; }

        public Roles() 
        {
            Users = new List<User>();
        }

    }
}
