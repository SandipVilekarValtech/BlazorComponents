using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorComponents.Shared
{
    public class AuthorDto
    {
        public Int32 Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime Birthdate { get; set; }

        public DateTime Added { get; set; }
    }
}
