using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCam : MonoBehaviour
{
    public float rototeSpeen;
    
    void Update()
    {
        transform.Rotate(Vector3.up * rototeSpeen * Time.deltaTime);
    }
    /*void OnTriggerEnter(Collider other) {
        if(other.name == "Player"){
            Myball player = other.GetComponent<Myball>();
            player.itemCount++;
            gameObject.SetActive(false);
        }
    }*/
}
