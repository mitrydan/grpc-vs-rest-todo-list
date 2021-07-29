using System;

namespace ToDoList.BenchmarkApp
{
	public sealed record TodoEntry(
		long Id,
		DateTime CreatedDateTime,
		DateTime? CompletedDateTime,
		string ActionTitle,
		string ActionDescription
	);
}
