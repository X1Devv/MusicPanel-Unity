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
        [SerializeField] private TrackPopupController trackPopupController;

        private AudioSystem audioSystem;

        void Start()
        {
            audioSystem = gameObject.AddComponent<AudioSystem>();
            trackPopupController.Initialize(audioSystem);

            playButton.onClick.AddListener(() => HandleButtonAction(audioSystem.Play));
            pauseButton.onClick.AddListener(() => HandleButtonAction(audioSystem.Pause, false));
            skipButton.onClick.AddListener(() => HandleButtonAction(audioSystem.NextTrack));
            prevButton.onClick.AddListener(() => HandleButtonAction(audioSystem.PreviousTrack));
            randomButton.onClick.AddListener(() => HandleButtonAction(audioSystem.PlayRandomTrack));
        }

        void Update()
        {
            trackNameText.text = audioSystem.GetCurrentTrackName();
            float remainingTime = audioSystem.GetRemainingTime();
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            remainingTimeText.text = $"{minutes:00}:{seconds:00}";
        }

        private void HandleButtonAction(System.Action action, bool showPopup = true)
        {
            action.Invoke();
            if (showPopup) trackPopupController.ShowTrackPopup();
        }
    }
}