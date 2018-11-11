using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientBL.Services;
using PatientBO.Models;
using PatientBO.ViewModels;

namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class
        /// </summary>
        private IPatientService _service;

        /// <summary>
        /// Initializes new instanct of THIS setting business logic object (_service)
        /// </summary>
        /// <param name="service">Object implementing business logic for this controller</param>
        public ImageController(IPatientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles request GET: ../api/image/
        /// Selects all Image objects available in the database table Images
        /// </summary>
        /// <returns>Collecton of Image models</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Image>> Get()
        {
            return _service.GetImages().ToList();
        }

        /// <summary>
        /// Handles request GET: api/patient/5
        /// Looks up Image instance with specified Id
        /// </summary>
        /// <param name="id">Id of Image to look for</param>
        /// <returns>Image model or Not Found</returns>
        [HttpGet("{id}", Name = "GetImage")]
        public ActionResult<Image> GetById(int id)
        {
            var image = _service.GetImageById(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }
    }
}