using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Extract github comment from request body
    string gitHubComment = data?.comment?.body;
    log.Info($"Comment: {gitHubComment}");

    var json = await req.Content.ReadAsStringAsync();
    log.Info($"Json: {json}");

    return req.CreateResponse(HttpStatusCode.OK, "From Github:" + gitHubComment);
}