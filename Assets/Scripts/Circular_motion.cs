using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular_motion : MonoBehaviour {

	public Transform rotationCenter;
	public float angle=0f;

	[SerializeField]
	public float rotationRadius = 2f, angularSpeed = 0f,sensitivity=100f;

	float posX, posY= 0f;

	// Update is called once per frame
	void Update () {
		posX = rotationCenter.position.x + Mathf.Cos (angle) * rotationRadius;
		posY = rotationCenter.position.y + Mathf.Sin (angle) * rotationRadius;
		transform.position = new Vector2 (posX, posY);
		if(Input.GetAxis("Horizontal")!=0){
			angularSpeed -= (Input.GetAxis("Horizontal")/10)* sensitivity;
		}
		if(Input.mouseScrollDelta.y!=0){
			angularSpeed += Input.mouseScrollDelta.y * sensitivity;
		}
			if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
				angularSpeed = 0f;
			}
		angle = angle + Time.deltaTime *angularSpeed;
		angularSpeed = Mathf.Sign(angularSpeed)*Mathf.Clamp(Mathf.Abs(angularSpeed)*(1-Time.deltaTime*sensitivity),0,100);
		if (angle >= 360f)
			angle = angle%360;

	}
}
