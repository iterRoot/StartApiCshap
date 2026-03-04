using StartApi.Core;
namespace StartApi.Modules.Tools.Fields;

public interface IFieldsRepository : IRepository<Fields>
{

}
public class FieldsRepository : Repository<Fields>, IFieldsRepository
{
    public FieldsRepository(MyDbContext context) : base(context)
    {

    }
    
}