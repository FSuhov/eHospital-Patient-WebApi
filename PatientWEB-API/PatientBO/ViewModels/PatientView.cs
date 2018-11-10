using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBO.ViewModels
{
    /// <summary>
    /// Represents an entity for short representation of PatientInfo
    /// </summary>
    public class PatientView
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
