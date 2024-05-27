using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fill;
    public int invoke_repeat;
    private float time = 0;
    void Start()
    {
        fill.fillAmount = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime ;
        time = time % invoke_repeat;
        fill.fillAmount = 1-time/invoke_repeat;
    }
}
