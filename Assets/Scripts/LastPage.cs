using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LastPage : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI text;
    public int loaded_scene;
    void Start()
    {
        text.text = "Score : "+GameObject.FindGameObjectWithTag("Score_").GetComponent<Score>().final_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Main_Game(){
        // Application.Quit();
        SceneManager.LoadScene(0);

    }

    public void replay(){
        loaded_scene=GameObject.FindGameObjectWithTag("Score_").GetComponent<Score>().lastscene;
        SceneManager.LoadScene(loaded_scene);
    }
}
