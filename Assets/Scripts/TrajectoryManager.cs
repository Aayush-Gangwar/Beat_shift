using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer Trajectory;
    public GameObject currentRing;
    private int state;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentRing = GetComponent<Releas>().current_object;
        state = GetComponent<Releas>().State;
        ShowTrajectory();

    }

    void SetTrajectoryActive(bool active)
    {
        Trajectory.enabled = active;
    }

    void ShowTrajectory()
    {
        if (state == 1)
        {

            SetTrajectoryActive(true);
            Vector3 diff = gameObject.transform.position - currentRing.transform.position;
            int segmentCount = 10;
            Vector2[] segments = new Vector2[segmentCount];
            segments[0] = gameObject.transform.position;

            Vector2 segVelocity = new Vector2(diff.x, diff.y) * 10f;

             RaycastHit2D hit = Physics2D.Raycast(transform.position, segVelocity);
             RaycastHit2D hit2=Physics2D.Raycast(transform.position, segVelocity);
        float dist=100f;
        var dist2 = 100f;
        var reflecttag = false;
        // If it hits something...
        if (hit.collider != null)
        {
            dist = hit.distance;
            if(hit.collider.gameObject.tag=="wall"){
                reflecttag=true;
                hit2 = Physics2D.Raycast(hit.point+0.1f*Vector2.Reflect(segVelocity.normalized, hit.normal), Vector2.Reflect(segVelocity.normalized, hit.normal));
            }
            
        }

        print(dist);
            for (int i = 1; i < segmentCount; i++)
            {
                float timeCurve = (i * Time.fixedDeltaTime * 5);
                segments[i] = segments[0] + segVelocity * timeCurve;
                if(Vector2.Distance(segments[i],gameObject.transform.position)>dist){

                    if(reflecttag){
                        
                        segments[i] = hit.point + (timeCurve-Vector2.Distance(hit.point,gameObject.transform.position)/Mathf.Sqrt(Vector2.SqrMagnitude(segVelocity)))* Vector2.Reflect(segVelocity.normalized, hit.normal)*Mathf.Sqrt(Vector2.SqrMagnitude(segVelocity));
                        if(hit2.collider!=null){
                            dist2 = hit2.distance;
                            if(Vector2.Distance(segments[i],hit.point)>dist2 && (i>=Vector2.Distance(hit.point,gameObject.transform.position)/Mathf.Sqrt(Vector2.SqrMagnitude(segVelocity)))){
                            segments[i] = hit2.point;
                        }
                        }

                        
                        
                        
                    }
                    else{
                    segments[i] = hit.point;

                    }
                }
            }
            Trajectory.positionCount = segmentCount;
            for (int j = 0; j < segmentCount; j++)

            {
                Trajectory.SetPosition(j, segments[j]);

            }

        }
        else
        {
            SetTrajectoryActive(false);

        }


    }
}

