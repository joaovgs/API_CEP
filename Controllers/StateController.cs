using Microsoft.AspNetCore.Mvc;

namespace WebApiAtvd.Controllers;

[ApiController]
[Route("[controller]")]
public class StateController : ControllerBase
{
    private readonly ILogger<StateController> _logger;

    public StateController(ILogger<StateController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Estado")]
    public IEnumerable<string> Estados([FromHeader] string sigla)    
    {
        List<Estado> estados = DataLoad.Estados();
        var objEstado = estados.Where(e => e.country_code == sigla);
        var nome = objEstado.Select(e => e.name);
        return nome; 
    }
}
