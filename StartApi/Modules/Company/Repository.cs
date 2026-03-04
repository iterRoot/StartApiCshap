using StartApi.Core;
namespace StartApi.Modules.Company;

public interface ICompanyRepository : IRepository<Company>
{

}
public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(MyDbContext context) : base(context)
    {

    }
    
}