using System.ComponentModel;

namespace BookStore.WebMvc.Books;

public sealed class GetBooksModel
{
    [DisplayName("Tiêu đề")]
    public string Title { get; set; }
    [DisplayName("Tác giả")]
    public string Author { get; set; }
    [DisplayName("Giá")]
    public decimal Price { get; set; }
    [DisplayName("Số lượng")]
    public int Quantity { get; set; }
}