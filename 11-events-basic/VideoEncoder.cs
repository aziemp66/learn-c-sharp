namespace EventsModels;

public class VideoEventArgs : EventArgs
{
    public Video Video { get; set; }
}

public class VideoEncoder
{
    // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

    //Event Handler
    //Event Handler<TEventArgs>
    public event EventHandler<VideoEventArgs> VideoEncoded;
    public event EventHandler VideoEncodedEmpty;

    public void Encode(Video video)
    {
        Console.WriteLine("Encoding Video...");
        Thread.Sleep(3 * 1000);

        OnVideoEncoded(video);
    }

    protected virtual void OnVideoEncoded(Video video)
    {
        if (VideoEncoded != null)
        {
            VideoEncoded(this, new VideoEventArgs() { Video = video });
            return;
        }
    }
}
