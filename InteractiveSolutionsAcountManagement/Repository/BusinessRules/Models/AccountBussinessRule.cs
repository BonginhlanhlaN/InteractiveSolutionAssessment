using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveSolutionsAcountManagement.Repository.BusinessRules.Interfaces;
using InteractiveSolutionsAcountManagement.Repository.Models;
using InteractiveSolutionsAcountManagement.Repository;

namespace InteractiveSolutionsAcountManagement.Repository.BusinessRules.Models
{
    public class AccountBussinessRule : IAccountBusinessRules
    {

        private readonly AccountManagementDbContext _dbContext;

        public AccountBussinessRule(AccountManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsAccountNumberDuplicate(Accounts account)
        {
            return _dbContext.Accounts.Any(a => a.AccountNumber == account.AccountNumber);
        }
    }
}
