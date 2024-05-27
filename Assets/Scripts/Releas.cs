using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Releas : MonoBehaviour
{
    // Rotation Speed
public float _rotationSpeed = 1;

// Speed
private Vector2 lastFrameVelocity;
public float invoke_repeat;
public float _velocity = 1;
public int State;
public GameObject player, explosion_animation,bounce_animation,fire_circle,all_burst_animation,text_animation;
public GameObject[] explosive_ball,time_ball,fire_ball,red_ball,green_ball;
public AudioSource ads;
public Color red,green,blue,time_color;
public Gradient time_gradient,blue_gradient,green_gradient,red_gradient;
public List<GameObject> Colorobjects;
public AudioSource fire_audio,reflected_audio,thorn_audio,ball_release_audio,ball_get_audio;
public AudioClip fire_ad,reflected_ad,thorn_ad,ball_release_ad,ball_get_ad;
public ScoringScript sc;
public Game_over_Script gos;
public List<int> Score ;

// Attached Rigidbody2D
Rigidbody2D _rb;
Circular_motion cb;
public GameObject current_object;
bool first_time=true;
public float angle_;
void Start ()
    {
        _rb = GetComponent<Rigidbody2D> ();
        cb= GetComponent<Circular_motion>();
        InvokeRepeating("Release_Ball", invoke_repeat, invoke_repeat);
        // ads.Play();
        text_animation =Resources.Load<GameObject>("Floating Text");
        State=1;
    }

void Update ()
    {
         lastFrameVelocity = _rb.velocity;
    }

void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "wall"){
        Bounce(collision.contacts[0].normal);
        StartCoroutine(PlayBounceAnim());
         }
    }
void OnTriggerEnter2D(Collider2D collision  ){
    if (collision.gameObject.tag == "AllBurst Circle" && State==0){
         player.GetComponent<SpriteRenderer>().color=blue;
          player.GetComponentInChildren<TrailRenderer>().colorGradient=blue_gradient;
        current_object = collision.gameObject;
        collision.gameObject.GetComponent<falling>().yvelocity=0f;
        StartCoroutine(Playall_burst_red_Anim());
        StartCoroutine(Playall_burst_green_Anim());
        StartCoroutine(Playall_burst_time_Anim());
        StartCoroutine(Playall_burst_fire_Anim());
        StartCoroutine(floating_text(collision.gameObject,3));
        new_rotation(collision.gameObject);
    }

    if (collision.gameObject.tag == "Firey Circle" && State==0){
        current_object = collision.gameObject;
        collision.gameObject.GetComponent<falling>().yvelocity=0f;
       StartCoroutine(PlayfireAnim(collision.gameObject));
    }

    if (collision.gameObject.tag == "Time Circle" && State==0){
        player.GetComponent<SpriteRenderer>().color=time_color;
        player.GetComponentInChildren<TrailRenderer>().colorGradient=time_gradient;
        current_object = collision.gameObject;
        StartCoroutine(floating_text(collision.gameObject,4));
        collision.gameObject.GetComponent<falling>().yvelocity=0f;

         new_rotation(collision.gameObject);
        Time.timeScale=0.5f;
        ads.pitch=0.5f;
    }

     if (collision.gameObject.tag == "Green_Circle" && State==0)
        {    
          player.GetComponent<SpriteRenderer>().color=green;
          player.GetComponentInChildren<TrailRenderer>().colorGradient=green_gradient;
            collision.gameObject.GetComponent<falling>().yvelocity=0f;
            current_object = collision.gameObject;
            StartCoroutine(floating_text(collision.gameObject,2));
            new_rotation(collision.gameObject);
        }
       if (collision.gameObject.tag == "Red_Circle" && State==0)
        {    
            player.GetComponent<SpriteRenderer>().color=red;
          player.GetComponentInChildren<TrailRenderer>().colorGradient=red_gradient;
            collision.gameObject.GetComponent<falling>().yvelocity=0f;
            current_object = collision.gameObject;
            StartCoroutine(floating_text(collision.gameObject,1));
            new_rotation(collision.gameObject);
        }
    
    if (collision.gameObject.tag == "thorns" && State==0){
        player.GetComponent<SpriteRenderer>().enabled=false;
        player.GetComponentInChildren<TrailRenderer>().enabled=false;
        _rb.velocity=new Vector2(0f,0f);
        StartCoroutine(Play_thorn_Anim());
    }
}

void Destroy_gameObject(GameObject collision){
        Destroy(collision);

}
 void new_rotation( GameObject collision){
      State=1;
      cb.enabled = true;
      ball_get_audio.PlayOneShot(ball_get_ad,0.7f);
      var vec = new Vector2(gameObject.transform.position.x-collision.transform.position.x,gameObject.transform.position.y-collision.transform.position.y);
      var sin = Vector2.Dot(Vector2.up,vec)/Mathf.Sqrt(Vector2.SqrMagnitude(vec));
      if(sin<0.0f)
      cb.angle=2*Mathf.PI-Mathf.Acos(Vector2.Dot(Vector2.right,vec)/Mathf.Sqrt(Vector2.SqrMagnitude(vec)));
      else{
        cb.angle=Mathf.Acos(Vector2.Dot(Vector2.right,vec)/Mathf.Sqrt(Vector2.SqrMagnitude(vec)));
      }
      
      _rb.velocity = Vector2.zero;
      cb.rotationCenter=collision.transform;
}

