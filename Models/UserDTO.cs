using System;
using System.Collections.Generic;
using Api.Data.Collections;
namespace Api.Models
{
    public class UserDTO
    {
        public string UserName { get; set;}

        public string Email { get; set;}

        public string Password { get; set;}

        public DateTime Birthday { get; set;}

        public int ProblemsSolved { get; set;}

        public List<ProblemDTO> Problems {get; set;}
    }
}