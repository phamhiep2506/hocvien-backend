using System.Text.Json.Serialization;

namespace Payloads;

public class Responses
{
    public int status { get; set; }
    public string? messages { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? data { get; set; }

    public Responses StatusMessages(int status, string messages)
    {
        this.status = status;
        this.messages = messages;

        return this;
    }

    public Responses StatusMessagesData(
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
