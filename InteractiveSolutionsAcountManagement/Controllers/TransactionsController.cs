using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteractiveSolutionsAcountManagement.Repository;
using InteractiveSolutionsAcountManagement.Repository.Models;
using InteractiveSolutionsAcountManagement.Repository.RepositoryPattern;

namespace InteractiveSolutionsAcountManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // GET: api/Transactions
        [HttpGet]
        public Task<ActionResult<IEnumerable<Transactions>>> GetTransactions()
        {
            return _transactionRepository.GetTransactions();
        }

        //GET: api/Transactions/5
        [HttpGet("{id}")]
        public Task<ActionResult<Transactions>> GetTransactions(int id)
        {
            return _transactionRepository.GetTransactions(id);
        }

        // GET: api/Transactions/account-transctions/5
        [HttpGet("account-transctions/{id}")]
        public  Task<ActionResult<IEnumerable<Transactions>>> GetAccountTransactions(int id)
        {
            return _transactionRepository.GetAccountTransactions(id);
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public Task<IActionResult> PutTransactions(int id, Transactions transactions)
        {
            return _transactionRepository.PutTransactions(id, transactions);
        }

        // POST: api/Transactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public Task<ActionResult<Transactions>> PostTransactions(Transactions transactions)
        {
            return _transactionRepository.PostTransactions(transactions);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public  Task<ActionResult<Transactions>> DeleteTransactions(int id)
        {
            return _transactionRepository.DeleteTransactions(id);
        }

    }
}
