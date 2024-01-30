using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int UserId { get; set; }

        public bool Present { get; set; }

        public Lesson Lesson { get; set; }

        public User Users { get; set; }
    }
}
