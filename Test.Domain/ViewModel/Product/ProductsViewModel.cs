using System.ComponentModel.DataAnnotations;

namespace Test.Domain.ViewModel.Product;

public class ProductsViewModel
{
    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(55, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    [MinLength(5, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر داشته باشد")]
    public string Name { get; set; }

    [Display(Name = "ایمیل کاربر")]
    public string ManufactureEmail { get; set; }

    public bool IsAvailable { get; set; }
    public DateTime CreateDate { get; set; } 

}