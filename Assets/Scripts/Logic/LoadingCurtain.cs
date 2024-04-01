using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1f;
        }

        public void Hide()
        {
            StartCoroutine(DoFadeIn());
        }

        private IEnumerator DoFadeIn()
        {
            float fadeTime = 0.03f;
            WaitForSeconds delay = new WaitForSeconds(fadeTime);

            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= fadeTime;
                yield return delay;
            }

            gameObject.SetActive(false);
        }
    }
}