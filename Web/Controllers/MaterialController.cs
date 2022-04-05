using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Helpers.Core;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ApiController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("{page}/{pageSize}")]
        public IActionResult Get(int page, int pageSize)
        {
            IEnumerable<MaterialDTO> materials = _materialService.GetAll(page, pageSize, out int totalRow);
            IEnumerable<MaterialViewModels> materialVMs = new MaterialViewModels().Gets(materials);
            PaginationSet<MaterialViewModels> pagedSet = new PaginationSet<MaterialViewModels>()
            {
                PageIndex = page,
                TotalRows = totalRow,
                PageSize = pageSize,
                Items = materialVMs
            };
            return Ok(pagedSet);
        }

        [HttpGet("{page}/{pageSize}/search")]
        public IActionResult Search(string qCode, string zone, string location, string item, string specification, int page, int pageSize)
        {
            IEnumerable<MaterialDTO> materials = _materialService.Search(qCode, zone, location, item, specification, page, pageSize, out int totalRow);
            IEnumerable<MaterialViewModels> materialVMs = new MaterialViewModels().Gets(materials);
            PaginationSet<MaterialViewModels> pagedSet = new PaginationSet<MaterialViewModels>()
            {
                PageIndex = page,
                TotalRows = totalRow,
                PageSize = pageSize,
                Items = materialVMs
            };
            return Ok(pagedSet);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(MaterialDTO material)
        {
            try
            {
                int handler = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.Ordinal)).Value);
                material.ImportHistories.ToList().ForEach(x => x.Handler = handler);

                _materialService.Add(material);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
        [HttpPost("update-material")]
        public IActionResult UpdateMaterial(MaterialDTO material)
        {
            try
            {
                
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}