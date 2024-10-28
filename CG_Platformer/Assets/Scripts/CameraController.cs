using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;


    void Start()
    {
        offset = transform.position - player.position;
    }

    
    void Update()
    {
        transform.position = player.position + offset;
    }
}
