using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel
{
    public class Comics
    {
        public Comics()
        {

        }
        public Comics(string Title, string ImageUrl)
        {
            this.Title = Title;
            this.ImageUrl = ImageUrl;
        }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
