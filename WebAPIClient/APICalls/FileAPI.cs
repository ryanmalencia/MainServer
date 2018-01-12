namespace WebAPIClient.APICalls
{
    public class FileAPI
    {
        public static void Download(string filename, string dest)
        {
            string http = "api/file/getallagents";
            WebAPIClient.DownloadFile(http, dest);
        }
    }
}
