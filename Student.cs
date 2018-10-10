using System;

namespace LinqPractice
{
    public class Student
    {
        public int StudentID {get; set;}

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public string Classification {get; set;}

        public bool Taken3350 {get;set;}

        public override string ToString()
        {
            return $"{FirstName} - {LastName} - {Classification}";
        }
    }
}