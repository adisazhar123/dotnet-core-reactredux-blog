using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdisBlog.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}