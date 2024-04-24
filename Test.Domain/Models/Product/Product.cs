using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Domain.Models.Product;

public class Product:BaseEntity
{
    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(55,ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    [MinLength(5,ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر داشته باشد")]
    public string Name { get; set; }

    [Display(Name = "تلفن کاربر")]
    public string ManufacturePhone { get; set; }

    [Display(Name = "ایمیل کاربر")]
    public string ManufactureEmail { get; set; }

    public bool IsAvailable { get; set; } = true;

    public int UserId { get; set; }
    #region Rel
    [ForeignKey("UserId")]
    public User.User User { get; set; }

    #endregion
}