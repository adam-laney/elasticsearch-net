﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Gets the current Watcher metrics
		/// </summary>
		WatcherStatsResponse WatcherStats(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null);

		/// <inheritdoc />
		WatcherStatsResponse WatcherStats(IWatcherStatsRequest request);

		/// <inheritdoc />
		Task<WatcherStatsResponse> WatcherStatsAsync(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc />
		Task<WatcherStatsResponse> WatcherStatsAsync(IWatcherStatsRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public WatcherStatsResponse WatcherStats(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null) =>
			WatcherStats(selector.InvokeOrDefault(new WatcherStatsDescriptor()));

		/// <inheritdoc />
		public WatcherStatsResponse WatcherStats(IWatcherStatsRequest request) =>
			DoRequest<IWatcherStatsRequest, WatcherStatsResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<WatcherStatsResponse> WatcherStatsAsync(
			Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null,
			CancellationToken ct = default
		) => WatcherStatsAsync(selector.InvokeOrDefault(new WatcherStatsDescriptor()), ct);

		/// <inheritdoc />
		public Task<WatcherStatsResponse> WatcherStatsAsync(IWatcherStatsRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IWatcherStatsRequest, WatcherStatsResponse>
				(request, request.RequestParameters, ct);
	}
}
