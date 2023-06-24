namespace Inventory.Mvc.Models
{
    public class EditImageViewModel : UploadImageViewModel
    {
        public Guid Id { get; set; }
        public string ExsitingImage { get; set; }
    }
}
