using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ColmenApp.Models.Responses.Pagination
{
    public class ResponsePaginate<T>
    {
        private ObservableCollection<T> _data;

        [JsonProperty(PropertyName = "current_page", NullValueHandling = NullValueHandling.Ignore)]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<T> data
        {
            get { return _data; }
            set { _data = value; }
        }

        [JsonProperty(PropertyName = "first_page_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstPageUrl { get; set; }

        [JsonProperty(PropertyName = "from", NullValueHandling = NullValueHandling.Ignore)]
        public int From { get; set; }

        [JsonProperty(PropertyName = "last_page", NullValueHandling = NullValueHandling.Ignore)]
        public int LastPage { get; set; }

        [JsonProperty(PropertyName = "last_page_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LastPageUrl { get; set; }

        [JsonProperty(PropertyName = "next_page_url", NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageUrl { get; set; }

        [JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "per_page", NullValueHandling = NullValueHandling.Ignore)]
        public int PerPage { get; set; }

        [JsonProperty(PropertyName = "prev_page_url", NullValueHandling = NullValueHandling.Ignore)]
        public object PrevPageUrl { get; set; }

        [JsonProperty(PropertyName = "to", NullValueHandling = NullValueHandling.Ignore)]
        public int To { get; set; }

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        public ResponsePaginate(ref ObservableCollection<T> data)
        {
            _data = data;
        }
    }
}
