
using projectCs.Entity;

namespace projectCs.Data;
public interface IDocumentRepository
{
    void Add(Document document);
    void SaveChanges();
}
