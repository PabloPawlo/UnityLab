using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FTPInput : MonoBehaviour {

    private CharacterController _characterController;
    public float speed = 15.0f;
    public float gravity = -9.81f;


	// Use this for initialization
	void Start () {
        _characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);





    }
}
