namespace DADH.Model
{
    public class OrderSearch
    {
        public string? keyword { get; set; }
        public DateTime? start_date { set; get; }
        public DateTime? end_date { set; get; }
        public int page_number { set; get; } = 1;
        public int page_size { set; get; } = 30;
   
    }
}
