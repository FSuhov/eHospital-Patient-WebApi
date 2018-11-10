﻿using AutoMapper;
using PatientBO.Models;
using PatientBO.ViewModels;
using PatientDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientBL.Services
{
    public class PatientInfoService : IPatientService
    {
        private IPatientData _data;
        private readonly IMapper _mapper;
        public PatientInfoService() { }

        public PatientInfoService(IPatientData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the collection of PatientInfos existing in the database.
        /// </summary>
        /// <returns> The collection of PatientView objects.</returns>
        public IEnumerable<PatientView> GetPatients()
        {
            IEnumerable<PatientInfo> patients = _data.GetPatients();
            var result = _mapper.Map<IEnumerable<PatientInfo>, IEnumerable<PatientView>>(patients);
            return result;
        }

        /// <summary>
        /// Gets the collection of PatientInfos that had appointments recently.
        /// </summary>
        /// <returns> The collection of PatientView objects.</returns>
        public IEnumerable<PatientView> GetRecentPatients()
        {
            // TODO: Implement search throw PatientAppoinment table when available

            IEnumerable<PatientInfo> patients = _data.GetPatients();
            var result = _mapper.Map<IEnumerable<PatientInfo>, IEnumerable<PatientView>>(patients);
            return result;
        }

        /// <summary>
        /// Looks for PatientInfo object with requested Id
        /// </summary>
        /// <param name="patientId">Id of PatientInfo to look for</param>
        /// <returns>PatientInfo object with specified Id or NULL if not found</returns>
        public PatientInfo GetPatientById(int patientId)
        {
            return _data.GetPatient(patientId);
        }

        /// <summary>
        /// Looks for PatientInfos matching the user input by FirstName or LastName 
        /// </summary>
        /// <param name="input">Text entered by User if "search"field</param>
        /// <returns>Collection of PatientView objects matching the query text</returns>
        public IEnumerable<PatientView> GetPatientsByText(string input)
        {
            var result = _data.GetPatients().Where(p => p.FirstName.Contains(input) || p.LastName.Contains(input));
            var viewResult = _mapper.Map<IEnumerable<PatientInfo>, IEnumerable<PatientView>>(result);
            return viewResult;
        }

        /// <summary>
        /// Adds PatientInfo object to the database
        /// </summary>
        /// <param name="patient">New PatientInfo object</param>
        public void AddPatient(PatientInfo patient)
        {
            _data.AddPatient(patient);
        }

        /// <summary>
        /// Updates PatientInfo object with specified Id
        /// </summary>
        /// <param name="patientId">Id of PatientInfo object to be updated</param>
        /// <param name="patient">PatientInfo object to be cloned from</param>
        public void UpdatePatient(int patientId, PatientInfo patient)
        {
            PatientInfo patientToUpdate = _data.GetPatient(patientId);
            patientToUpdate.FirstName = patient.FirstName;
            patientToUpdate.LastName = patient.LastName;
            patientToUpdate.Country = patient.Country;
            patientToUpdate.City = patient.City;
            patientToUpdate.Address = patient.Address;
            patientToUpdate.BirthDate = patient.BirthDate;
            patientToUpdate.Phone = patient.Phone;
            patientToUpdate.Email = patient.Email;
            patientToUpdate.Gender = patient.Gender;
            patientToUpdate.ImageId = patient.ImageId;
            _data.Save();
        }

        /// <summary>
        /// Gets a collection of all Image objects available in the database
        /// </summary>
        /// <returns>Collection of Image objects</returns>
        public IEnumerable<Image> GetImages()
        {
            return _data.GetImages();
        }

        /// <summary>
        /// Looks for an Image with the requested Id
        /// </summary>
        /// <param name="imageId">Id of Image to look for</param>
        /// <returns>Image object with specified Id or NULL if not found</returns>
        public Image GetImageById(int imageId)
        {
            return _data.GetImage(imageId);
        }

        public void DeletePatient(int patientId)
        {
            PatientInfo patientToDelete = _data.GetPatient(patientId);

            if (patientToDelete != null)
            {
                patientToDelete.IsDeleted = true;
            }
        }
    }
}
