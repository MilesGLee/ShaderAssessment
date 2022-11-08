using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    void Start()
    {
        FadeOut(3.0f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Fade(1.0f, 0.5f);
    }

    public void Fade(float delay, float duration) 
    {
        FadeIn(duration);
        RoutineBehaviour.Instance.StartNewTimedAction(args => FadeOut(duration), TimedActionCountType.SCALEDTIME, delay);
    }

    public void FadeIn(float time) 
    {
        _fadeImage.CrossFadeAlpha(1.0f, time, false);
    }

    public void FadeOut(float time)
    {
        _fadeImage.CrossFadeAlpha(0.0f, time, false);
    }
}
