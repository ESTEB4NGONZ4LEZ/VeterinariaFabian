
using API.Dtos.MovimientoMedicamento;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MovimientoMedicamentoController : BaseApiController
    {
        public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<MovimientoMedicamentoDto>> Get()
        {
            var registros = await _unitOfWork.MovimientoMedicamento.GetAllAsync();
            return _mapper.Map<List<MovimientoMedicamentoDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<MovimientoMedicamentoDto> GetById(int id)
        {
            var registro = await _unitOfWork.MovimientoMedicamento.GetByIdAsync(id);
            return _mapper.Map<MovimientoMedicamentoDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoMedicamentoDto>> Post(MovimientoMedicamentoDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<MovimientoMedicamento>(data);
            _unitOfWork.MovimientoMedicamento.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MovimientoMedicamentoDto>> Put(int id, [FromBody] MovimientoMedicamentoDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<MovimientoMedicamento>(updateData);
            registro.Id = id;
            _unitOfWork.MovimientoMedicamento.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.MovimientoMedicamento.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.MovimientoMedicamento.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MovimientoMedicamentoDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.MovimientoMedicamento.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<MovimientoMedicamentoDto>>(registros.registers);
            return new Pager<MovimientoMedicamentoDto>
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