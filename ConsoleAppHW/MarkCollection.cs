using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppHW
{
    class MarkCollection 
    {
        public int Exam1Mark { get; set; }
        public int Exam2Mark { get; set; }



        public MarkCollection(int mark1, int mark2)
        {
            Exam1Mark = mark1;
            Exam2Mark = mark2;

        }
        

        List<MarkCollection> studentmarks = new List<MarkCollection>();

        
    }
}
