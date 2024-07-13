namespace dinks_server.Entities;
using AutoMapper;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Username { get; set; }

    [Required]
    [StringLength(256)]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    // Navigation properties
    public virtual AutoMapper.Profile Profile { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
}
