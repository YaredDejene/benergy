using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Benergy.Core.Context;

namespace Benergy.Core.Entities
{
    /// <summary>
    /// This is the base class for all database related entities. Also used in setting audit values
    /// </summary>
    public class BaseEntity
    {
        public BaseEntity()
        {
             NTContextModel contextModel = NTContext.Context;
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_user_id")]
        public string CreatedUserID { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("last_modified_user_id")]
        public string LastModifiedUserID { get; set; }

        [Column("last_modified_date")]
        public DateTime LastModifiedDate { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        public virtual void UpdateAuditFields()
        {
            NTContextModel contextModel = NTContext.Context;

            this.LastModifiedDate = DateTime.UtcNow;
            //this.LastModifiedUserID = contextModel.UserName;
        }
    }
}