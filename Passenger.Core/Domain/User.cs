using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string Role {get; protected set; }

        protected User()
        {
        }

        public User(string email, string username, string password, string salt, string role)
        {
            Id = Guid.NewGuid();
            try
            {
                MailAddress m = new MailAddress(email);

            }
            catch (FormatException)
            {
                return;
            }
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
            Role = role;
        }
    }
}