using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VidukaFiveNews.Models
{
    public class ArticlesListResponse
    {
        public IEnumerable<Article> Articles { get; set; }

        public int ElementCount { get; set; }


        public ArticlesListResponse()
        {
        }
    }
}