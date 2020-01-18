using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    private CharacterController CharControler;
    [SerializeField] private float movementSpeed;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpMultiplier;

    private bool isJumping;




    private void Awake () {

        CharControler = GetComponent<CharacterController>();

	}
	
	


	void Update () {

        PlayerMovement();
	}

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        CharControler.SimpleMove(forwardMovement + rightMovement);
        JumpInput();

    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping )
        {
            isJumping = true;
            StartCoroutine(JumpEvent());

        }

    }

    private IEnumerator JumpEvent()
    {
        CharControler.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            CharControler.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;


            yield return null;

        } while (!CharControler.isGrounded && CharControler.collisionFlags != CollisionFlags.Above );


        CharControler.slopeLimit = 45.0f;
        isJumping = false;
        
    }

}

