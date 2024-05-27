using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Game_over_Script : MonoBehaviour
{
    public GameObject ball;
    public ScoringScript sc;
    public float score = 0f;
    public TMPro.TextMeshProUGUI text;
    public bool gameover=false;
     public bool gameover2=false;
    //  public AudioSource thorn_audio;
    // //  public GameObject player;
    //  public AudioClip thorn_ads;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

          if(gameover){
            StartCoroutine(Quit_game());
            gameover=false;
        }
         if(gameover2){
            StartCoroutine(Quit_game2());
            gameover2=false;
        }
        
        if(ball){

        if(  Mathf.Abs(ball.transform.position.y)>7.0f){
            Quit_Scene();
        }

        if(  Mathf.Abs(ball.transform.position.x)>15f ){
            Quit_Scene();
        }
        }
    }

    public void Quit_Scene(){
        GameObject.FindGameObjectWithTag("Score_").GetComponent<Score>().final_score = sc.score;
        GameObject.FindGameObjectWithTag("Score_").GetComponent<Score>().lastscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(5);
        
    }

    IEnumerator Quit_game() {
         yield return new WaitForSeconds(1f);

           Quit_Scene();
}
    IEnumerator Quit_game2() {
        // StartCoroutine(Play_thorn_Anim ());
         yield return new WaitForSeconds(1f);

           Quit_Scene();
}


//  IEnumerator Play_thorn_Anim () {
//     var vec = player.transform.position;
//      Destroy(player,1f);
//     var bounce_animation=Resources.Load<GameObject>("bounce_animation");
//     thorn_audio.PlayOneShot(thorn_ads,0.7f);
//     GameObject _effect=Instantiate(bounce_animation,vec,Quaternion.identity);
//     Destroy(_effect,1f);
//     yield return new WaitForSeconds(5f);
// }

}
