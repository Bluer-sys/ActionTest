using CsvParser.GoogleSheet;
using Google.Apis.Requests;

namespace CsvParser.Utilities;

// https://developers.google.com/sheets/api/limits
// This version of the Google Sheets API has a limit of 500 requests per 100 seconds per project,
// and 100 requests per 100 seconds per user.
// Limits for reads and writes are tracked separately. There is no daily usage limit.
public static class ClientServiceRequestExtensions
{
	public static async Task<TResponse> ExecuteDelayedAsync<TResponse>(
		this ClientServiceRequest<TResponse> request, 
		TimeSpan delay = default)
	{
		await WaitDelayAsync(delay).ConfigureAwait(false);
		return await request.ExecuteAsync(CancellationToken.None).ConfigureAwait(false);
	}
        
	public static async Task<TResponse> ExecuteDelayedAsync<TResponse>(
		this ClientServiceRequest<TResponse> request, 
		CancellationToken cancellationToken, 
		TimeSpan delay = default)
	{
		await WaitDelayAsync(delay).ConfigureAwait(false);
		return await request.ExecuteAsync(cancellationToken).ConfigureAwait(false);
	}

	private static async Task WaitDelayAsync(TimeSpan delay)
	{
		if (delay == default)
			delay = TimeSpan.FromSeconds( SheetConstants.DefaultDelayPerRequest );

		await Task.Delay( delay );
	}
}