
using API.Dtos.Medicamento;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MedicamentoController : BaseApiController
    {
        public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<MedicamentoDto>> Get()
        {
            var registros = await _unitOfWork.Medicamento.GetAllAsync();
            return _mapper.Map<List<MedicamentoDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<MedicamentoDto> GetById(int id)
        {
            var registro = await _unitOfWork.Medicamento.GetByIdAsync(id);
            return _mapper.Map<MedicamentoDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentoDto>> Post(MedicamentoDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Medicamento>(data);
            _unitOfWork.Medicamento.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody] MedicamentoDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Medicamento>(updateData);
            registro.Id = id;
            _unitOfWork.Medicamento.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Medicamento.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Medicamento.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicamentoDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Medicamento.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<MedicamentoDto>>(registros.registers);
            return new Pager<MedicamentoDto>
            (
                lista,
                registros.allRegisters,
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
        }

        [HttpGet("laboratorioGenfar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<dynamic> GetLaboratorioGenfar()
        {
            var registros = await _unitOfWork.Medicamento.GetMedicamentoGenfar();
            return registros;
        }

        [HttpGet("medicamento>50000")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<dynamic> GetMedicamento50000()
        {
            var registros = await _unitOfWork.Medicamento.GetMedicamentos50000();
            return registros;
        }
    }
}