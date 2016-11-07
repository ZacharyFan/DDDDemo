namespace Mall.Infrastructure.ResponseHandle
{
    public class JsonResponseReader
    {
        private readonly string _jsonData;
        public JsonResponseReader(string json)
        {
            this._jsonData = json;
        }

        public string GetString(string key)
        {
            return key;  //TODO implement。
        }
    }
}
