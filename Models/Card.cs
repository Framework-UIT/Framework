namespace Framework.Models
{
    public class Card
    {
        public static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ImgUrl { get; set; }

        public Card(string name, string des, string cat_id, string img_url)
        {
            IdCounter++;
            this.Id = IdCounter;
            this.Name = name;
            this.Description = des;
            this.CategoryId = cat_id;
            this.ImgUrl = img_url;
        }

        public Card()
        {
            IdCounter++;
            this.Id = IdCounter;
            this.Name = "New Name " + IdCounter.ToString();
            this.Description = "New Description " + IdCounter.ToString();
            this.CategoryId = "New Cat" + IdCounter.ToString();
            this.ImgUrl = "New ImgUrl " + IdCounter.ToString();

        }
    }
}