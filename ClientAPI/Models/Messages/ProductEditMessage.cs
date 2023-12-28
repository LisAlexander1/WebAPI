using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ClientAPI.Models.Messages;

public class ProductEditMessage : ValueChangedMessage<Product>
{
    public ProductEditMessage(Product value) : base(value)
    {
    }
}