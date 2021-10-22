using System.Collections.Generic;

namespace ConsoleAppHW
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int StudentCount { get; set; }

        public MarkCollection Mark;

        
        public int Age { get; set; }


        private static int count;
        public readonly int Id;


        private Student()
        {
            count++;
            Id = count;
        }
        public Student(string name, string surname, int age) : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
           
        }
        public override string ToString()
        {
            return $"Student: {Id} - Name: {Name} Surname: {Surname} Age {Age} Final Mark {Mark}";
        }

        public override bool Equals(object obj)
        {
            return Name == ((Student)obj).Name && Surname == ((Student)obj).Surname;
        }

    }
}
