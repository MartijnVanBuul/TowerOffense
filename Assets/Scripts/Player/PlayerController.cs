using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PlayerState
{
    Neutral,
    Attacking,
    Rolling
}

public class PlayerController : MonoBehaviour {

    [Range(1, 6)]
    public float WalkSpeed = 5;
    [Range(6, 12)]
    public float RunSpeed = 8;
    [Range(12, 60)]
    public float acceleration = 20;

    public KeyCode RunKeycode = KeyCode.LeftShift;
    public KeyCode RollKeycode = KeyCode.LeftControl;

    private float xAxis;
    private float yAxis;
    private Vector3 movementVector;
    public Vector3 DirectionVector;
    public Vector3 currentSpeed;
    private Vector3 targetSpeed;

    private E_PlayerState currentState = E_PlayerState.Neutral;

    private Transform movementTransform;

    public AnimationCurve RollMovememtCurve;
    private float rollDuration = 0.2f;
    private float rollTime = 0;

    // Use this for initialization
    void Start () {
        movementTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");



        if (currentState != E_PlayerState.Rolling)
        {
            if (xAxis != 0 || yAxis != 0)
            {
                DirectionVector = new Vector3(xAxis, 0, yAxis);
                DirectionVector.Normalize();
            }

            movementVector = new Vector3(xAxis, 0, yAxis);

            if (movementVector.magnitude > 1)
                movementVector.Normalize();

            if (Input.GetKey(RunKeycode))
                targetSpeed = movementVector * RunSpeed;
            else
                targetSpeed = movementVector * WalkSpeed;

            MoveCharacter();
        }
        else
            RollMoveCharacter();

        if (Input.GetKeyDown(RollKeycode) && currentState == E_PlayerState.Neutral)
            RollCharacter();

    }

    private void MoveCharacter()
    {
        currentSpeed = Vector3.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        movementTransform.Translate(currentSpeed * Time.deltaTime, Space.World);
    }


    private void RollMoveCharacter()
    {
        currentSpeed = WalkSpeed * RollMovememtCurve.Evaluate(rollTime) * DirectionVector;

        movementTransform.Translate(currentSpeed * Time.deltaTime, Space.World);
        rollTime += Time.deltaTime;

        if(rollTime > rollDuration)
        {
            currentState = E_PlayerState.Neutral;
        }
    }

    private void RollCharacter()
    {
        rollTime = 0;
        currentState = E_PlayerState.Rolling;
    }
}

