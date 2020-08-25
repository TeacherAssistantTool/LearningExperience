﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Domain.Advisors
{
    public interface IAdvisor
    {
        Task AddAdvisor(AdvisorDto advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(AdvisorDto advisorRemoved);
        Task UpdateAdvisor(AdvisorDto advisorUpdated);
        Advisor GetAdvisorById(string AdvisorId);
    }
}

