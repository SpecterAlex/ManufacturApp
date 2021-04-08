using Newtonsoft.Json;

namespace ColmenApp.Models.Responses
{
    public class ResponseApi<T>
    {
		private T _data;
		private string _status = "success";
		private string _message;

		[JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
		public string Status
		{
			get { return _status; }
			set { _status = value; }
		}

		[JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		[JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
		public T data
		{
			get { return _data; }
			set { _data = value; }
		}

		public ResponseApi(ref T data)
		{
			_data = data;
		}
    }
}
