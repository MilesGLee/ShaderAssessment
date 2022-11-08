using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private GameObject _mapObject;
    private bool _mapOpen;

    void Start()
    {
        FadeOut(3.0f);
        _mapObject.SetActive(false);
        _mapOpen = false;
    }

    void Update()
    {
        if (_mapOpen)
            _mapObject.SetActive(true);
        if (!_mapOpen)
            _mapObject.SetActive(false);
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

    public void CloseMap()
    {
        _mapOpen = false;
    }

    public void OpenMap()
    {
        _mapOpen = true;
    }

    public void ToggleMap()
    {
        _mapOpen = !_mapOpen;
    }
}
