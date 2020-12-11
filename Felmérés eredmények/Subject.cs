using System.Collections.Generic;
using System.Linq;

namespace Felmérés_eredmények
{
    public class Subject
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        internal List<SubjectState> SubjectStates { get; }

        public Subject(string firstName, string lastName, string birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDay;
            SubjectStates = new List<SubjectState>();
        }

        public Subject(int? id, string firstName, string lastName, string birthDay) : this(firstName, lastName, birthDay)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName}  [{SubjectStates.Count()} alkalom]"; 
        }
    }
}
