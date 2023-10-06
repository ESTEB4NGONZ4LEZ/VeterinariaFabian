
using API.Dtos.Mascota;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MascotaController : BaseApiController
    {
        public MascotaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<MascotaDto>> Get()
        {
            var registros = await _unitOfWork.Mascota.GetAllAsync();
            return _mapper.Map<List<MascotaDto>>(registros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<MascotaDto> GetById(int id)
        {
            var registro = await _unitOfWork.Mascota.GetByIdAsync(id);
            return _mapper.Map<MascotaDto>(registro);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotaDto>> Post(MascotaDto data)
        {
            if(data == null) return BadRequest();
            var addRegistro = _mapper.Map<Mascota>(data);
            _unitOfWork.Mascota.Add(addRegistro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = addRegistro.Id}, addRegistro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto updateData)
        {
            if(updateData == null) return BadRequest();
            var registro = _mapper.Map<Mascota>(updateData);
            registro.Id = id;
            _unitOfWork.Mascota.Update(registro);
            await _unitOfWork.SaveAsync();
            return updateData;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Mascota.GetByIdAsync(id);
            if(registro == null) return NotFound();
            _unitOfWork.Mascota.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MascotaDto>>> GetPager([FromQuery] Params pagerParams)
        {
            var registros = await _unitOfWork.Mascota.GetAllAsync
            (
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
            var lista = _mapper.Map<List<MascotaDto>>(registros.registers);
            return new Pager<MascotaDto>
            (
                lista,
                registros.allRegisters,
                pagerParams.PageIndex,
                pagerParams.PageSize,
                pagerParams.Search
            );
        }

        [HttpGet("felino")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<dynamic> GetMascotaFelina()
        {
            var registros = await _unitOfWork.Mascota.GetMascotaFelina();
            return registros;
        }

        [HttpGet("vacunacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<dynamic> GetMascotaVacunacion()
        {
            var registros = await _unitOfWork.Mascota.GetMascotasVacunacion();
            return registros;
        }
    }
}