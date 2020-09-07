using System;

namespace Api.Data.Collections
{
    public class Problem
    {
        public string Title { get; private set;}

        public string Description { get; private set;}

        public DateTime PostDate { get; private set;}

        public Boolean IsSolved { get; private set;}

        public Problem(string title, string description, DateTime postDate, Boolean isSolved){
             this.Title = title;
             this.Description = description;
             this.PostDate = postDate;
             this.IsSolved = isSolved;
        }
    }
}