using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class Card
    {
        public int Id { get; set; }
        // [Required]
        // [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ImgUrl { get; set; }

        public Card(int Id, string name, string des, string cat_id, string img_url)
        {

            this.Id = Id;
            this.Name = name;
            this.Description = des;
            this.CategoryId = cat_id;
            this.ImgUrl = img_url;
        }
    }
}