using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public ICompanyRepository Company => _companyRepository ?? (_companyRepository = new CompanyRepository(_repositoryContext));

        public IEmployeeRepository Employee => _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_repositoryContext));

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
