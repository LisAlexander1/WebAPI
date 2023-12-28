using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ClientAPI.Models.Messages;

public class SaleUpdatedMessage : ValueChangedMessage<string>
{
    public SaleUpdatedMessage(string value = "") : base(value)
    {
    }
}