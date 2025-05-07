using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class WhatsAppMessage
{
    public int Id { get; set; }

    public long? Timestamp { get; set; }

    public string? GroupId { get; set; }

    public string? UserId { get; set; }

    public string? MessageId { get; set; }

    public string? MessageType { get; set; }

    public string? MessageBody { get; set; }

    public string? ParticipantId { get; set; }
}
