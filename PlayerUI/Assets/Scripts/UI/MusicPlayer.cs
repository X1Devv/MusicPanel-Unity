using UnityEngine;
using UnityEngine.UI;
using Game.Audio;
using TMPro;

namespace Game.UI
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button skipButton;
        [SerializeField] private Button prevButton;
        [SerializeField] private Button randomButton;
        [SerializeField] private TextMeshProUGUI trackNameText;
        [SerializeField] private TextMeshProUGUI remainingTimeText;

        private AudioSystem audioSystem;

        void Start()
        {
            AudioClip[] playlist = Resources.LoadAll<AudioClip>("Audio");
            audioSystem = gameObject.AddComponent<AudioSystem>();
            audioSystem.Initialize(playlist);

            playButton.onClick.AddListener(OnPlayButtonClicked);
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
            skipButton.onClick.AddListener(OnSkipButtonClicked);
            prevButton.onClick.AddListener(OnPrevButtonClicked);
            randomButton.onClick.AddListener(OnRandomButtonClicked);
        }

        void Update()
        {
            trackNameText.text = audioSystem.GetCurrentTrackName();
            float remainingTime = audioSystem.GetRemainingTime();
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            remainingTimeText.text = $"{minutes:00}:{seconds:00}";
        }

        private void OnPlayButtonClicked()
        {
            audioSystem.Play();
        }

        private void OnPauseButtonClicked()
        {
            audioSystem.Pause();
        }

        private void OnSkipButtonClicked()
        {
            audioSystem.NextTrack();
        }

        private void OnPrevButtonClicked()
        {
            audioSystem.PreviousTrack();
        }

        private void OnRandomButtonClicked()
        {
            audioSystem.PlayRandomTrack();        
        }
    }
}