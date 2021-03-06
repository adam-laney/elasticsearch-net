﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.XPack.MachineLearning.DeleteCalendar
{
	public class DeleteCalendarUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await DELETE("/_ml/calendars/calendar_id")
			.Fluent(c => c.MachineLearning.DeleteCalendar("calendar_id", p => p))
			.Request(c => c.MachineLearning.DeleteCalendar(new DeleteCalendarRequest("calendar_id")))
			.FluentAsync(c => c.MachineLearning.DeleteCalendarAsync("calendar_id", p => p))
			.RequestAsync(c => c.MachineLearning.DeleteCalendarAsync(new DeleteCalendarRequest("calendar_id")));
	}
}
