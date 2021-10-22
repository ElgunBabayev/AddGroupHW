using System;
using System.Collections.Generic;

namespace ConsoleAppHW
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Group> groupContext = new List<Group>();
            List<MarkCollection> studentMarks = new List<MarkCollection>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Menu: 1 - Add Group | 2 - Add Student | 3 - Add Student Mark | 4 - View Student List | 5 - Find Student | 6 - Delete Group | exit");
                Console.ResetColor();

                string userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "exit")
                {
                    break;
                }

                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);

                if (selectionIsValid && selection >= 1 && selection <= 6)
                {
                    switch (selection)
                    {
                        case (int)AppMenuSelection.AddGroup:

                            Console.Write("Enter group name: ");
                            string groupName = Console.ReadLine();
                            if (string.IsNullOrEmpty(groupName))
                            {
                                Console.WriteLine("Group name invalid.");
                                break;
                            }

                            Console.Write("Enter group teacher name: ");
                            string groupTeacher = Console.ReadLine();
                            if (string.IsNullOrEmpty(groupTeacher))
                            {
                                Console.WriteLine("Teacher name invalid.");
                                break;
                            }

                           

                            Group newGroup = new Group(groupName, groupTeacher);

                            if (groupContext.Contains(newGroup))
                            {
                                Console.WriteLine("Group already exists.");
                                break;
                            }

                            groupContext.Add(newGroup);
                            Console.WriteLine("Group added successfully.");

                            break;

                        case (int)AppMenuSelection.AddStudent:
                            if (groupContext.Count <= 0)
                            {
                                Console.WriteLine("Add a group first.");
                                break;
                            }

                            Console.Write("Enter student name: ");
                            string studentName = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentName))
                            {
                                Console.WriteLine("Student name invalid.");
                                break;
                            }

                            Console.Write("Enter student surname: ");
                            string studentSurname = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentSurname))
                            {
                                Console.WriteLine("Student surname invalid.");
                                break;
                            }

                            Console.Write("Enter age: ");
                            int studentAge;
                            bool studentAgeIsValid = int.TryParse(Console.ReadLine(), out studentAge);
                            if (!studentAgeIsValid)
                            {
                                Console.WriteLine("Population invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the group that you want to add the student to: ");
                            int groupId;
                            bool groupIdIsValid = int.TryParse(Console.ReadLine(), out groupId);
                            if (!groupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group groupToAddStudentTo = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == groupId)
                                {
                                    groupToAddStudentTo = item;
                                }
                            }

                            if (groupToAddStudentTo == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            Student newStudent = new Student(studentName, studentSurname, studentAge);

                            if (groupToAddStudentTo.AddStudent(newStudent))
                            {
                                Console.WriteLine("Student added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student already exists.");
                            }

                            break;

                        case (int)AppMenuSelection.AddStudentMark:
                            Console.WriteLine("Enter 1st mark: ");
                            int firstmark;
                            bool firstmarkIsValid = int.TryParse(Console.ReadLine(), out firstmark);
                            if (!firstmarkIsValid)
                            {
                                Console.WriteLine("mark invalid.");
                                break;
                            }

                            Console.WriteLine("Enter 2nd mark: ");
                            int secondmark;
                            bool secondmarkIsValid = int.TryParse(Console.ReadLine(), out secondmark);
                            if (!secondmarkIsValid)
                            {
                                Console.WriteLine("mark invalid.");
                                break;
                            }

                           



                            MarkCollection studentMark = new MarkCollection(firstmark, secondmark);
                            studentMarks.Add(studentMark);
                             Console.WriteLine("StudentMarks added succesfully.");
                         break;



                            
                            

                            


                        case (int)AppMenuSelection.ViewStudentList:
                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }
                            break;

                        case (int)AppMenuSelection.FindStudent:
                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();
                            if (string.IsNullOrEmpty(usersQuery))
                            {
                                Console.WriteLine("Query invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                item.SearchAndPrintStudent(usersQuery);
                            }

                            break;



                        case (int)AppMenuSelection.DeleteGroup:

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the group that you want to delete: ");
                            int deleteGroupId;
                            bool deleteGroupIdIsValid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (!deleteGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group groupToDelete = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == deleteGroupId)
                                {
                                    groupToDelete = item;
                                }
                            }

                            if (groupToDelete == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            groupContext.Remove(groupToDelete);

                            Console.WriteLine("Group deleted successfully.");
                            break;













                            

                            
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }
        }
    }
}
