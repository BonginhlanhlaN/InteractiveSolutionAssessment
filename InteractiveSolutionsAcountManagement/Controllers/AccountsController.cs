using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteractiveSolutionsAcountManagement.Repository;
using InteractiveSolutionsAcountManagement.Repository.Models;
using InteractiveSolutionsAcountManagement.Repository.BusinessRules.Models;
using InteractiveSolutionsAcountManagement.Repository.RepositoryPattern;

namespace InteractiveSolutionsAcountManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            
        }

        // GET: api/Accounts
        [HttpGet]
        public Task<ActionResult<IEnumerable<Accounts>>> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public Task<ActionResult<Accounts>> GetAccounts(int id)
        {
            return _accountRepository.GetAccounts(id);
        }

        // GET: api/persons-accounts/5
        [HttpGet("persons-accounts/{id}")]
        public Task<ActionResult<IEnumerable<Accounts>>> GetPersonsAccounts(int id)
        {

            return _accountRepository.GetPersonsAccounts(id);
          
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public Task<IActionResult> PutAccounts(int id, Accounts accounts)
        {

            return _accountRepository.PutAccounts(id, accounts);

        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public Task<ActionResult<Accounts>> PostAccounts(Accounts accounts)
        {

            return _accountRepository.PostAccounts(accounts);
           
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public Task<ActionResult<Accounts>> DeleteAccounts(int id)
        {

            return _accountRepository.DeleteAccounts(id);

        }

      
    }
}
