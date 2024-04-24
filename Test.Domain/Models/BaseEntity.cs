using System.ComponentModel.DataAnnotations;

namespace Test.Domain.Models;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
}