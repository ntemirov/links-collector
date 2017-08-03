using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LinksCollector.DataAccessLayer.DataModels;

namespace LinksCollector.DataAccessLayer.Configurations
{
    public class RequestDataModelMap : EntityTypeConfiguration<RequestDataModel>
    {
        public override void Map(EntityTypeBuilder<RequestDataModel> builder)
        {
            builder.ToTable("Requests");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GetUtcDate()");

            builder.Property(p => p.UpdatedAt);

            builder.Property(p => p.Url)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.RequestDate)
                .IsRequired();

            builder.Property(p => p.HyperlinksCount)
                .IsRequired();

            builder.Property(p => p.RequestProcessingTime)
                .IsRequired();
        }
    }
}
