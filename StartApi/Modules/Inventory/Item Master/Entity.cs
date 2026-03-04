
using StartApi.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartApi.Modules.Inventory.ItemMaster;

public class ItemMaster : AuditableEntity
{
	public string ItemMasterName { get; set; }=null!;
	public string ItemMasterCode { get; set; }=null!;
	public string? Uom { get; set; }
	public decimal Price { get; set; }
	public string? Currency { get; set; }


	public string? Notes { get; set; }

}

public class ItemMasterConfig : IEntityTypeConfiguration<ItemMaster>
{
    public void Configure(EntityTypeBuilder<ItemMaster> builder)
    {
	    builder.Property(m => m.ItemMasterName)
		    .HasMaxLength(100);
            
	    builder.Property(m => m.ItemMasterCode)
		    .HasMaxLength(50);

	    builder.Property(m => m.Uom)
		    .HasMaxLength(255);

	    builder.Property(m => m.Price)
		    .HasColumnType("decimal(18,2)");

	    builder.Property(m => m.Currency)
		    .HasMaxLength(10);

	    builder.Property(m => m.Notes)
		    .HasMaxLength(500);

	
    }
}