using Microsoft.AspNetCore.Mvc;
using SolicitudesApiRest.Repositories;
using SolicitudesApiRest.Model;

namespace SolicitudesApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitudController : ControllerBase
{
    private readonly ISolicitudRepository solicitudRepository;
    public SolicitudController(ISolicitudRepository solicitudRepository)
    {
        this.solicitudRepository = solicitudRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSolicitudes(){
        return Ok(await this.solicitudRepository.GetAllSolicitudes());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSolicitudPorId(int id){
        return Ok(await this.solicitudRepository.GetSolicitudPorId(id));
    }

    [HttpPost]
    public async Task<IActionResult> InsertSolicitud([FromBody] Solicitud solicitud){
        if(solicitud == null) return BadRequest();
        return Created("creado", await this.solicitudRepository.InsertSolicitud(solicitud));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSolicitud([FromBody] Solicitud solicitud){
        if(solicitud == null) return BadRequest();
        await this.solicitudRepository.UpdateSolicitud(solicitud);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSolicitud(int id){
        await this.solicitudRepository.DeleteSolicitud(id);
        return NoContent();
    }
}
