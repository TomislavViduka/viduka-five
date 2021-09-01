using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VidukaFiveNews.Models
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public LoginRequest()
        {
        }
    }
}