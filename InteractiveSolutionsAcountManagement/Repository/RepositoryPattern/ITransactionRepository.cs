using InteractiveSolutionsAcountManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveSolutionsAcountManagement.Repository.RepositoryPattern
{
    public interface ITransactionRepository
    {

        public Task<ActionResult<IEnumerable<Transactions>>> GetTransactions();

        public Task<ActionResult<Transactions>> GetTransactions(int id);

        public Task<ActionResult<IEnumerable<Transactions>>> GetAccountTransactions(int id);

        public Task<IActionResult> PutTransactions(int id, Transactions transactions);

        public Task<ActionResult<Transactions>> PostTransactions(Transactions transactions);

        public Task<ActionResult<Transactions>> DeleteTransactions(int id);
    }
}
