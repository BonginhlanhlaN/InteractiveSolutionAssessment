using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InteractiveSolutionsAcountManagement.Repository;
using InteractiveSolutionsAcountManagement.Repository.Models;

namespace InteractiveSolutionsAcountManagement.Repository.BusinessRules.Interfaces
{
    interface IPersonBusinessRules
    {


        public bool IsIdNumberDuplicate(Persons person);

        public bool IsPersonAccountExist(Persons person);
        
    }
}
