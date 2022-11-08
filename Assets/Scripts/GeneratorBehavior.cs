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
    }

    public void IncrementType() 
    {
        _typeIndex++;
        _elementIndex = 0;
        if (_typeIndex > _typeList.Count - 1) 
        {
            _typeIndex = 0;
        }
    }

    public void DecrementType()
    {
        _typeIndex--;
        _elementIndex = 0;
        if (_typeIndex < 0) 
        {
            _typeIndex = _typeList.Count - 1;
        }
    }

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
