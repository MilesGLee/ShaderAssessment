using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private GameObject _mapObject;
    private bool _mapOpen;
    private bool _isUIOpen;

    public bool IsUIOpen { get { return _isUIOpen; } }

    void Start()
    {
        //Default variables
        FadeOut(3.0f);
        _mapObject.SetActive(false);
        _mapOpen = false;
    }

    void Update()
    {
        //Turn the map on and off
        if (_mapOpen)
            _mapObject.SetActive(true);
        if (!_mapOpen)
            _mapObject.SetActive(false);
    }

    /// <summary>
    /// Fade in and out with a delay
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="duration"></param>
    public void Fade(float delay, float duration) 
    {
        FadeIn(duration);
        RoutineBehaviour.Instance.StartNewTimedAction(args => FadeOut(duration), TimedActionCountType.SCALEDTIME, delay);
    }

    /// <summary>
    /// Fade in the screen
    /// </summary>
    /// <param name="time"></param>
    public void FadeIn(float time) 
    {
        _fadeImage.CrossFadeAlpha(1.0f, time, false);
    }

    /// <summary>
    /// Fade out the screen
    /// </summary>
    /// <param name="time"></param>
    public void FadeOut(float time)
    {
        _fadeImage.CrossFadeAlpha(0.0f, time, false);
    }

    /// <summary>
    /// Close the map
    /// </summary>
    public void CloseMap()
    {
        _mapOpen = false;
    }

    /// <summary>
    /// Open the map
    /// </summary>
    public void OpenMap()
    {
        _mapOpen = true;
    }

    /// <summary>
    /// Toggle the map on and off
    /// </summary>
    public void ToggleMap()
    {
        _mapOpen = !_mapOpen;
    }
}
