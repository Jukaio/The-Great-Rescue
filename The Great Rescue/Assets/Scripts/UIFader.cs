using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour{

    private CanvasGroup Image;
    public float fadeTime;
    public bool fadeIn;

    private void Start()
    {
        Image = gameObject.GetComponent<CanvasGroup>();
        if (fadeIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(Image, 0f, 1f, fadeTime));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(Image, 1f, 0f, fadeTime));
    }

    public IEnumerator Fade(CanvasGroup cg, float start, float end, float lerpTime)
    {
        float startTime = Time.time;
        float timeSinceStared = Time.time - startTime;
        float precentage = timeSinceStared / lerpTime;

        while(true)
        {
            timeSinceStared = Time.time - startTime;
            precentage = timeSinceStared / lerpTime;

            float currentValue = Mathf.Lerp(start, end, precentage);

            cg.alpha = currentValue;

            if (precentage >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
