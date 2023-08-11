using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedGain = 0.2f;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _speed += _speedGain * Time.deltaTime;
    }
}
