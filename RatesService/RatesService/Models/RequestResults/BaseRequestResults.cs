namespace RatesService.Models.RequestResults
{
    public class BaseRequestResultsList<T>
    {
        public List<T> Data { get; set; }
        public Status Status { get; set; }
        
    }
    public class Status
    {
        public string TimeStamp { get; set; }
        public int Error_Code { get; set; }
        public string Error_Message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
    }
}