IEnumerator PlayfireAnim (GameObject fire_circle) {
    // audioSource.PlayOneShot(enemy_dying);
    explosion_animation=Resources.Load<GameObject>("Explosion");
    fire_audio.PlayOneShot(fire_ad, 0.7F);
    GameObject _effect=Instantiate(explosion_animation,player.transform.position,Quaternion.identity);
    GameObject _effect1=Instantiate(explosion_animation,fire_circle.transform.position,Quaternion.identity);
    Destroy(_effect,6f);
     Destroy(_effect1,6f);
     gos.gameover=true;
     Destroy(player);
     Destroy(fire_circle);
    yield return new WaitForSeconds(5f);
    
}

  IEnumerator Playall_burst_green_Anim() {

    green_ball=GameObject.FindGameObjectsWithTag("Green_Circle");

       foreach(GameObject i in green_ball){
        all_burst_animation=Resources.Load<GameObject>("All_explosion");
        StartCoroutine(floating_text(i,2));
         GameObject _effect=Instantiate( all_burst_animation,i.transform.position,Quaternion.identity);
               Destroy(_effect,1f);
           Destroy(i,0f);
           yield return new WaitForSeconds(0f);
    }
}

IEnumerator Playall_burst_red_Anim() {
    red_ball=GameObject.FindGameObjectsWithTag("Red_Circle");
       foreach(GameObject i in red_ball){
        all_burst_animation=Resources.Load<GameObject>("All_explosion");
        StartCoroutine(floating_text(i,1));
         GameObject _effect=Instantiate( all_burst_animation,i.transform.position,Quaternion.identity);
               Destroy(_effect,1f);
           Destroy(i,0f);
           yield return new WaitForSeconds(0f);
    }
}

  IEnumerator Playall_burst_fire_Anim() {
    fire_ball=GameObject.FindGameObjectsWithTag("Firey Circle");
       foreach(GameObject i in fire_ball){
        all_burst_animation=Resources.Load<GameObject>("All_explosion");
         GameObject _effect=Instantiate( all_burst_animation,i.transform.position,Quaternion.identity);
            Destroy(_effect,1f);
           Destroy(i,0f);
           yield return new WaitForSeconds(0f);
    }
}

  IEnumerator Playall_burst_time_Anim() {
    time_ball=GameObject.FindGameObjectsWithTag("Time Circle");

       foreach(GameObject i in time_ball){
        all_burst_animation=Resources.Load<GameObject>("All_explosion");
        StartCoroutine(floating_text(i,4));
         GameObject _effect=Instantiate( all_burst_animation,i.transform.position,Quaternion.identity);
          Destroy(_effect,1f);
           Destroy(i,0f);
           yield return new WaitForSeconds(0f);
    }
}
  IEnumerator PlayBounceAnim () {
    bounce_animation=Resources.Load<GameObject>("bounce_animation");
    reflected_audio.PlayOneShot(reflected_ad,0.7f);
    GameObject _effect=Instantiate(bounce_animation,player.transform.position,Quaternion.identity);
    Destroy(_effect,1f);
    yield return new WaitForSeconds(5.1f);
}

 IEnumerator Play_thorn_Anim () {
    bounce_animation=Resources.Load<GameObject>("bounce_animation");
    thorn_audio.PlayOneShot(thorn_ad,0.7f);
    GameObject _effect=Instantiate(bounce_animation,player.transform.position,Quaternion.identity);
    // yield return new WaitForSeconds(2f);
    gos.gameover2=true;
    Destroy(_effect,0.5f);
    Destroy(player,0.5f);
    yield return new WaitForSeconds(0f);
}


   void Bounce(Vector2 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector2.Reflect(lastFrameVelocity.normalized, collisionNormal);
        _rb.velocity = direction * speed;
    }

 IEnumerator floating_text(GameObject gameObject1,int i){
    // text_animation =Resources.Load<GameObject>("Floating Text");
    Vector3 offset = new Vector3(0f,1.5f,0f);
    GameObject _effect= Instantiate(Colorobjects[i-1],gameObject1.transform.position+offset,Quaternion.identity);
    sc.score += Score[i-1];
    Destroy(_effect,1f);
    yield return new WaitForSeconds(0f);

}
void Release_Ball()
    {
        if (first_time){
            ads.Play();
            first_time=false;
        }
        if(State==1){
            if(Time.timeScale==0.5f){
                Time.timeScale=1f;
                ads.pitch=1f;
            }
            angle_=cb.angle;
        cb.enabled = false;
        float horizontalInput = Input.GetAxis ("Horizontal");

        transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - (horizontalInput * _rotationSpeed));

        float theta =angle_;

        // Getting new X direction
        float newDirX = Mathf.Cos (theta);

        // Getting new Y direction
        float newDirY = Mathf.Sin (theta);

        // Applying velocity according to current angle
        _rb.velocity = new Vector2 (newDirX, newDirY) * _velocity;
        ball_release_audio.PlayOneShot(ball_release_ad, 0.7F);
        State=0;
        Destroy_gameObject(current_object);
        // }
        }

    }

}
