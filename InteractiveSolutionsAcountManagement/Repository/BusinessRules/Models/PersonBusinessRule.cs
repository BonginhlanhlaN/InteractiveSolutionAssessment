using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InteractiveSolutionsAcountManagement.Repository.BusinessRules.Interfaces;
using InteractiveSolutionsAcountManagement.Repository.Models;

namespace InteractiveSolutionsAcountManagement.Repository.BusinessRules.Models
{

    public class PersonBusinessRule : IPersonBusinessRules
    {
        private readonly AccountManagementDbContext _dbContext;
        public PersonBusinessRule(AccountManagementDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public bool IsIdNumberDuplicate(Persons person)
        {

            return this._dbContext.Persons.Any(p => p.IdNumber == person.IdNumber);
        }

        public bool IsPersonAccountExist(Persons person)
        {
            return this._dbContext.Accounts.Any(a => a.PersonCode == person.Code);
        }
    }
}
