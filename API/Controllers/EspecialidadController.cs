
using API.Dtos.Especialidad;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EspecialidadController : BaseApiController
    {
        public EspecialidadController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<EspecialidadDto>> Get()
        {
            var registros = await _unitOfWork.Especialidad.GetAllAsync();
            return _mapper.Map<List<EspecialidadDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EspecialidadxVeterinarioDto> GetById(int id)
        {
            var registro = await _unitOfWork.Especialidad.GetByIdAsync(id);
            return _mapper.Map<EspecialidadxVeterinarioDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspecialidadDto>> Post(EspecialidadDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Especialidad>(data);
            _unitOfWork.Especialidad.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EspecialidadDto>> Put(int id, [FromBody] EspecialidadDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Especialidad>(updateData);
            registro.Id = id;
            _unitOfWork.Especialidad.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Especialidad.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Especialidad.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EspecialidadDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Especialidad.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<EspecialidadDto>>(registros.registers);
            return new Pager<EspecialidadDto>
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