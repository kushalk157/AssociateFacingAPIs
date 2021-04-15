using Associate_FacingAPIs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Associate_FacingAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public readonly IContactsBL _contactsBL;
        public ContactsController(IContactsBL contactsBL)
        {
            _contactsBL = contactsBL;
        }

        
        [Route("GetContacts")]
        [HttpGet]
        public async Task<IActionResult> GetContacts(string source, string phoneNumber)
        {
            try
            {
                return Ok(await _contactsBL.GetContacts(source, phoneNumber));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
        }




    }
}
