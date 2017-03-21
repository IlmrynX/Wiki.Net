namespace Wiki.Net.Model
{
    public class ApiResult<T>
    {
        public string batchcomplete { get; set; }
        public T query { get; set; }
    }
}
