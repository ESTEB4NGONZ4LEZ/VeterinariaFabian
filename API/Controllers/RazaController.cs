
using API.Dtos.Raza;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class RazaController : BaseApiController
    {
        public RazaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<RazaDto>> Get()
        {
            var registros = await _unitOfWork.Raza.GetAllAsync();
            return _mapper.Map<List<RazaDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<RazaDto> GetById(int id)
        {
            var registro = await _unitOfWork.Raza.GetByIdAsync(id);
            return _mapper.Map<RazaDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazaDto>> Post(RazaDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Raza>(data);
            _unitOfWork.Raza.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RazaDto>> Put(int id, [FromBody] RazaDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Raza>(updateData);
            registro.Id = id;
            _unitOfWork.Raza.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Raza.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Raza.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<RazaDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Raza.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<RazaDto>>(registros.registers);
            return new Pager<RazaDto>
            (
                lista,
                registros.allRegisters,
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
        }
    }
}