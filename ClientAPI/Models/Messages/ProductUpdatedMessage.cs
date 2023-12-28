using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ClientAPI.Models.Messages;

public class ProductUpdatedMessage : ValueChangedMessage<string>
{
    public ProductUpdatedMessage(string value = "") : base(value)
    {
    }
}