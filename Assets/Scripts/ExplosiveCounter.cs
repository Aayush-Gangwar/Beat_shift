using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCounter : MonoBehaviour
{
    // Start is called before the first frame update
      // Start is called before the first frame update
     float firetime=10f;
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
                firetime=10f;
            }
        }
        
    }
}
