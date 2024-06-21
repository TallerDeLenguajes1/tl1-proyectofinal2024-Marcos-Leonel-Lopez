public static class Validation
{
    public static async Task<bool> CheckInternetConnection()
    {
        try
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            HttpResponseMessage response = await client.GetAsync("http://www.google.com");
            return response.IsSuccessStatusCode;

        }
        catch
        {
            return false;
        }
    }
}

