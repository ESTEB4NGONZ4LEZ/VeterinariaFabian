
using API.Dtos.Veterinario;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class VeterinarioController : BaseApiController
    {
        public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<VeterinarioDto>> Get()
        {
            var registros = await _unitOfWork.Veterinario.GetAllAsync();
            return _mapper.Map<List<VeterinarioDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<VeterinarioxCitaDto> GetById(int id)
        {
            var registro = await _unitOfWork.Veterinario.GetByIdAsync(id);
            return _mapper.Map<VeterinarioxCitaDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VeterinarioDto>> Post(VeterinarioDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Veterinario>(data);
            _unitOfWork.Veterinario.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody] VeterinarioDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Veterinario>(updateData);
            registro.Id = id;
            _unitOfWork.Veterinario.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Veterinario.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Veterinario.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VeterinarioDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Veterinario.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<VeterinarioDto>>(registros.registers);
            return new Pager<VeterinarioDto>
            (
                lista,
                registros.allRegisters,
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
        }

        [HttpGet("cirujanoVascular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<dynamic> GetCirujanoVascular()
        {
            var registros = await _unitOfWork.Veterinario.GetCirujanoVascular();
            return registros;
        }
    }
}