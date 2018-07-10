using System;
using System.Runtime.Serialization;

namespace DesignPattern._06_Adapter
{
    [DataContract(Name = "适配器模式")]
    public class _06_AdapterPattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_06_AdapterPattern).GetClassName());

            var audioPlayer = new AudioPlayer();
            audioPlayer.Play("mp3", "beyond the horizon.mp3");
            audioPlayer.Play("mp4", "alone.mp4");
            audioPlayer.Play("vlc", "far far away.vlc");
            audioPlayer.Play("avi", "mind me.avi");

            Console.WriteLine();
        }
    }


    public interface IAdvancedMediaPlayer
    {
        void PlayVlc(string fileName);
        void PlayMp4(string fileName);
    }

    public class VlcPlayer : IAdvancedMediaPlayer
    {
        public void PlayVlc(string fileName) => Console.WriteLine($"Playing vlc file.Name:{fileName}");

        public void PlayMp4(string fileName) { }
    }

    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void PlayVlc(string fileName) { }

        public void PlayMp4(string fileName) => Console.WriteLine($"Playing mp4 file.Name:{fileName}");

    }

    public interface IMediaPlayer
    {
        void Play(string audioType, string fileName);
    }

    public class MediaAdapter : IMediaPlayer
    {
        private readonly IAdvancedMediaPlayer advancedMediaPlayer;
        public MediaAdapter(string audioType)
        {
            if (audioType.Contains("vlc")) advancedMediaPlayer = new VlcPlayer();
            else if (audioType.Contains("mp4")) advancedMediaPlayer = new Mp4Player();
        }
        public void Play(string audioType, string fileName)
        {
            if (audioType.Contains("vlc")) advancedMediaPlayer.PlayVlc(fileName);
            else if (audioType.Contains("mp4")) advancedMediaPlayer.PlayMp4(fileName);
        }
    }

    public class AudioPlayer : IMediaPlayer
    {
        private MediaAdapter mediaAdapter;
        public void Play(string audioType, string fileName)
        {
            if (audioType.Contains("mp3")) Console.WriteLine($"Playing mpc fileName:{fileName}");
            else if (audioType.Contains("vlc") || audioType.Contains("mp4"))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.Play(audioType, fileName);
            }
            else Console.WriteLine($"Invalid media {audioType} format not supperte");

        }
    }
}


