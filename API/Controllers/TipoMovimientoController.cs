
using API.Dtos.TipoMovimiento;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoMovimientoController : BaseApiController
    {
        public TipoMovimientoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<TipoMovimientoDto>> Get()
        {
            var registros = await _unitOfWork.TipoMovimiento.GetAllAsync();
            return _mapper.Map<List<TipoMovimientoDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<TipoMovimientoDto> GetById(int id)
        {
            var registro = await _unitOfWork.TipoMovimiento.GetByIdAsync(id);
            return _mapper.Map<TipoMovimientoDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMovimientoDto>> Post(TipoMovimientoDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<TipoMovimiento>(data);
            _unitOfWork.TipoMovimiento.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoMovimientoDto>> Put(int id, [FromBody] TipoMovimientoDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<TipoMovimiento>(updateData);
            registro.Id = id;
            _unitOfWork.TipoMovimiento.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.TipoMovimiento.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.TipoMovimiento.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoMovimientoDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.TipoMovimiento.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<TipoMovimientoDto>>(registros.registers);
            return new Pager<TipoMovimientoDto>
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