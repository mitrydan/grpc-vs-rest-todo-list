using System;

namespace ToDoList.Domain.Models
{
    public sealed record TodoEntry(
        long Id,
        DateTime CreatedDateTime,
        DateTime? CompletedDateTime,
        string ActionTitle,
        string ActionDescription
    );
}
