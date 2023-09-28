namespace DADH.Model.Product
{
    public class SearchPromotionModel: SearchBase
    {
        public long warehouse_id { set; get; }
        public bool is_promotion { set; get; }
    }
}
