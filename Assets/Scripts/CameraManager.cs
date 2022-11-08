using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private List<Transform> _cameraPositions = new List<Transform>();
    [SerializeField] private UIManager _UIManager;

    /// <summary>
    /// Fade out the screen and move the camera to the given position index
    /// </summary>
    /// <param name="positionIndex"></param>
    public void MoveCamera(int positionIndex) 
    {
        _UIManager.Fade(1.0f, 0.5f);
        RoutineBehaviour.Instance.StartNewTimedAction(args => {
            _camera.transform.position = _cameraPositions[positionIndex].position;
            _camera.transform.rotation = _cameraPositions[positionIndex].rotation;
        }, TimedActionCountType.SCALEDTIME, 1.0f);
    }
}
