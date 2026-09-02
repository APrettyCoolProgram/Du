// Get the HTML source of a file.
public static string GetSource(string url)
{
    var webRequest       = (HttpWebRequest)WebRequest.Create(url);
    webRequest.Accept    = "text/html, application/xhtml+xml, */*";
    webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
    var webResponse      = (HttpWebResponse)webRequest.GetResponse();

    var htmlSource = "";

    using(Stream dataStream = webResponse.GetResponseStream())
    {
        if(dataStream != null)
        {
            using(var streamReader = new StreamReader(dataStream))
                htmlSource = streamReader.ReadToEnd();
        }
    }

    return htmlSource;
}