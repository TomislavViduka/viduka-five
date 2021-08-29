using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VidukaFiveNews.Models
{
    public class Article
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }


        [JsonPropertyName("content")]
        public string Content { get; set; }


        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("date")]
        public int Date { get; set; }

        [JsonPropertyName("authorId")]
        [ForeignKey("authorId")]
        public int AuthorId { get; set; }

        public Article()
        {
        }
    }
}