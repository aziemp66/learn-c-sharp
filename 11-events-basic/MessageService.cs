namespace EventsModels;

public class MessageService
{
    public void OnVideoEncoded(object source, VideoEventArgs args)
    {
        System.Console.WriteLine(
            $"Message Service: Sending {args.Video.Title}'s notification Message"
        );
    }
}
