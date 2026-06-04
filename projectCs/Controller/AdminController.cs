using Microsoft.AspNetCore.Mvc;
using projectCs.Dtos;
using projectCs.Entity;
using projectCs.Data;
[ApiController]
[Route("/admin")]
public class AdminController(AppDbContext context, IDocumentRepository repo) : ControllerBase
{
    [HttpGet("user")]
    public IActionResult GetUsers()
    {
        var users = context.Users
        .Select(u => new UserDto(
            u.Id,
            u.Email,
            u.FullName,
            u.Role.ToString() ?? "unknow",
            u.Status.ToString() ?? "unknow"
            )
          ).ToList();
        return Ok(users);

    }
    [HttpPost("document/create")]
    public IActionResult CreateDocument([FromBody] projectCs.Dtos.DocumentRequestDto request)
    {
        if (!Enum.TryParse<Document.DocumentType>(request.DocumentType, out var docType))
            return BadRequest("Invalid type");

        var newDoc = new Document
        {
            CustomerId = request.CustomerId,
            UserId = request.UserId,
            Type = docType,
            ReferenceNumber = request.ReferenceNumber,
            IssueDate = DateOnly.Parse(request.IssueDate),
            PartnerName = request.PartnerName,
            PartnerTaxCode = request.PartnerTaxCode,
            TotalAmount = request.TotalAmount,
            FilePath = request.FilePath,
            Status = "PENDING"
        };

        repo.Add(newDoc);
        repo.SaveChanges();

        return Ok(new { Message = "Đã lưu qua Repository" });
    }
}
