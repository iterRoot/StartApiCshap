using StartApi.Core;
namespace StartApi.Modules.Inventory.ItemMaster;

public interface IItemMasterRepository : IRepository<ItemMaster>
{

}
public class ItemMasterRepository : Repository<ItemMaster>, IItemMasterRepository
{
    public ItemMasterRepository(MyDbContext context) : base(context)
    {

    }
    
}