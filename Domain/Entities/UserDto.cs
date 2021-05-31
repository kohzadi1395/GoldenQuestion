using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfileImage { get; set; }

        public Guid GenderId { get; set; }

        public Comment Comment { get; set; }
    }
}
