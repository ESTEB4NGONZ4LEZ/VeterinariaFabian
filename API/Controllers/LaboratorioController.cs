
using API.Dtos.Laboratorio;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class LaboratorioController : BaseApiController
    {
        public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<LaboratorioDto>> Get()
        {
            var registros = await _unitOfWork.Laboratorio.GetAllAsync();
            return _mapper.Map<List<LaboratorioDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<LaboratorioDto> GetById(int id)
        {
            var registro = await _unitOfWork.Laboratorio.GetByIdAsync(id);
            return _mapper.Map<LaboratorioDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LaboratorioDto>> Post(LaboratorioDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Laboratorio>(data);
            _unitOfWork.Laboratorio.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<LaboratorioDto>> Put(int id, [FromBody] LaboratorioDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Laboratorio>(updateData);
            registro.Id = id;
            _unitOfWork.Laboratorio.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Laboratorio.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Laboratorio.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<LaboratorioDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Laboratorio.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<LaboratorioDto>>(registros.registers);
            return new Pager<LaboratorioDto>
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