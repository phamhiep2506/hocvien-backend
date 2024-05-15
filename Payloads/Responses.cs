using System.Text.Json.Serialization;
using Interfaces.IPayloads;

namespace Payloads;

public class Responses : IResponses
{
    public int status { get; set; }
    public string? messages { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? data { get; set; }

    public IResponses StatusMessages(int status, string messages)
    {
        this.status = status;
        this.messages = messages;

        return this;
    }

    public IResponses StatusMessagesData(
        int status,
        string messages,
        object data
    )
    {
        this.status = status;
        this.messages = messages;
        this.data = data;

        return this;
    }
}
