using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientBL.Services;
using Moq;
using System.Collections.Generic;
using PatientBO.Models;
using AutoMapper;
using PatientBO.ViewModels;
using System.Linq;

namespace PatientTests
{
    [TestClass]
    public class PatientInfoServiceTests
    {
        private static IPatientService _service;
        private Mock<PatientTestingDataContext> _data;
        private static IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            _data = new Mock<PatientTestingDataContext>();
            _data.SetupGet(i => i.Images).Returns(mockImages);
            _data.SetupGet(a => a.Appointments).Returns(mockAppointments);
            _data.SetupGet(p => p.Patients).Returns(mockPatients);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientInfo, PatientView>();
            });
            IMapper mapper = config.CreateMapper();

            _service = new PatientInfoService(_data.Object, mapper);
        }

        [TestMethod]
        public void GetPatientsTest_ReturnsSorterCollection()
        {
            // Arrange

            // Act
            List<PatientView> actualPatients = _service.GetPatients().ToList();            

            // Assert
            Assert.AreEqual(mockPatients.Count, actualPatients.Count);            
        }

        [TestMethod]
        [DataRow(2)]
        public void GetPatientByIdWhenValidId_ReturnsCorrectPatientInfo(int id)
        {
            // Arrange

            // Act
            PatientInfo patient = _service.GetPatientById(id);
            string expectedName = mockPatients.FirstOrDefault(p => p.PatientId == id).FirstName;
            string expectedSurname = mockPatients.FirstOrDefault(p => p.PatientId == id).LastName;

            // Assert
            Assert.AreEqual(expectedName, patient.FirstName);
            Assert.AreEqual(expectedSurname, patient.LastName);
        }

        private static List<Image> mockImages = new List<Image>
        {
            new Image{ImageId = 1, ImageName = "James_Bond.jpg"},
            new Image{ImageId = 2, ImageName = "Ivy_Young.jpg"},
            new Image{ImageId = 3, ImageName = "Melissa_Brown.jpg"},
            new Image{ImageId = 4, ImageName = "John_Smith.jpg"},
            new Image{ImageId = 5, ImageName = "Kevin_McBribe.jpg"},
        };

        private static List<PatientInfo> mockPatients = new List<PatientInfo>
        {
            new PatientInfo{PatientId = 1, FirstName = "James", LastName = "Bond", Country ="UK", City = "London", Address = "Douning str, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "mi5@gmail.com", Gender = 1, ImageId = 1, IsDeleted = false},
            new PatientInfo{PatientId = 2, FirstName = "Ivy", LastName = "Young", Country ="Ireland", City = "Dublin", Address = "Yellow park, 1", BirthDate = new System.DateTime(1980, 9, 28), Phone="380671119999", Email = "ivy@gmail.com", Gender = 2, ImageId = 2, IsDeleted = false},
            new PatientInfo{PatientId = 3, FirstName = "Melissa", LastName = "Brown", Country ="Sweden", City = "Stokholm", Address = "Norcheping av, 110", BirthDate = new System.DateTime(1990, 3, 8), Phone="380635554334", Email = "mel@outlook.com", Gender = 2, ImageId = 3, IsDeleted = false},
            new PatientInfo{PatientId = 4, FirstName = "John", LastName = "Smith", Country ="UK", City = "London", Address = "Westminster, 11", BirthDate = new System.DateTime(1956, 1, 18), Phone="380975554334", Email = "jo@gmail.com", Gender = 1, ImageId = 4, IsDeleted = false},
            new PatientInfo{PatientId = 5, FirstName = "Kevin", LastName = "McBribe", Country ="UK", City = "Aberdin", Address = "Lake view sq, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "scottish@gmail.com", Gender = 1, ImageId = 5, IsDeleted = false},
            new PatientInfo{PatientId = 6, FirstName = "Elizabeth", LastName = "Parker", Country ="UK", City = "London", Address = "Douning str, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "mi5@gmail.com", Gender = 2, ImageId = 1, IsDeleted = false},
            new PatientInfo{PatientId = 7, FirstName = "Frank", LastName = "Connor", Country ="UK", City = "London", Address = "Douning str, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "mi5@gmail.com", Gender = 1, ImageId = 1, IsDeleted = false},
            new PatientInfo{PatientId = 8, FirstName = "Anna", LastName = "Green", Country ="UK", City = "London", Address = "Douning str, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "mi5@gmail.com", Gender = 1, ImageId = 1, IsDeleted = false},
            new PatientInfo{PatientId = 9, FirstName = "Sarah", LastName = "Zimmermann", Country ="UK", City = "London", Address = "Douning str, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "mi5@gmail.com", Gender = 1, ImageId = 1, IsDeleted = false},
            new PatientInfo{PatientId = 10, FirstName = "Maria", LastName = "Popkina", Country ="UK", City = "London", Address = "Douning str, 11", BirthDate = new System.DateTime(1970, 1, 18), Phone="380505554334", Email = "mi5@gmail.com", Gender = 1, ImageId = 1, IsDeleted = false},
        };

        private static List<Appointment> mockAppointments = new List<Appointment>
        {
            new Appointment{AppointmentId = 1, PatientId = 1, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,1), Purpose="Diagnostic", IsDeleted = false, UserId = 1},
            new Appointment{AppointmentId = 2, PatientId = 2, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,2), Purpose="Analysis", IsDeleted = false, UserId = 1},
            new Appointment{AppointmentId = 3, PatientId = 3, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,3), Purpose="Procedures", IsDeleted = false, UserId = 1},
            new Appointment{AppointmentId = 4, PatientId = 4, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,4), Purpose="Claims", IsDeleted = false, UserId = 2},
            new Appointment{AppointmentId = 5, PatientId = 5, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,5), Purpose="Diagnostic", IsDeleted = false, UserId = 2},
            new Appointment{AppointmentId = 6, PatientId = 6, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,6), Purpose="Seekness", IsDeleted = false, UserId = 2},
            new Appointment{AppointmentId = 7, PatientId = 7, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,7), Purpose="Claims", IsDeleted = false, UserId = 3},
            new Appointment{AppointmentId = 8, PatientId = 4, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,8), Purpose="Diagnostic", IsDeleted = false, UserId = 1},
            new Appointment{AppointmentId = 9, PatientId = 1, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,9), Purpose="Diagnostic", IsDeleted = false, UserId = 1},
            new Appointment{AppointmentId = 10, PatientId = 2, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,10), Purpose="Diagnostic", IsDeleted = false, UserId = 1},
            new Appointment{AppointmentId = 11, PatientId = 10, Duration = 30, AppointmentDateTime = new System.DateTime(2018, 10,11), Purpose="Diagnostic", IsDeleted = false, UserId = 1},

        };
    }    
}
