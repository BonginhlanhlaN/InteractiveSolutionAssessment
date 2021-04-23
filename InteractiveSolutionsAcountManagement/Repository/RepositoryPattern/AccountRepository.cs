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
    public class AccountRepository : ControllerBase, IAccountRepository
    {

        private readonly AccountManagementDbContext _context;

        private readonly AccountBussinessRule _accountBusinessRule;

        

        public AccountRepository(AccountManagementDbContext context)
        {

            _context = context;
            _accountBusinessRule = new AccountBussinessRule(_context);

        }

        public async Task<ActionResult<IEnumerable<Accounts>>> GetAccounts()
        {

            return await _context.Accounts.ToListAsync();

        }

        public async Task<ActionResult<Accounts>> GetAccounts(int id)
        {

            var accounts = await _context.Accounts.FindAsync(id);

            if (accounts == null)
            {
                return NotFound();
            }

            return accounts;

        }

        public async Task<ActionResult<IEnumerable<Accounts>>> GetPersonsAccounts(int id)
        {

            var accounts = from account in _context.Accounts
                           where account.PersonCode == id
                           select account;


            return await accounts.ToListAsync();

        }

        public async Task<IActionResult> PutAccounts(int id, Accounts accounts)
        {

            if (id != accounts.Code)
            {
                return BadRequest();
            }

            _context.Entry(accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExists(id))
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

        public async Task<ActionResult<Accounts>> PostAccounts(Accounts accounts)
        {

            if (_accountBusinessRule.IsAccountNumberDuplicate(accounts))
            {
                return BadRequest();
            }

            _context.Accounts.Add(accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccounts", new { id = accounts.Code }, accounts);

        }

        public async Task<ActionResult<Accounts>> DeleteAccounts(int id)
        {

            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();

            return accounts;

        }

        private bool AccountsExists(int id)
        {
            return _context.Accounts.Any(e => e.Code == id);
        }

    }
}
