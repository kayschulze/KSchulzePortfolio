using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KSchulzePortfolio.Models
{
    public class GitRepo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public static List<GitRepo> GetGitRepos()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://api.github.com");

            var request = new RestRequest("users/kayschulze/repos", Method.GET);
            //client.Authenticator = new HttpBasicAuthenticator("EnvironmentVariable.AccountSid", "EnvironmentVariable.AuthToken");
            //request.Resource = "users/kayschulze/repos";

            //IRestResponse response = client.Execute(request);

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var gitRepoList = JsonConvert.DeserializeObject<List<GitRepo>>(jsonResponse["messages"].ToString());
            return gitRepoList;
        }

        public static GitRepo GetOneGitRepo()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://api.github.com");

            var request = new RestRequest("users/kayschulze/repos", Method.GET);
            //client.Authenticator = new HttpBasicAuthenticator("EnvironmentVariable.AccountSid", "EnvironmentVariable.AuthToken");
            //request.Resource = "users/kayschulze/repos";

            //IRestResponse response = client.Execute(request);

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var gitRepo = JsonConvert.DeserializeObject<GitRepo>(jsonResponse["messages"].ToString());
            return gitRepo;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
