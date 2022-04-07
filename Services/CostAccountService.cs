using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CostAccountService : ICostAccountService
    {
        private readonly IRepository<CostAccount> _costAccountRepository;
        private readonly IMapper _mapper;
        public CostAccountService(IRepository<CostAccount> costAccountRepository, IMapper mapper)
        {
            _costAccountRepository = costAccountRepository;
            _mapper = mapper;

        }
        public IEnumerable<CostAccountDTO> GetAll()
        {
            IEnumerable<CostAccount> costAccounts = _costAccountRepository.FindAll(c => c.CostAccountItems).AsEnumerable();

            return _mapper.Map<IEnumerable<CostAccountDTO>>(costAccounts);
        }
    }
}
