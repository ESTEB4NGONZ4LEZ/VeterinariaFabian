
using API.Dtos.Propietario;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PropietarioController : BaseApiController
    {
        public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<PropietarioDto>> Get()
        {
            var registros = await _unitOfWork.Propietario.GetAllAsync();
            return _mapper.Map<List<PropietarioDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PropietarioDto> GetById(int id)
        {
            var registro = await _unitOfWork.Propietario.GetByIdAsync(id);
            return _mapper.Map<PropietarioDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropietarioDto>> Post(PropietarioDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Propietario>(data);
            _unitOfWork.Propietario.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody] PropietarioDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Propietario>(updateData);
            registro.Id = id;
            _unitOfWork.Propietario.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Propietario.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Propietario.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PropietarioDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Propietario.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<PropietarioDto>>(registros.registers);
            return new Pager<PropietarioDto>
            (
                lista,
                registros.allRegisters,
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
        }

        [HttpGet("propietarioxMascota")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<dynamic> GetPropietarioxMascota()
        {
            var registros = await _unitOfWork.Propietario.GetPropietarioxMasxotas();
            return registros;
        }
    }
}