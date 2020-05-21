using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
     private Transform _playerTransform;
     [SerializeField]
     private float speed;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        Vector3 position =  Vector2.Lerp(transform.position, _playerTransform.position, speed * Time.deltaTime);
        position.z = -10;
        transform.position = position;
        
    }
}
