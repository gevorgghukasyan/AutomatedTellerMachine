using Common.Entities;

namespace Common
{
	public interface INotificationService
	{
		void SendMessage(User user, string message);
	}
}