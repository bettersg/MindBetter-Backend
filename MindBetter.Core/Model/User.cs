using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public User(string email, string userName, string firstName, string lastName)
        {
            Email = email;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
