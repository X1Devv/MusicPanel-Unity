using UnityEngine;
using TMPro;
using Game.Audio;
using System.Collections;

namespace Game.UI
{
    public class TrackPopupController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI trackNameText;
        [SerializeField] private Animator popupAnimator;
        [SerializeField] private Animator diskAnimator;

        private AudioSystem audioSystem;
        private bool isAnimating;

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
            trackNameText.text = audioSystem.GetCurrentTrackName();

            if (isAnimating) return;

            StartCoroutine(ShowSequence());
        }

        private IEnumerator ShowSequence()
        {
            isAnimating = true;

            yield return Animate(diskAnimator, "Manifestations", true, 1f);
            yield return Animate(popupAnimator, "Appearances", true, 2f);
            yield return Animate(popupAnimator, "Appearances", false, 0f);
            yield return Animate(diskAnimator, "Manifestations", false, 1f);

            isAnimating = false;
        }

        private IEnumerator Animate(Animator animator, string parameter, bool state, float delay)
        {
            animator.SetBool(parameter, state);
            yield return new WaitForSeconds(delay);
        }
    }
}