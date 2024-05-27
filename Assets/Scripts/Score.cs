using System.Collections;
using System.Collections.Generic;
// using Unity.SceneManager;
using UnityEngine;
using TMPro;

public  class Score : MonoBehaviour
{
    public  float final_score = 0f;
    public int lastscene;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        
    }
    

}

