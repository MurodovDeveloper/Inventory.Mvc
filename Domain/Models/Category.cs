namespace Domain.Models;

public class Category
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? CategoryImage { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}
