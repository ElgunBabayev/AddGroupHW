using System.Collections.Generic;
using System;

namespace ConsoleAppHW
{
    class Group
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        private List<Student> Students { get; set; }
        List<MarkCollection> Studentmarks { get; set; }

        public int StudentCount
        { get 
            {
                int result = 0;
                foreach (Student item in Students)
                {
                    result += item.StudentCount;
                }
                return result;

            } 
        }


        private static int count;
        public readonly int Id;

        private Group()
        {
            count++;
            Id = count;
            Students = new List<Student>();
        }

        public Group(string name, string teacher ) : this()
        {
            Name = name;
            
            Teacher = teacher;
        }

        public override string ToString()
        {
            return $"Group: {Id} - Name: {Name} Teacher name {Teacher} Student Count: {Students.Count}";
        }
        public override bool Equals(object obj)
        {
            return Name == ((Group)obj).Name;   
        }
        public bool AddStudent(Student student)
        {
            if (Students.Contains(student))
            {
                return false;
            }

            Students.Add(student);
            return true;
        }

        public bool AddStudentMark(MarkCollection mark)
        {
            if (Studentmarks.Contains(mark))
            {
                return false;
            }

            Studentmarks.Add(mark);
            return true;
        }
        public void PrintAllStudents()
        {
            foreach (Student item in Students)
            {
                Console.WriteLine($"{Name}-deki {item}");
            }
        }

        public void SearchAndPrintStudent(string query)
        {
            bool resultFound = false;
            foreach (Student item in Students)
            {
                if (item.Name.Contains(query) || item.Surname.Contains(query))
                {
                    Console.WriteLine($"{item} in {Name}");
                    resultFound = true;
                }
            }

            if (!resultFound)
            {
                Console.WriteLine($"No results found in {Name}.");
            }
        }



    }
}
