namespace Notifications.Contracts.Base
{
    public interface IBaseEvent 
    {
        byte[] Data { get; set; }
    }
}
