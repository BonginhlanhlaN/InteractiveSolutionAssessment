using InteractiveSolutionsAcountManagement.Repository.BusinessRules.Models;
using InteractiveSolutionsAcountManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveSolutionsAcountManagement.Repository.RepositoryPattern
{
    public class PersonRepository : ControllerBase, IPersonRepository
    {

        private readonly AccountManagementDbContext _context;

        private readonly PersonBusinessRule _personBusinessRule;

        public PersonRepository(AccountManagementDbContext context)
        {

            _context = context;
            _personBusinessRule = new PersonBusinessRule(_context);

        }

        public async Task<ActionResult<IEnumerable<Persons>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<ActionResult<Persons>> GetPersons(int id)
        {

            var persons = await _context.Persons.FindAsync(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;

        }

        public async Task<IActionResult> PutPersons(int id, [FromBody] Persons persons)
        {

            if (id != persons.Code)
            {
               
                return BadRequest();
            }

            _context.Entry(persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        public async Task<ActionResult<Persons>> PostPersons(Persons persons)
        {

            if (_personBusinessRule.IsIdNumberDuplicate(persons))
            {
                return BadRequest();
            }

            _context.Persons.Add(persons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersons", new { id = persons.Code }, persons);

        }

        public async Task<ActionResult<Persons>> DeletePersons(int id)
        {

            var persons = await _context.Persons.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }


            if (_personBusinessRule.IsPersonAccountExist(persons))
            {
                return BadRequest();
            }


            _context.Persons.Remove(persons);
            await _context.SaveChangesAsync();

            return persons;

        }

        private bool PersonsExists(int id)
        {
            return _context.Persons.Any(e => e.Code == id);
        }
    }
}
