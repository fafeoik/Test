using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeEffect : MonoBehaviour
{
    private Tween fadeTween;

    private void Fade(float endValue, float duration, CanvasGroup canvasToFade)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasToFade.DOFade(endValue,duration);
    }

    public void FadeIn(float duration, CanvasGroup canvas)
    {
        Fade(1f, duration, canvas);
    }
    public void FadeOut(float duration, CanvasGroup canvas)
    {
        Fade(0f, duration, canvas);
    }
}
