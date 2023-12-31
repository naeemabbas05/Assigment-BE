﻿using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISkillSetService
    {
        Task<Response<IReadOnlyList<SkillSets>>> GetAllSkillSet();
    }
}
