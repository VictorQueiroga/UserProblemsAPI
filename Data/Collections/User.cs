using System;
using System.Collections.Generic;
using Api.Models;


namespace Api.Data.Collections
{
    public class User
    {
        public string UserName { get; private set;}

        public string Email { get; private set;}

        public string Password { get; private set;}

        public DateTime Birthday { get; private set;}

        public int ProblemsSolved { get; private set;}
        
        public List<Problem> Problems = new List<Problem>();

        public User(string userName, string email, string password, DateTime birthday, int problemsSolved,List<ProblemDTO> problems){
             this.UserName = userName;
             this.Email = email;
             this.Password = password;
             this.Birthday = birthday;
             this.ProblemsSolved = problemsSolved;
             foreach(ProblemDTO problem in problems){
                 this.Problems.Add(new Problem(problem.Title,problem.Description,problem.PostDate,problem.IsSolved));
             }
        }
    }
}