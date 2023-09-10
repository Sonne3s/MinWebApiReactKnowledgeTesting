using System.ComponentModel.DataAnnotations;

namespace AdminAPI.Models
{
    public class UserRegistration
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public void Deconstruct(out string? login, out string? password, out string? firstName, out string? lastName, out string? middleName)
        {
            login = this.Login;
            password = this.Password;
            firstName = this.FirstName;
            lastName = this.LastName;
            middleName = this.MiddleName;
        }
    }
}
