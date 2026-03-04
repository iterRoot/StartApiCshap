
namespace StartApi.Modules.Inventory.ItemMaster;

public class ItemMasterListResponse
{
	public string ItemMasterName { get; set; } =null!;
	public string ItemMasterCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }
    // System & Status

}
public class ItemMasterDetailResponse
{

   	public string ItemMasterName { get; set; }=null!;
	public string ItemMasterCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }
}


public class ItemMasterInsertRequest
{

   	public string ItemMasterName { get; set; }=null!;
	public string ItemMasterCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }
}

public class ItemMasterUpdateRequest
{

    public string ItemMasterName { get; set; }=null!;
	public string ItemMasterCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }

}