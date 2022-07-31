using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate() //카메라 인터페이스 이동은 LateUpdate에 쓰임 
    {
        transform.position = playerTransform.position + Offset;
    }
}
