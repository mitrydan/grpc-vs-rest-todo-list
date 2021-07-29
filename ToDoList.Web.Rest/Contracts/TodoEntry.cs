using System;

namespace ToDoList.Web.Rest.Contracts
{
	public sealed record TodoEntry(
		long Id,
		DateTime CreatedDateTime,
		DateTime? CompletedDateTime,
		string ActionTitle,
		string ActionDescription
	);
}
