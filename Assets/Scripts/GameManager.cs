using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private CameraManager _cameraManager;

    private void Start()
    {
        _UIManager = GetComponent<UIManager>();
        _cameraManager = GetComponent<CameraManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            _UIManager.ToggleMap();
        }
    }

    public void SelectLocationTable() 
    {
        _UIManager.CloseMap();
        _cameraManager.MoveCamera(0);
    }

    public void SelectLocationGenerator()
    {
        _UIManager.CloseMap();
        _cameraManager.MoveCamera(1);
    }
}
