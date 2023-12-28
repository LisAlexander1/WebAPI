using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ClientAPI.Models.Messages;

public class SaleEditMessage : ValueChangedMessage<Sale>
{
    public SaleEditMessage(Sale value) : base(value)
    {
    }
}