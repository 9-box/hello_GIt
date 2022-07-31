using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Myball : MonoBehaviour
{
    public float JumpPower;
    public int itemCount;
    public GameManager manager;
    bool isJumping;
    Rigidbody rigid;
    AudioSource audio1;
    // Start is called before the first frame update
    void Awake() {
        rigid = GetComponent <Rigidbody>();
        audio1 = GetComponent <AudioSource>();
        isJumping = false;
    }

    void Update() {
        if(Input.GetButtonDown("Jump") && !isJumping){// 점프를 위한 코드
            isJumping = true;
            rigid.AddForce(new Vector3(0,JumpPower,0),ForceMode.Impulse);
        }    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h,0,v),ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision) { // 바닥에 닿을시 상태를 바꿔주는 코드
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;            
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Item"){           
            itemCount++;
            audio1.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
            
        }
        else if(other.tag == "Finish"){
           if(itemCount == manager.totalItemCount){
                if(manager.stage == 2){
                    SceneManager.LoadScene(0);
                }
                else{
                    SceneManager.LoadScene(manager.stage+1);
                }
           }
            else{
            //restart
                SceneManager.LoadScene(manager.stage);
           }
            
        }
    }
}
