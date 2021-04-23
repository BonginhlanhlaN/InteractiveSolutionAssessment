using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteractiveSolutionsAcountManagement.Repository;
using InteractiveSolutionsAcountManagement.Repository.Models;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using InteractiveSolutionsAcountManagement.Repository.BusinessRules.Models;
using InteractiveSolutionsAcountManagement.Repository.RepositoryPattern;

namespace InteractiveSolutionsAcountManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        
        private readonly IPersonRepository _personRepository;
        //private PersonBusinessRule _personBusinessRule;

        public PersonsController(IPersonRepository personRepository)
        {

            _personRepository = personRepository;

        }

        // GET: api/Persons
        [HttpGet]
        public Task<ActionResult<IEnumerable<Persons>>> GetPersons()
        {

            return   _personRepository.GetPersons();

        }

        
        // GET: api/Persons/5
        [HttpGet("{id}")]
        public Task<ActionResult<Persons>> GetPersons(int id)
        {

            return _personRepository.GetPersons(id);

        }

        

        // PUT: api/Persons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public Task<IActionResult> PutPersons(int id, [FromBody]Persons persons)
        {

            return _personRepository.PutPersons(id, persons);
           
        }

       

        // POST: api/Persons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public Task<ActionResult<Persons>> PostPersons(Persons persons)
        {

            return _personRepository.PostPersons(persons);
        }

        

       // DELETE: api/Persons/5
       [HttpDelete("{id}")]
       public Task<ActionResult<Persons>> DeletePersons(int id)
       {

            return _personRepository.DeletePersons(id);
           
       }

       
    }
}
