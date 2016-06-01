using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liduina.Mobile.Repositories
{
	public abstract class BaseRepository
	{
		protected const string BASEENDPOINT = "http://hangoverapp.azurewebsites.net/oData/";

		protected async Task<TResponse> Get<TResponse>(string action)
		{
			TResponse result = default(TResponse);
			try
			{
				var client = new RestClient(BASEENDPOINT);
				var request = new RestRequest(action, Method.GET);

				var response = await client.Execute<TResponse>(request);
				result = response.Data;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error retrieving data: [{ex.Message}]");
			}
			return result;
		}

		protected async Task<int> Insert<TRequest>(string action, TRequest requestObject)
		{
			int result = default(int);
			try
			{
				var client = new RestClient(BASEENDPOINT);
				var request = new RestRequest(action, Method.POST);
				request.AddBody(requestObject);

				var response = await client.Execute<int>(request);
				result = response.Data;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error retrieving data: [{ex.Message}]");
			}
			return result;
		}
	}
}
