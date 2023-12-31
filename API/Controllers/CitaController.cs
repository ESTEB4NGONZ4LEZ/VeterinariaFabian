
using API.Dtos.Cita;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CitaController : BaseApiController
    {
        public CitaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<CitaDto>> Get()
        {
            var registros = await _unitOfWork.Cita.GetAllAsync();
            return _mapper.Map<List<CitaDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CitaDto> GetById(int id)
        {
            var registro = await _unitOfWork.Cita.GetByIdAsync(id);
            return _mapper.Map<CitaDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CitaDto>> Post(CitaDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Cita>(data);
            _unitOfWork.Cita.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CitaDto>> Put(int id, [FromBody] CitaDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Cita>(updateData);
            registro.Id = id;
            _unitOfWork.Cita.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Cita.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Cita.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CitaDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Cita.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<CitaDto>>(registros.registers);
            return new Pager<CitaDto>
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