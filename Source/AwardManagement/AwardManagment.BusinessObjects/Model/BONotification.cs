namespace AwardManagment.BusinessObjects.Model
{
    public partial class BONotification
    {
        public System.Guid NotificationID { get; set; }
        public bool IsCompleted { get; set; }
        public string Details { get; set; }
        public System.Guid UserId { get; set; }
        public virtual BOUser User { get; set; }
    }
}
