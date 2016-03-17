using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Entities
{

    /// <summary>
    /// Table properties mapping
    /// </summary>
    public class Phone : EntityTypeConfiguration<Model.Phone>
    {
        public Phone()
        {
            //Table name
            ToTable("Phone");

            //Table properties options
            HasKey(obj => obj.ID);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(obj => obj.DDD)
                .HasColumnName("DDD")
                .HasColumnType("Varchar")
                .IsRequired();

            Property(obj => obj.Number)
                .HasColumnName("Number")
                .HasColumnType("Varchar")
                .IsRequired();

            //Relationship
            HasRequired(obj => obj.User)
                .WithMany(objDependent => objDependent.Phones)
                .Map(m => m.MapKey("UserId"));



        }
    }
}
