
using API.Dtos.Especie;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class EspecieController : BaseApiController
    {
        public EspecieController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<EspecieDto>> Get()
        {
            var registros = await _unitOfWork.Especie.GetAllAsync();
            return _mapper.Map<List<EspecieDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EspecieDto> GetById(int id)
        {
            var registro = await _unitOfWork.Especie.GetByIdAsync(id);
            return _mapper.Map<EspecieDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspecieDto>> Post(EspecieDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Especie>(data);
            _unitOfWork.Especie.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody] EspecieDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Especie>(updateData);
            registro.Id = id;
            _unitOfWork.Especie.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Especie.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Especie.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EspecieDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Especie.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<EspecieDto>>(registros.registers);
            return new Pager<EspecieDto>
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