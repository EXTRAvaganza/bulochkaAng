using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bulochka.Entities;
using bulochka.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bulochka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BulochkaController : Controller
    {
        private BulochkaService _bulochkaService;
        public BulochkaController(ApplicationContext _context)
        {
            _bulochkaService = new BulochkaService(_context);
        }
        [HttpGet]
        public IEnumerable<Bulochka> Get()
        {
            return _bulochkaService.GetAll();
        }
    }
}
