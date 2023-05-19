using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("tb_m_accounts")]
    public class Account : BaseEntity
    {
        [Column("password", TypeName = "nvarchar(max)")]
        public string Password { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("otp")]
        public int OTP { get; set; }
        [Column("is_used")]
        public bool IsUsed { get; set; }
        [Column("expired_time")]
        DateTime ExpiredTime { get; set; }

        // Cardinality
        public Employee? Employee { get; set; }

        public ICollection<Education>? Educations { get; set; }

        public ICollection<AccountRole>? AccountRoles { get; set; }

    }
}
