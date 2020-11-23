using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository { 
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        { 
        }

        public async Task CreateCompany(Company company) => await Create(company);

        public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Company> GetCompany(Guid companyId, bool trackChanges)
        {
            return await FindByCondition(p => p.Id == companyId, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

        public async Task DeleteCompany(Company company) => await Delete(company);
    }
}
