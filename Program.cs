using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Alexander",
                    LastName = "McDonald",
                    Classification = "Junior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Laith",
                    LastName = "Alfaloujeh",
                    Classification = "Junior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Mekkala",
                    LastName = "Bourapa",
                    Classification = "Junior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Charles",
                    LastName = "Coufal",
                    Classification = "Junior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "John",
                    LastName = "Cunningham",
                    Classification = "Junior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Michael",
                    LastName = "Hayes",
                    Classification = "Junior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Aaron",
                    LastName = "Hebert",
                    Classification = "Senior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Yi Fu",
                    LastName = "Ji",
                    Classification = "Senior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Todd",
                    LastName = "Kile",
                    Classification = "Senior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Mara",
                    LastName = "Kinoff",
                    Classification = "Senior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Cesareo",
                    LastName = "Lona",
                    Classification = "Senior",
                    Taken3350 = true,
                },
                new Student()
                {
                    FirstName = "Michael",
                    LastName = "Matthews",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Mason",
                    LastName = "McCollum",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Phelps",
                    LastName = "Merrell",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Quan",
                    LastName = "Nguyen",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Alexander",
                    LastName = "Roder",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Amy",
                    LastName = "Saysouriyosack",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Claudia",
                    LastName = "Silva",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Gabriela",
                    LastName = "Valenzuela",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Kayla",
                    LastName = "Washington",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Matthew",
                    LastName = "Webb",
                    Classification = "Senior",
                    Taken3350 = false,
                },
                new Student()
                {
                    FirstName = "Cory",
                    LastName = "Williams",
                    Classification = "Senior",
                    Taken3350 = false,
                },
            };
            using(var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
                db.Students.AddRange(students);
                db.SaveChanges();
                var mfilter = new string[] 
                    {"M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                
                var lfilter = new string[] 
                    {"A","B","C","D","E","F","G","H","I","J","K","L"};
                //Not Senior filter
                var notseniorFiltered = students.Where(s => s.Classification != "Senior");
                Console.WriteLine("         All students who are not a Senior:");
                foreach(Student s in notseniorFiltered)
                {
                    Console.WriteLine(s);
                }
                //Taken 3350
                var taken3350Filtered = students.Where(s => s.Taken3350 = true);
                Console.WriteLine("         All Students who have taken CIDM3350:");
                foreach(Student s in taken3350Filtered)
                {
                    Console.WriteLine(s);
                }
                //M or Lower Filter
                var letterMFiltered = students.Where(s => mfilter.Any(x => s.FirstName.StartsWith(x)));
                Console.WriteLine("         All Students who have first names with m or lower:");
                foreach(Student s in letterMFiltered)
                {
                    Console.WriteLine(s);
                }
                //L or higher filter
                var letterLFiltered = students.Where(s => lfilter.Any(x => s.LastName.StartsWith(x)));
                Console.WriteLine("         All Students who have first names with m or lower:");
                foreach(Student s in letterLFiltered)
                {
                    Console.WriteLine(s);
                }

                var fnameOrdered = students.OrderBy(s => s.FirstName);
                Console.WriteLine("         Students ordered by first name:");
                foreach(Student s in fnameOrdered)
                {
                    Console.WriteLine(s);
                }

                var lnameDescending = students.OrderByDescending(s => s.LastName);
                Console.WriteLine("         Students ordered by Last Name in Descending Order:");
                foreach(Student s in lnameDescending)
                {
                    Console.WriteLine(s);
                }

                var rankSorted = students.OrderBy(s => s.Classification);
                Console.WriteLine("         Students ordered by classification");
                foreach(Student s in rankSorted)
                {
                    Console.WriteLine(s);
                }

                var seniorLname = from s in students
                                    where s.Classification == "Senior"
                                    orderby s.LastName
                                    select s;
                Console.WriteLine("        Seniors ordered by last name:");
                foreach(Student s in seniorLname)
                {
                    Console.WriteLine(s);
                }

                var notSeniorFname = from s in students
                                    where s.Classification != "Senior"
                                    orderby s.FirstName
                                    select s;
                Console.WriteLine("         Juniors ordered by first name:");
                foreach(Student s in notSeniorFname)
                {
                    Console.WriteLine(s);
                }

                var groupedbyClassification = from s in students
                                                group s by s.Classification into g
                                                orderby g.Key
                                                select g;
                
                Console.WriteLine("         All Students grouped by Classification");
                foreach(Student s in groupedbyClassification)
                {
                    Console.WriteLine(s);
                }
                
            }
        }
                
            


    }
}

