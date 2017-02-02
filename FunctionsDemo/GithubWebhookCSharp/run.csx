using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log, IAsyncCollector<string> outputQueue)
{
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Extract github comment from request body
    string gitHubComment = data?.comment?.body;
    string userUrl = data?.comment?.user?.url;

    //log.Info($"Comment: {gitHubComment}");

    //var json = await req.Content.ReadAsStringAsync();
    //log.Info($"Json: {json}");

    //await outputQueue.AddAsync(json);
    await outputQueue.AddAsync($"{userUrl}:{gitHubComment}");

    return req.CreateResponse(HttpStatusCode.OK,"Okay");
}