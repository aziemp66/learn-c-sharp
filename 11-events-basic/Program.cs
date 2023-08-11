using EventsModels;

class Program
{
    static void Main(string[] args)
    {
        var video = new Video() { Title = "Video 1" };
        var mailService = new MailService(); //subscriber
        var messageService = new MessageService();
        var videoEncoder = new VideoEncoder(); //publisher

        //subscribe
        videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
        videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

        videoEncoder.Encode(video);
    }
}
