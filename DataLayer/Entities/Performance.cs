using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Performance
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int UserId { get; set; }

        public int Grade { get; set; }

        public Lesson Lesson { get; set; }

        public User Users { get; set; }
    }
}
