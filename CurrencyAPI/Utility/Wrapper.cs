namespace CurrencyAPI.Utility
{
    public class Wrapper<T>
    {
        public List<T> data { get; set; }
        public long timestamp { get; set; }
    }
}
