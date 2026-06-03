using Microsoft.AspNetCore.Mvc;
using projectCs.Service;
using projectCs.Entity;

[ApiController]
[Route("/document")]
public class DocumentController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public string getType()
    {
        return "OK";
    }
    [HttpGet("type")]

    public IActionResult getDocumentType()
    {
        var types = Enum.GetNames(typeof(Document.DocumentType)).ToList();
        return Ok(types);
    }
}
