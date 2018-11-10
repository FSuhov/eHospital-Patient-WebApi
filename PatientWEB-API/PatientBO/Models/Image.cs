using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientBO.Models
{
    /// <summary>
    /// Class representing Image if Patient
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets a Unique number to identify the book and store in the Database
        /// </summary>
        [Key]
        public int ImageId { get; set; }

        /// <summary>
        /// Gets or sets the name of Image
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets the content of Image file
        /// </summary>
        public byte[] ImageContent { get; set; }
    }
}
