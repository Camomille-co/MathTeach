using DataLayer.Entities;

namespace MathTeach.Models
{
    public class RegisterModel
    {
        public string FIO { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string RoleId { get; set; }

        public Roles Roles { get; set; }
    }
}
