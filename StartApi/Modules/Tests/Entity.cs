
// using StartApi.Core;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace StartApi.Modules.Company;

// public class Company : AuditableEntity
// {
// 	public string CompanyName { get; set; }=null!;
// 	public string CompanyCode { get; set; }=null!;
// 	public string? BillingAddress { get; set; }
// 	public string? ShippingAddress { get; set; }
// 	public string? Website { get; set; }
// 	public string? Notes { get; set; }

// }

// public class CompanyConfig : IEntityTypeConfiguration<Company>
// {
//     public void Configure(EntityTypeBuilder<Company> builder)
//     {
// 	    builder.Property(m => m.CompanyName)
// 		    .HasMaxLength(100);
            
// 	    builder.Property(m => m.CompanyCode)
// 		    .HasMaxLength(50);

// 	    builder.Property(m => m.BillingAddress)
// 		    .HasMaxLength(255);

// 	    builder.Property(m => m.ShippingAddress)
// 		    .HasMaxLength(255);

// 	    builder.Property(m => m.Website)
// 		    .HasMaxLength(150);

// 	    builder.Property(m => m.Notes)
// 		    .HasMaxLength(500);

	
//     }
// }