using System;
using RollaBall;
using UnityEngine;

public class Player : MonoBehaviour
{
    [NonSerialized]public float RigidSpeed;
    private float _speed= 10.0f;
    private float _forceJump= 7.0f;
    private bool _onGround = false;
    private new Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
            
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
        _rigidbody.AddForce(movement * _speed);
    }
    
    protected void Jump()
    {
        if (Input.GetButtonDown("Jump")&&_onGround)
        {
            _rigidbody.AddForce(Vector3.up * _forceJump,ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _onGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BonusScore"))
        {
            other.GetComponent<GoodBonus>().scoreController.Score += 200;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            other.GetComponent<GoodBonus>().scoreController.Score -=200;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("TrapDealy"))
        {
            _speed-=5;
        }
        if (other.CompareTag("BonusNoclip"))
        {
            //
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrapDealy"))
        {
            _speed+=5;
        }
    }

    public float GetSpeedPlayer()
    {
        return _rigidbody.velocity.magnitude;
    }
}
