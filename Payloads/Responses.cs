using System.Text.Json.Serialization;
using Interfaces.IPayloads;

namespace Payloads;

public class Responses : IResponses
{
    public int Status { get; set; }
    public string? Messages { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Data { get; set; }

    public IResponses StatusMessages(int status, string messages)
    {
        Status = status;
        Messages = messages;

        return this;
    }

    public IResponses StatusMessagesData(
        int status,
        string messages,
        object data
    )
    {
        Status = status;
        Messages = messages;
        Data = data;

        return this;
    }
}
