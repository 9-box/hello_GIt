using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text StageCountText;
    public Text PlayerCountText;
    void Awake() {
        StageCountText.text = "/"+ totalItemCount;
    }
    public void GetItem(int count)
    {
        PlayerCountText.text=count.ToString();
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(stage);
        }
    }
}
