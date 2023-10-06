
using API.Dtos.TratamientoMedico;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TratamientoMedicoController : BaseApiController
    {
        public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<TratamientoMedicoDto>> Get()
        {
            var registros = await _unitOfWork.TratamientoMedico.GetAllAsync();
            return _mapper.Map<List<TratamientoMedicoDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<TratamientoMedicoDto> GetById(int id)
        {
            var registro = await _unitOfWork.TratamientoMedico.GetByIdAsync(id);
            return _mapper.Map<TratamientoMedicoDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoMedicoDto>> Post(TratamientoMedicoDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<TratamientoMedico>(data);
            _unitOfWork.TratamientoMedico.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TratamientoMedicoDto>> Put(int id, [FromBody] TratamientoMedicoDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<TratamientoMedico>(updateData);
            registro.Id = id;
            _unitOfWork.TratamientoMedico.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.TratamientoMedico.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.TratamientoMedico.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TratamientoMedicoDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.TratamientoMedico.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<TratamientoMedicoDto>>(registros.registers);
            return new Pager<TratamientoMedicoDto>
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