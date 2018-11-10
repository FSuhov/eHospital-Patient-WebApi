using PatientBO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientDA
{
    public interface IPatientData
    {
        IEnumerable<Image> GetImages();
        IEnumerable<PatientInfo> GetPatients();

        Image GetImage(int id);
        void AddImage(Image image);

        PatientInfo GetPatient(int id);
        void AddPatient(PatientInfo patient);

        void Save();
    }
}
