using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ZoneService : IZoneService
    {
        private readonly IRepository<Zone> _zoneRepository;
        private readonly IMapper _mapper;

        public ZoneService(IRepository<Zone> zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public IEnumerable<ZoneDTO> GetAll()
        {
            var zones = _zoneRepository.FindAll().AsEnumerable();
            return _mapper.Map<IEnumerable<ZoneDTO>>(zones);
        }
    }
}