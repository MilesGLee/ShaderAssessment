using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableBehaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;
    [SerializeField] private bool _onlyOnce;
    private bool _invoked;

    private void Awake()
    {
        _invoked = false;
    }

    private void OnMouseDown()
    {
        if (_onlyOnce && !_invoked)
        {
            _invoked = true;
            _event.Invoke();
        }
        if (!_onlyOnce) 
        {
            _event.Invoke();
        }
    }
}
