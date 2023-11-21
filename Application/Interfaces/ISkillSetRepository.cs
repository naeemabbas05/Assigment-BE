using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISkillSetRepository
    {
        Task<Response<IReadOnlyList<SkillSets>>> GetAllSkillSet();

    }
}
