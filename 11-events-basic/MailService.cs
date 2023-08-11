namespace EventsModels;

public class MailService
{
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        System.Console.WriteLine($"Mail Service : Sending {e.Video.Title}'s copy to Email");
    }
}
