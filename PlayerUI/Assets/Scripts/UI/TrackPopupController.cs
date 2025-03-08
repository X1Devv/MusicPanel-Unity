using UnityEngine;
using TMPro;
using Game.Audio;

namespace Game.UI
{
    public class TrackPopupController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI trackNameText;
        [SerializeField] private Animator popupAnimator;
        [SerializeField] private Animator diskAnimator;
        private AudioSystem audioSystem;

        private void Awake()
        {
            popupAnimator.SetBool("Appearances", false);
            diskAnimator.SetBool("Manifestations", false);
        }

        public void Initialize(AudioSystem system)
        {
            audioSystem = system;
        }

        public void ShowTrackPopup()
        {
            diskAnimator.SetBool("Manifestations", true);

            trackNameText.text = audioSystem.GetCurrentTrackName();

            StartCoroutine(ShowSequence());
        }

        private System.Collections.IEnumerator ShowSequence()
        {
            yield return new WaitForSeconds(1f);

            popupAnimator.SetBool("Appearances", true);

            yield return new WaitForSeconds(2f);

            popupAnimator.SetBool("Appearances", false);
            
            yield return new WaitForSeconds(1f);

            diskAnimator.SetBool("Manifestations", false);
        }
    }
}