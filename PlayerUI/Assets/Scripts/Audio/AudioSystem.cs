using UnityEngine;

namespace Game.Audio
{
    public class AudioSystem : MonoBehaviour
    {
        private AudioSource audioSource;
        private AudioClip[] playlist;
        private int currentTrackIndex = 0;
        private bool isPlaying = false;

        public void Initialize(AudioClip[] tracks)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            playlist = tracks;
            audioSource.clip = playlist[currentTrackIndex];
            audioSource.loop = false;
        }

        public void Play()
        {
            audioSource.Play();
            isPlaying = true;
        }

        public void Pause()
        {
            audioSource.Pause();
            isPlaying = false;
        }

        public void Stop()
        {
            audioSource.Stop();
            isPlaying = false;
        }

        public void NextTrack()
        {
            currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
            audioSource.clip = playlist[currentTrackIndex];
            if (isPlaying)
            {
                audioSource.Play();
            }
        }

        public void PreviousTrack()
        {
            currentTrackIndex = (currentTrackIndex - 1 + playlist.Length) % playlist.Length;
            audioSource.clip = playlist[currentTrackIndex];
            if (isPlaying)
            {
                audioSource.Play();
            }
        }

        public void PlayRandomTrack()
        {
            currentTrackIndex = Random.Range(0, playlist.Length);
            audioSource.clip = playlist[currentTrackIndex];
            audioSource.Play();
            isPlaying = true;
        }

        void Update()
        {
            if (isPlaying && !audioSource.isPlaying && playlist.Length > 0)
            {
                NextTrack();
            }
        }

        public string GetCurrentTrackName()
        {
            if (playlist.Length > 0)
            {
                return playlist[currentTrackIndex].name;
            }
            return "None";
        }

        public float GetRemainingTime()
        {
            if (audioSource == null || playlist.Length == 0)
            {
                return 0f;
            }
            return audioSource.clip.length - audioSource.time;
        }
    }
}