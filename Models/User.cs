using System.ComponentModel.DataAnnotations;

namespace Reddit.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();


        public int UserID { get; set; }
        public ICollection<Community> SubscribedCommunities { get; set; }
    }
}