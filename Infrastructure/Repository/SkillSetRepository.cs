using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SkillSetRepository: ISkillSetRepository
    {
        public IGenericRepository<SkillSets> _skillSetRepository;

        public SkillSetRepository(IGenericRepository<SkillSets> skillSetRepository)
        {
            _skillSetRepository = skillSetRepository;

        }

        public async Task<Response<IReadOnlyList<SkillSets>>> GetAllSkillSet()
        {
            var skillSets = await _skillSetRepository.GetAll();
            return new Response<IReadOnlyList<SkillSets>>(skillSets);
        }
    }
}
