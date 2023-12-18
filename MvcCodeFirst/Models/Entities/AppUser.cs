using MvcCodeFirst.Models.Entities.Enums;

namespace MvcCodeFirst.Models.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public Gender Gender { get; set; }
    }
}
