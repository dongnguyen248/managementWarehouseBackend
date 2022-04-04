using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> _unitRepository;
        private readonly IMapper _mapper;

        public UnitService(IRepository<Unit> unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public IEnumerable<UnitDTO> GetAll()
        {
            IEnumerable<Unit> units = _unitRepository.FindAll().AsEnumerable();
            return _mapper.Map<IEnumerable<UnitDTO>>(units);
        }
    }
}