using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLiCrack
{
    internal class Information
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("groupTitle")]
        public string GroupTitle { get; set; }
    }
}
