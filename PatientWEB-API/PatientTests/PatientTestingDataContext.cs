﻿using PatientBO.Models;
using PatientDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientTests
{
    public class PatientTestingDataContext : IPatientData
    {
        public virtual List<PatientInfo> Patients { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual List<Appointment> Appointments { get; set; }

        public void AddImage(Image image)
        {
            Images.Add(image);
            Save();
        }
        
        public void AddPatient(PatientInfo patient)
        {
            Patients.Add(patient);
            Save();
        }
        
        public Image GetImage(int id)
        {
            return Images.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Image> GetImages()
        {
            return Images.ToList();
        }
                
        public PatientInfo GetPatient(int id)
        {
            return Patients.FirstOrDefault(p => p.Id == id);
        }
        
        public IEnumerable<PatientInfo> GetPatients()
        {
            return Patients.ToList();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return Appointments.ToList();
        }
        
        public void Save()
        {
            return;
        }
    }
}
