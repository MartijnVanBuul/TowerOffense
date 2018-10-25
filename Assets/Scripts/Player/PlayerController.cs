using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Range(1, 6)]
    public float MovementSpeed = 5;
    [Range(6, 12)]
    public float RunSpeed = 8;
    [Range(12, 60)]
    public float acceleration = 20;
    public KeyCode RunKeycode = KeyCode.LeftShift;

    private float xAxis;
    private float yAxis;
    private Vector3 movementVector;
    private Vector3 currentSpeed;
    private Vector3 targetSpeed;

    private Transform movementTransform;

	// Use this for initialization
	void Start () {
        movementTransform = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        movementVector = new Vector3(xAxis, 0, yAxis);

        if (movementVector.magnitude > 1)
            movementVector.Normalize();

        if(Input.GetKey(RunKeycode))
            targetSpeed = movementVector * RunSpeed;
        else
            targetSpeed = movementVector * MovementSpeed;

        currentSpeed = Vector3.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        movementTransform.Translate(currentSpeed * Time.deltaTime);
    }
}
