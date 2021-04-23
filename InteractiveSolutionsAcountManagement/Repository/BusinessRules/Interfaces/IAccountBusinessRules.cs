using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveSolutionsAcountManagement.Repository.Models;

namespace InteractiveSolutionsAcountManagement.Repository.BusinessRules.Interfaces
{
    interface IAccountBusinessRules
    {

        public bool IsAccountNumberDuplicate(Accounts account);

    }
}
