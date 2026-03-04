
namespace StartApi.Modules.Tools.Fields;

public class FieldsListResponse
{
	public string FieldsName { get; set; } =null!;
	public string FieldsCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }
    // System & Status

}
public class FieldsDetailResponse
{

   	public string FieldsName { get; set; }=null!;
	public string FieldsCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }
}


public class FieldsInsertRequest
{

   	public string FieldsName { get; set; }=null!;
	public string FieldsCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }
}

public class FieldsUpdateRequest
{

    public string FieldsName { get; set; }=null!;
	public string FieldsCode { get; set; }=null!;
	public string? BillingAddress { get; set; }
	public string? ShippingAddress { get; set; }
	public string? Website { get; set; }
	public string? Notes { get; set; }

}