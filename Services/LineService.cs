using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class LineService : ILineService
    {
        private readonly IRepository<Line> _lineRepository;
        private readonly IMapper _mapper;

        public LineService(IRepository<Line> lineRepository, IMapper mapper)
        {
            _lineRepository = lineRepository;
            _mapper = mapper;
        }

        public IEnumerable<LineDTO> GetAll()
        {
            IEnumerable<Line> lines = _lineRepository.FindAll().AsEnumerable();
            return _mapper.Map<IEnumerable<LineDTO>>(lines);
        }
    }
}