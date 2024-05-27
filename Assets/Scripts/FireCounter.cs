using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCounter : MonoBehaviour
{
    // Start is called before the first frame update
     float firetime=5f;
    public bool canfire=true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canfire){
            firetime-=Time.deltaTime;

            if(firetime<0f){
                canfire=true;
                firetime=5f;
            }
        }
        
    }
}
