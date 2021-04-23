using InteractiveSolutionsAcountManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveSolutionsAcountManagement.Repository.RepositoryPattern
{
    public interface IAccountRepository
    {

        public Task<ActionResult<IEnumerable<Accounts>>> GetAccounts();

        public Task<ActionResult<Accounts>> GetAccounts(int id);

        public Task<ActionResult<IEnumerable<Accounts>>> GetPersonsAccounts(int id);

        public Task<IActionResult> PutAccounts(int id, Accounts accounts);

        public Task<ActionResult<Accounts>> PostAccounts(Accounts accounts);

        public Task<ActionResult<Accounts>> DeleteAccounts(int id);

    }
}
