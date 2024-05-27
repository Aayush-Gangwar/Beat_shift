using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
     public GameObject[] theGoodies;
  
      //Time it takes to spawn theGoodies
      [Space(3)]
      public float waitingForNextSpawn = 10;
      public float theCountdown = 10;
  
      // the range of X
      [Header ("X Spawn Range")]
      public float xMin;
      public float xMax;
  
      // the range of y
      [Header ("Y Spawn Range")]
      public float yMin;
      public float yMax;
  
  
      void Start()
      {
      }
  
      public void Update()
      {
          // timer to spawn the next goodie Object
          theCountdown -= Time.deltaTime;
          if(theCountdown <= 0)
          {
              SpawnGoodies ();
              theCountdown = waitingForNextSpawn;
          }
      }
  
  
      void SpawnGoodies()
      {
          // Defines the min and max ranges for x and y
          Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
  var fire = GetComponent<FireCounter>();
  var fire1 = GetComponent<ExplosiveCounter>();
          // Choose a new goods to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
          int rnd=Random.Range (0, theGoodies.Length);
          while(fire.canfire!=true && rnd==1){
            rnd=Random.Range (0, theGoodies.Length);
          }
          if(rnd==1){
            
            fire.canfire = false;
          }

          while(fire1.canfire!=true && rnd==4){
            rnd=Random.Range (0, theGoodies.Length);
          }
          if(rnd==4){
            
            fire1.canfire = false;
          }
          GameObject goodsPrefab = theGoodies [rnd];
 
          // Creates the random object at the random 2D position.
          Instantiate (goodsPrefab, pos, Quaternion.identity);
 
          // If I wanted to get the result of instantiate and fiddle with it, I might do t$$anonymous$$s instead:
          //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
          //newgoods.somet$$anonymous$$ng = somet$$anonymous$$ngelse;
      }
}
