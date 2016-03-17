using DAL.Entities;

namespace DAL.Model
{
    public class Phone : BaseEntity
    {
        public string DDD { get; set; }
        public string Number { get; set; }

        /// <summary>
        /// Relation FK
        /// </summary>
        public virtual User User { get; set; }
    }
}
