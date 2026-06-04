namespace projectCs.Dtos;

public record DocumentRequestDto(
    long CustomerId,
    long UserId,
    string DocumentType,
    string ReferenceNumber,
    string IssueDate,
    string PartnerName,
    string? PartnerTaxCode,
    decimal TotalAmount,
    string FilePath
);
