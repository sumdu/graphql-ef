using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        
        public TransactionTypeEnum TransactionType { get; set; }
        
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [StringLength(300, ErrorMessage = "Name of transaction must be 300 characters or less")]
        public string Name { get; set; }

        [DefaultValue(2022)]
        [Range(2022, 2030)]
        public int Year { get; set; } = DateTime.Now.Year;
        
        [Range(1, 12)]
        public int Month { get; set; } = DateTime.Now.Month;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public RecurrenceTypeEnum? RecurrenceType { get; set; }

        //public int? RecurrenceDayOfWeek { get; set; }
        //public int? RecurrenceDay { get; set; }
        //public int? RecurrenceMonth { get; set; }

        public DateTime? TransactionDate { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        
        public DateTime? DateUpdated { get; set; }
        
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        
        public int? UpdatedById { get; set; }
        public virtual User UpdatedBy { get; set; }
    }
}
