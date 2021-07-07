using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBO.ViewModels
{
    /// <summary>
    /// Represents an entity for short representation of PatientInfo
    /// </summary>
    public class PatientView : IComparable<PatientView>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(PatientView other)
        {
            return (this.LastName + this.FirstName).ToLower().CompareTo((other.LastName + other.FirstName).ToLower());
        }
    }
}
