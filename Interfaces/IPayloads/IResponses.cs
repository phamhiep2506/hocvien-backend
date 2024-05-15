namespace Interfaces.IPayloads;

public interface IResponses
{
    public IResponses StatusMessages(int status, string messages);

    public IResponses StatusMessagesData(
        int status,
        string messages,
        object data
    );
}
