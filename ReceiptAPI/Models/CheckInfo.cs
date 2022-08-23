namespace ReceiptAPI.Models
{
    /// <summary>
    /// Информация по чеку
    /// </summary>
    public class CheckInfo
    {
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public string ProductName { get; set; }
        public decimal Money { get; set; }
    }
}
