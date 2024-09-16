using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebMvc.Books;


public sealed class CreateBookModel
{
    [DisplayName("Tiêu đề")]
    [Required(ErrorMessage = "Vui lòng nhập tiêu đề.")]
    [MaxLength(100)]
    public string Title { get; set; }
    [DisplayName("Mô tả")]
    public string Description { get; set; }
    [DisplayName("Tác giả")]
    [Required(ErrorMessage = "Vui lòng nhập tác giả.")]
    [MaxLength(100)]
    public string Author { get; set; }
    [DisplayName("Giá bán")]
    [Required(ErrorMessage = "Vui lòng nhập giá bán.")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn hoặc bằng 0.")]
    public decimal? Price { get; set; }
    [DisplayName("Số lượng")]
    [Required(ErrorMessage = "Vui lòng nhập số lượng.")]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0.")]
    public int? Quantity { get; set; }
}