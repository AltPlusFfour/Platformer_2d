using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementPlus : MonoBehaviour {
    //	public Collider m_ObjectCollider;
	//	m_ObjectCollider = GetComponent<Collider>();
	//	m_ObjectCollider.isTrigger = true;
	public CharacterController2D controller;
	
	public float runSpeed = 40f;
    
    public Animator animator;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    public bool extraJump = true;
   
	[SerializeField] public Transform wallCheck;
	[SerializeField] public float wallCheckDist;
	public bool isWallDetected;
	public bool canWallSlide;
	public bool iswallSliding;

	private void OnDrawGizmos() 
	{
		Gizmos.DrawLine(wallCheck.position,new Vector3 (wallCheck.position.x + wallCheckDist,
														wallCheck.position.y,
														wallCheck.position.z));
	}


	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Run", Mathf.Abs(horizontalMove));
		

		if (Input.GetButtonDown("Jump"))
		{
		    jump = true;
			animator.SetBool("IsJumping", true);

            if (Input.GetButtonDown("Jump") && !controller.m_Grounded && extraJump)
                {
                   
					controller.m_Rigidbody2D.AddForce(new Vector2(0f, controller.m_JumpForce));
			       
                    
                    extraJump = false;
                }

		

		}

		
        

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			animator.SetBool("IsCrouching", true);

		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
				if(Physics2D.OverlapCircle(controller.m_CeilingCheck.position, controller.k_CeilingRadius, controller.m_WhatIsGround))
				{
				animator.SetBool("IsCrouching", true);
				crouch = true;
				}
				if(crouch == false && animator.GetBool("IsCrouching"))
				{
				animator.SetBool("IsCrouching", false);
				}	
			
			
			
		}

        if (controller.m_Grounded)
            {
                extraJump = true;
				animator.SetBool("IsJumping",false);
				if(crouch == false && animator.GetBool("IsCrouching"))
				{
				animator.SetBool("IsCrouching", false);
				}	
            }
	if (!controller.m_Grounded)
            {
                animator.SetBool("IsJumping",true);

				
            }

		
    
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}


	public void onCrouching(bool isCrouching)	
	{
 
		animator.SetBool("IsCrouching", isCrouching);	

	}


	 
}
