using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Lesson
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int GroupId { get; set; }

        public List<Group> Groups { get; set; }
    }
}
