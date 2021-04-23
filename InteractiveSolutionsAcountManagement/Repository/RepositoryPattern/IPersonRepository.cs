using InteractiveSolutionsAcountManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveSolutionsAcountManagement.Repository.RepositoryPattern
{
    public interface IPersonRepository
    {

        public Task<ActionResult<IEnumerable<Persons>>> GetPersons();

        public Task<ActionResult<Persons>> GetPersons(int id);

        public Task<IActionResult> PutPersons(int id, [FromBody] Persons persons);

        public Task<ActionResult<Persons>> PostPersons(Persons persons);

        public Task<ActionResult<Persons>> DeletePersons(int id);

    }
}
