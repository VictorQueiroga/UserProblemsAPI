using System;

namespace Api.Models
{
    public class ProblemDTO
    {
        public string Title { get;  set;}

        public string Description { get; set;}

        public DateTime PostDate { get;  set;}

        public Boolean IsSolved { get; set;}

    }
}