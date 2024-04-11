using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_gcCharacterController;

    public float m_fMovementSpeed = 10.0f;
    public float m_fJumpSpeed = 70.0f;
    public float m_fGravity = 30.0f;
    public float m_fTurnSmoothing = 15.0f;

    private Vector3 m_vTrajectory;
    private float m_fJumpVelocity;
    private bool m_bIsJumping = false;

    
    void Start()
    {
        m_gcCharacterController = GetComponent<CharacterController>();
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        
        //
        // PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME 
        // PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME PLEASE FIX ME
        //
        
        
        
        m_vTrajectory = Vector3.zero;

        m_vTrajectory.z = Input.GetAxis("Vertical");
        m_vTrajectory.x = Input.GetAxis("Horizontal");
        m_vTrajectory.Normalize();
        
        m_vTrajectory *= m_fMovementSpeed;

        if (m_bIsJumping)
        {
            if (m_gcCharacterController.collisionFlags == CollisionFlags.Below
                || m_gcCharacterController.collisionFlags == CollisionFlags.CollidedBelow
                || m_gcCharacterController.isGrounded) m_bIsJumping = false;
        }


        if (Input.GetButton("Jump") && !m_bIsJumping)
        {
            m_bIsJumping = true;
            m_fJumpVelocity = m_fJumpSpeed;
        }
        
        // Roll down
        if (m_fJumpVelocity > 0.0f)
            m_fJumpVelocity -= Mathf.Clamp((m_fJumpSpeed * 2) * Time.deltaTime, 0.0f, m_fJumpSpeed);
        else 
            m_fJumpVelocity = 0.0f;


        m_vTrajectory.y = m_fJumpVelocity - m_fGravity;

        m_gcCharacterController.Move(m_vTrajectory * Time.deltaTime);

        m_vTrajectory.y = 0.0f;
        if (m_vTrajectory != Vector3.zero)
        {
            Quaternion gTargetRotation = Quaternion.LookRotation(m_vTrajectory, Vector3.up);
            Quaternion qNewRotation = Quaternion.Slerp(transform.rotation, gTargetRotation, m_fTurnSmoothing * Time.deltaTime);
            transform.rotation = qNewRotation;
        }
        
        
        // RaycastHit Hit;
        // if (Physics.SphereCast(transform.position, 5.0f, transform.forward, out Hit, 10.0f))
        // {
        //     Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.red, 1.0f, false);    
        // }
        // else
        // {
        //     Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.green, 1.0f, false);
        // }
    }
}
