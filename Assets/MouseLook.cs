using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes
    {
        MouseXandY=0,
        MouseX=1,
        MouseY=2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityX = 9.0f, sensitivityY = 9.0f;
    public float minimumVert = -15.0f, maximumVert = 15.0f;

    private float _rotationX = 0, _rotationY = 0;
    private Camera cameraPlayer;


	// Use this for initialization
	void Start () {
        cameraPlayer = GameObject.Find("camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(axes==RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        }
        else
        {
            _rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            transform.localEulerAngles = new Vector3(0, _rotationY, 0);
            cameraPlayer.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        }
	}
}
