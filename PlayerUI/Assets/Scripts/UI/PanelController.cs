using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private Button openButton;
        [SerializeField] private Button closeButton;
        private Animator animator;
        private bool hasOpenedOnce = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            openButton.onClick.AddListener(OnOpenButtonClicked);
            closeButton.onClick.AddListener(OnCloseButtonClicked);

            animator.SetBool("Activate", false);
            animator.SetBool("Close", false);
        }

        private void OnOpenButtonClicked()
        {
            if (!hasOpenedOnce)
            {
                animator.SetBool("Activate", true);
                hasOpenedOnce = true;
            }
            else
            {
                animator.SetBool("Close", false);
            }
        }

        private void OnCloseButtonClicked()
        {
            if (hasOpenedOnce)
                animator.SetBool("Close", true);
        }
    }
}