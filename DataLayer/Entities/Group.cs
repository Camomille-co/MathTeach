using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }
}
