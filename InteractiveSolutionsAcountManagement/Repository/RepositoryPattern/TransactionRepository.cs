using InteractiveSolutionsAcountManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveSolutionsAcountManagement.Repository.RepositoryPattern
{
    public class TransactionRepository : ControllerBase, ITransactionRepository
    {

        private readonly AccountManagementDbContext _context;

        public TransactionRepository(AccountManagementDbContext context)
        {
            _context = context;

        }

        public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }


        public async Task<ActionResult<Transactions>> GetTransactions(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);

            if (transactions == null)
            {
                return NotFound();
            }

            return transactions;
        }

        public async Task<ActionResult<IEnumerable<Transactions>>> GetAccountTransactions(int id)
        {
            var transactions = from transaction in _context.Transactions
                               where transaction.AccountCode == id
                               select transaction;


            return await transactions.ToListAsync();
        }

        public async Task<IActionResult> PutTransactions(int id, Transactions transactions)
        {

            if (id != transactions.Code)
            {
                return BadRequest();
            }

            _context.Entry(transactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsExists(id))
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


        public async Task<ActionResult<Transactions>> PostTransactions(Transactions transactions)
        {
            _context.Transactions.Add(transactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactions", new { id = transactions.Code }, transactions);
        }

        
        public async Task<ActionResult<Transactions>> DeleteTransactions(int id)
        {

            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transactions);
            await _context.SaveChangesAsync();

            return transactions;

        }

        private bool TransactionsExists(int id)
        {
            return _context.Transactions.Any(e => e.Code == id);
        }

    }
}
