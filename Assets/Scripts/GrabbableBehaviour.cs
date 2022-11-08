using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabbableBehaviour : MonoBehaviour
{
    private float _offset;
    private int _defaultLayer;
    private bool _isGrabbed, _isSelected;
    private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _ignoreGrabLayer;
    [SerializeField] private GameObject _outline;
    private GameManager _gameManager;

    private void Awake()
    {
        //Default variables
        _defaultLayer = gameObject.layer;
        _rigidbody = GetComponent<Rigidbody>();
        _outline.SetActive(false);
        _isSelected = false;
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void SelectObject() 
    {
        _outline.SetActive(true);
        _isSelected = true;
    }

    public void DeselectObject() 
    {
        _isSelected = false;
        _outline.SetActive(false);
    }

    /// <summary>
    /// When the object is clicked, get the offset
    /// </summary>
    private void OnMouseDown()
    {
        _isGrabbed = true;
        gameObject.layer = 3;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _ignoreGrabLayer))
        {
            _offset = Vector3.Distance(hit.point, gameObject.transform.position);
        }
    }

    /// <summary>
    /// Get the world position to move the grabbed object to
    /// </summary>
    /// <returns></returns>
    Vector3 GetPosition() 
    {
        //Create a raycast and set it to the mouse cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _ignoreGrabLayer))
        {
            Vector3 normal = hit.normal;

            Vector3 pos = hit.point + (normal * _offset);

            return pos;
        }
        else return Vector3.zero;
    }

    /// <summary>
    /// Move this object
    /// </summary>
    private void OnMouseDrag()
    {
        transform.position = GetPosition();
        _rigidbody.isKinematic = true;
    }

    /// <summary>
    /// Stop moving and and reset its layer and kinematic state
    /// </summary>
    private void OnMouseUp()
    {
        if (_isGrabbed) 
        {
            _isGrabbed = false;
            gameObject.layer = _defaultLayer;
            _rigidbody.isKinematic = false;
        }
    }
}
