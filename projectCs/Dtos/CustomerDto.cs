namespace projectCs.Dtos;

public record CustomerDto(
    long id,
    string CompanyName,
    string TaxCode,
    string status
    );
