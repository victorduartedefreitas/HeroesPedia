using System;

namespace HeroesPedia.Domain.Models
{
    public class Image
    {
        public string Url { get; set; }
        public Uri Uri
        {
            get
            {
                return new Uri(Url);
            }
        }
    }
}
