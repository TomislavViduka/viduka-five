using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VidukaFiveNews.Models
{
    public class ArticlePostRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }


        [JsonPropertyName("content")]
        public string Content { get; set; }


        [JsonPropertyName("image")]
        public string Image { get; set; }


        public ArticlePostRequest()
        {
        }
    }
}