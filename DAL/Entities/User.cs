using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Entities
{

    /// <summary>
    /// Table properties mapping
    /// </summary>
    public class User : EntityTypeConfiguration<Model.User>
    {
        public User()
        {
            //Table name
            ToTable("User");

            //Table properties options
            HasKey(obj => obj.ID);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(obj => obj.Name)
                .HasColumnName("Name")
                .HasColumnType("Varchar")
                .IsRequired();

            Property(obj => obj.Password)
                .HasColumnName("Password")
                .HasColumnType("Varchar")
                .IsRequired();

            Property(obj => obj.Email)
                .HasColumnName("Email")
                .HasColumnType("Varchar")
                .IsRequired();

        }
    }
}
