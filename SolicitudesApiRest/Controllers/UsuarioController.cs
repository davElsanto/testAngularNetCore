using Microsoft.AspNetCore.Mvc;
using SolicitudesApiRest.Repositories;
using SolicitudesApiRest.Model;

namespace SolicitudesApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsurioRepository usurioRepository;
    public UsuarioController(IUsurioRepository usurioRepository)
    {
        this.usurioRepository = usurioRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsuarios(){
        return Ok(await this.usurioRepository.GetAllUsuarios());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioPorId(int id){
        return Ok(await this.usurioRepository.GetUsuarioPorId(id));
    }

    [HttpPost]
    public async Task<IActionResult> InsertUsuario([FromBody] Usuario usuario){
        if(usuario == null) return BadRequest();
        return Created("creado", await this.usurioRepository.InsertUsuario(usuario));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario){
        if(usuario == null) return BadRequest();
        await this.usurioRepository.UpdateUsuario(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> UpdateUsuario(int id){
        await this.usurioRepository.DeleteUsuario(id);
        return NoContent();
    }
}
