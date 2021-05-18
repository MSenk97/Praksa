namespace Models.Common
{
    public interface IAdvert
    {
        int AdvertID { get; set; }
        int CategoryID { get; set; }
        string Condition { get; set; }
        int DeliveryID { get; set; }
        string Description { get; set; }
        int Price { get; set; }
        string Title { get; set; }
        int UserID { get; set; }
    }
}