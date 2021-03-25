using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess.EntityConfigurations
{
    internal class TodoEntryConfiguration : IEntityTypeConfiguration<TodoEntry>
    {
        public void Configure(EntityTypeBuilder<TodoEntry> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedDateTime)
                .IsRequired();

            builder.Property(p => p.ActionTitle)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
