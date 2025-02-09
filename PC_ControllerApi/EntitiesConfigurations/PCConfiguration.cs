using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_ControllerApi.Models;

namespace PC_ControllerApi.EntitiesConfigurations
{
    public class PCConfiguration<T> : BaseEntityConfiguration<T> where T : PC
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.PCName).HasColumnName("pc_name");
            builder.ToTable("pc_info");
        }
    }
}
