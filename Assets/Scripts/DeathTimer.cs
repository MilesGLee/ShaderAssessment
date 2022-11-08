using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private bool _spawnOnDeath;
    [SerializeField] private GameObject _spawnedOnDeath;

    private void Start()
    {
        RoutineBehaviour.Instance.StartNewTimedAction(args => 
        {
            if (_spawnOnDeath)
                Instantiate(_spawnedOnDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }, TimedActionCountType.SCALEDTIME, _delay);
    }
}
