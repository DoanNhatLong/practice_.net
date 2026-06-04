using projectCs.Entity;
namespace projectCs.Data;

public class DocumentRepository
(AppDbContext context
 ) : IDocumentRepository
{
    public void Add(Document document) => context.Documents.Add(document);

    public void SaveChanges() => context.SaveChanges();

}
