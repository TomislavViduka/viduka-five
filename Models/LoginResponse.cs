using System;
using System.Text.Json.Serialization;

namespace VidukaFiveNews.Models
{
    public class LoginResponse
    {
    
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
