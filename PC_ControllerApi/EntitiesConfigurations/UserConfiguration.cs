using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_ControllerApi.EntitiesConfigurations;
using PC_ControllerApi.Models;

namespace PC_ControllerApi.EntityBuilders
{
    public class UserConfiguration<T> : BaseEntityConfiguration<T> where T : User
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(36).HasColumnName("user_name");
            builder.Property(p => p.AdditionalInfo).HasColumnName("additional_info").HasMaxLength(300);
            builder.Property(p => p.PC_Id).HasColumnName("pc_id").IsRequired();
            builder.ToTable("user_info");
        }
    }
}
