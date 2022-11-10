using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private Transform _holdPosition;
    [SerializeField] private LayerMask _ignoreGrabLayer;
    [SerializeField] private GameObject _grabButton;
    private GrabbableBehaviour _selectedObject;
    private GrabbableBehaviour _heldObject;

    public Transform HoldPosition { get { return _holdPosition; } }

    private void Start()
    {
        //Default variables
        _UIManager = GetComponent<UIManager>();
        _cameraManager = GetComponent<CameraManager>();
        _heldObject = null;
        _selectedObject = null;
        _grabButton.SetActive(false);

        //SelectLocationTable();
    }

    private void Update()
    {
        //Display grab button
        if (_selectedObject != null && _heldObject == null)
            _grabButton.SetActive(true);
        if (_selectedObject == null)
            _grabButton.SetActive(false);
        if (_heldObject != null)
            _grabButton.SetActive(false);

        //Toggle map on and off
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            _UIManager.ToggleMap();
        }

        //Selecting objects
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            if (_heldObject == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _ignoreGrabLayer))
                {
                    if (hit.collider.GetComponent<GrabbableBehaviour>())
                    {
                        if (_selectedObject != null)
                        {
                            _selectedObject.DeselectObject();
                            _selectedObject = null;
                        }
                        _selectedObject = hit.collider.GetComponent<GrabbableBehaviour>();
                        _selectedObject.SelectObject();
                    }
                    else 
                    {
                        if (_selectedObject != null)
                        {
                            _selectedObject.DeselectObject();
                            _selectedObject = null;
                        }
                    }
                }
            }
            if (_heldObject != null) 
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _ignoreGrabLayer))
                {
                    if (hit.point != Vector3.zero) 
                    {
                        _heldObject.transform.parent = null;
                        _heldObject.transform.position = hit.point;
                        _heldObject.GetComponent<Rigidbody>().isKinematic = false;
                        _heldObject.DeselectObject();
                        _heldObject = null;
                        _selectedObject = null;
                    }
                }
            }
        }
        //Holding selected objects
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            HoldObject();
        }
    }

    public void HoldObject() 
    {
        if (_selectedObject != null && _heldObject == null)
        {
            _selectedObject.GetComponent<Rigidbody>().isKinematic = true;
            _selectedObject.transform.parent = _holdPosition;
            _selectedObject.transform.localPosition = new Vector3(0, 0, 0);
            _selectedObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            _heldObject = _selectedObject;
        }
    }

    /// <summary>
    /// Move the camera to the clicked position on the map
    /// </summary>
    public void SelectLocationTable() 
    {
        _UIManager.CloseMap();
        _cameraManager.MoveCamera(0);
    }

    /// <summary>
    /// Move the camera to the clicked position on the map
    /// </summary>
    public void SelectLocationGenerator()
    {
        _UIManager.CloseMap();
        _cameraManager.MoveCamera(1);
    }

    /// <summary>
    /// Move camera to hasred location
    /// </summary>
    public void SelectLocationQuestion()
    {
        _UIManager.CloseMap();
        _cameraManager.MoveCamera(2);
    }

    /// <summary>
    /// Quit to main menu 
    /// </summary>
    public void QuitToMainMenu() 
    {
        Application.LoadLevel("menu_scene");
    }
}
