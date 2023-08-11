using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedGain = 0.2f;
    [SerializeField] private float _turnSpeed = 200f;

    private int _steerValue;

    void Update()
    {
        _speed += _speedGain * Time.deltaTime;
        transform.Rotate(0f, _steerValue * _turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
