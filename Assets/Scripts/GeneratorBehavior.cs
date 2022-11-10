using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneratorBehavior : MonoBehaviour
{
    private int _typeIndex;
    private int _elementIndex;
    [SerializeField] private List<string> _typeList;
    [SerializeField] private List<string> _objectList;
    [SerializeField] private List<string> _textureList;
    [SerializeField] private List<string> _shaderList;
    [SerializeField] private List<GameObject> _spawnList;
    [SerializeField] private Transform _spawnLocation;
    [SerializeField] private TMP_Text _typeText;
    [SerializeField] private TMP_Text _elementText;

    private void Update()
    {
        //Display object and element list depending on the type index
        _typeText.text = _typeList[_typeIndex];
        if (_typeIndex == 0) 
        {
            _elementText.text = _objectList[_elementIndex];
        }
        if (_typeIndex == 1)
        {
            _elementText.text = _textureList[_elementIndex];
        }
        if (_typeIndex == 2)
        {
            _elementText.text = _shaderList[_elementIndex];
        }

    }

    /// <summary>
    /// Spawn an object based on the index of the type array and element array
    /// </summary>
    public void PrintObject() 
    {
        if (_typeIndex == 0)
        {
            if (_elementIndex == 0)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[1], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 1)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[2], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 2)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[3], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 3)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[4], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
        }
        if (_typeIndex == 1)
        {
            if (_elementIndex == 0)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[5], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 1)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[6], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 2)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[7], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
        }
        if (_typeIndex == 2)
        {
            if (_elementIndex == 0)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[8], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 1)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[9], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
            if (_elementIndex == 2)
            {
                Instantiate(_spawnList[0], _spawnLocation.position, Quaternion.identity);
                RoutineBehaviour.Instance.StartNewTimedAction(args => Instantiate(_spawnList[10], _spawnLocation.position, Quaternion.identity), TimedActionCountType.SCALEDTIME, 1.5f);
            }
        }
    }

    /// <summary>
    /// Increase the type index
    /// </summary>
    public void IncrementType() 
    {
        _typeIndex++;
        _elementIndex = 0;
        if (_typeIndex > _typeList.Count - 1) 
        {
            _typeIndex = 0;
        }
    }

    /// <summary>
    /// Decrease the type index
    /// </summary>
    public void DecrementType()
    {
        _typeIndex--;
        _elementIndex = 0;
        if (_typeIndex < 0) 
        {
            _typeIndex = _typeList.Count - 1;
        }
    }

    /// <summary>
    /// Increase the element index
    /// </summary>
    public void IncrementElement()
    {
        _elementIndex++;
        if (_typeIndex == 0) 
        {
            if (_elementIndex > _objectList.Count - 1)
            {
                _elementIndex = 0;
            }
        }
        if (_typeIndex == 1)
        {
            if (_elementIndex > _textureList.Count - 1)
            {
                _elementIndex = 0;
            }
        }
        if (_typeIndex == 2)
        {
            if (_elementIndex > _shaderList.Count - 1)
            {
                _elementIndex = 0;
            }
        }

    }

    /// <summary>
    /// Decrease the element index
    /// </summary>
    public void DecrementElement()
    {
        _elementIndex--;
        if (_typeIndex == 0)
        {
            if (_elementIndex < 0)
            {
                _elementIndex = _objectList.Count - 1;
            }
        }
        if (_typeIndex == 1)
        {
            if (_elementIndex < 0)
            {
                _elementIndex = _textureList.Count - 1;
            }
        }
        if (_typeIndex == 2)
        {
            if (_elementIndex < 0)
            {
                _elementIndex = _shaderList.Count - 1;
            }
        }
    }
}
