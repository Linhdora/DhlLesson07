using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DhlLesson07DemoLab.Models
{
    public class DhlProduct : IValidatableObject
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(150, MinimumLength = 6,
            ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { set; get; }

        // Lưu tên file ảnh sau khi upload
        public string? Image { set; get; }

        [NotMapped]
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        [Display(Name = "Hình ảnh")]
        public IFormFile ImageFile { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(0, 100000, ErrorMessage = "Giá phải từ 0 đến 100000")]
        [Display(Name = "Giá")]
        public float? Price { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập giá khuyến mãi")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        [Display(Name = "Giá khuyến mãi")]
        public float? SalePrice { set; get; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int? CategoryId { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        [StringLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (Price.HasValue && SalePrice.HasValue && SalePrice > Price * 0.9f)
            {
                yield return new ValidationResult(
                    "Giá khuyến mãi phải nhỏ hơn giá chuẩn ít nhất 10%",
                    new[] { nameof(SalePrice) });
            }

            if (!string.IsNullOrEmpty(Description))
            {
                var badWords = new[] { "die", "admin", "fack" };
                var found = badWords.FirstOrDefault(w =>
                    Description.Contains(w, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    yield return new ValidationResult(
                        $"Mô tả chứa từ nhạy cảm: \"{found}\"",
                        new[] { nameof(Description) });
                }
            }
        }
    }
}