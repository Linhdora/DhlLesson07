using System.ComponentModel.DataAnnotations;
namespace DhlLesson07DemoLab.Models
{
    public class DhlAccount
    {
        [Key]
        public int Id { get; set; }
        [
            Display(Name="Họ và tên"),
            Required(ErrorMessage ="Họ không được để trống"),
            MinLength(6,ErrorMessage ="Họ tên ít nhất là 6 kí tự"),
            MaxLength(20,ErrorMessage ="Hộ tên tối đa là 20 kí tự")
        ]
        public string FullName { get; set; }
        [   
            Display(Name="Địa chỉ email"),
            Required(ErrorMessage ="Địa chỉ email không được để trống"),
            EmailAddress(ErrorMessage ="Địa chỉ email không đúng định dạng"),
            DataType(DataType.EmailAddress)

        ]
        public string Email { get; set; }
        [
            Display(Name ="Số điện thoại"),
            DataType(DataType.PhoneNumber),
            RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage ="Số điện thoại không đúng định dạng")
            ,Required(ErrorMessage ="Số không được để trống")  
            ]
        public string Phone { get; set; }
        [
            Display(Name ="Địa chỉ thường trú")
            ,Required(ErrorMessage ="Địa chỉ không được để trống"),
            StringLength(35,ErrorMessage = "Địa chỉ tối đa là 35 kí tự")
            ]
        public string Address { get; set; }
        [Display(Name ="Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name ="Ngày sinh"),
            Required(ErrorMessage ="Ngày sinh không được để trống"),

            DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name ="Giới tính")]
        public string Gender { get; set; }
        [Display(Name ="Mật khẩu")
            ,DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Link Facebook cá nhân")
            ,Required(ErrorMessage ="Link Facebook không được để trống"),
            Url(ErrorMessage ="URL phải đúng định dạng")]
        public string Facebook { get; set; }

    }
}
