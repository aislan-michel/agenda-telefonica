namespace AgendaTelefonica.Console.Entities;

public abstract class Notification
{
    protected readonly List<string> _notifications = new();
    public IEnumerable<string> Notifications => _notifications;
    public bool HaveNotifications => _notifications.Count > 0;
}