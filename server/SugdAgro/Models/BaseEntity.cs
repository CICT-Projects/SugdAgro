using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TZ2401.Models
{
    public abstract class BaseEntity
    {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsPublished { get; set; }
    }
}