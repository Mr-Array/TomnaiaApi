﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class Review
    {
        [Key]
        public string ReviewId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public int Rating { get; set; } // Assuming a rating out of 5

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string RideId { get; set; }

        [ForeignKey(nameof(RideId))]
        public Ride Ride { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
