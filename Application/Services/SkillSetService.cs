using Application.Interfaces;
using Application.Services.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillSetService: ISkillSetService
    {
        private readonly ISkillSetRepository _skillSeRepository;
        public SkillSetService(ISkillSetRepository skillSeRepository)
        {
            _skillSeRepository = skillSeRepository;
        }

        public async Task<Response<IReadOnlyList<SkillSets>>> GetAllSkillSet()
        {
            return await _skillSeRepository.GetAllSkillSet();
        }
    }
}
