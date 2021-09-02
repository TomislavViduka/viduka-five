using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VidukaFiveNews.Models
{
    public class LoginResponse
    {
        //[JsonPropertyName("id")]
        //public int Id { get; set; }

        //[JsonPropertyName("email")]
        //public string Email { get; set; }

        //[JsonPropertyName("name")]
        //public string Name { get; set; }

        //[JsonPropertyName("accessToken")]
        //public string AccessToken { get; set; }

        //[JsonPropertyName("refreshToken")]
        //public string RefreshToken { get; set; }

        [JsonPropertyName("author")]
        public Author Author { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }


        public LoginResponse(Author author, string token)
        {
            this.Author = author;
            this.Token = token;
        }

    }
}
