﻿using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.WebApi.Models.TeacherModel
{
    public class TeacherFeedBackDto
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }
        [MaxLength(20)]
        public string Tittle { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
