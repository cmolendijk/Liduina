using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Diagnostics;

namespace hangoverApp.Repositories
{
	public class ButtonRepository : BaseRepository
    {
		public async void ExecuteButton(int buttonId)
		{
			try
			{
				var client = new RestClient(BASEENDPOINT);
				var request = new RestRequest("Button/ExecuteButton?buttonId=" + buttonId, Method.GET);

				await client.Execute(request);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error retrieving data: [{ex.Message}]");
			}
		}
    }
}
