using System.ComponentModel.DataAnnotations;

namespace Test.Domain.ViewModel.User;

public class UserViewModel
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    public string Email { get; set; }

    [Display(Name = "شماره تلفن همراه")]
    [MaxLength(11)]
    public string PhoneNumber { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    [MinLength(4, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد")]
    public string PassWord { get; set; }

    [Display(Name = "تایید رمز عبور")]
    [Compare("PassWord")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string ConfirmPassword { get; set; }


}