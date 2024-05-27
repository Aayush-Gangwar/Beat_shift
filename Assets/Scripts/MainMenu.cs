using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void QuitGame(){
    //     Application.Quit();
    // }

    

    public void back(){
        SceneManager.LoadScene(0);
    }
     public void play(){
        SceneManager.LoadScene(1);
    }
     public void level_1(){
        SceneManager.LoadScene(2);
    }
     public void level_2(){
        SceneManager.LoadScene(3);
    }
     public void level_3(){
        SceneManager.LoadScene(4);
    }
      public void how_to_play(){
        SceneManager.LoadScene(6);
    }
      public void credit(){
        SceneManager.LoadScene(7);
    }
    
}
