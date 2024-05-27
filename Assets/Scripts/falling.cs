using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    // Start is called before the first frame update
    public  float yvelocity = -1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0f,yvelocity*Time.deltaTime,0f);

        if (gameObject.transform.position.y<=-6){
            Destroy(gameObject);
        }
    }
}
