using Reddit.Models;
using System;
using System.Collections.Generic;



public class Community
{
    public int ComunityId { get; set; }

    public User Owner { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Post> Posts { get; set; }
    public ICollection<User> UserSubscribers { get; set; } 



}