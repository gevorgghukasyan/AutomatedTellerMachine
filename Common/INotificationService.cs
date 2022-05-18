namespace Common
{
    public interface INotificationService
    {
        void SendMessage(User user, string message);
    }
}