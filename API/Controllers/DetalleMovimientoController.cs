
using API.Dtos.DetalleMovimiento;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class DetalleMovimientoController : BaseApiController
    {
        public DetalleMovimientoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<DetalleMovimientoDto>> Get()
        {
            var registros = await _unitOfWork.DetalleMovimiento.GetAllAsync();
            return _mapper.Map<List<DetalleMovimientoDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<DetalleMovimientoDto> GetById(int id)
        {
            var registro = await _unitOfWork.DetalleMovimiento.GetByIdAsync(id);
            return _mapper.Map<DetalleMovimientoDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleMovimientoDto>> Post(DetalleMovimientoDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<DetalleMovimiento>(data);
            _unitOfWork.DetalleMovimiento.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DetalleMovimientoDto>> Put(int id, [FromBody] DetalleMovimientoDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<DetalleMovimiento>(updateData);
            registro.Id = id;
            _unitOfWork.DetalleMovimiento.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.DetalleMovimiento.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.DetalleMovimiento.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DetalleMovimientoDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.DetalleMovimiento.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<DetalleMovimientoDto>>(registros.registers);
            return new Pager<DetalleMovimientoDto>
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