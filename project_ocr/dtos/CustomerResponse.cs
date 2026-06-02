namespace project_ocr.dtos;
public record CustomerResponse(
    string CompanyName,
    string TaxCode,
    string? Status
);