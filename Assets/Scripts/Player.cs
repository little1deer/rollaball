using System;
using RollaBall;
using UnityEngine;

public class Player : MonoBehaviour
{
    [NonSerialized]public float RigidSpeed;
    private float _speed= 10.0f;
    private float _forceJump= 7.0f;
    private bool _onGround = false;
    public Rigidbody Rigidbody;
   
    protected void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
            
        Vector3 movement = new Vector3(moveHorizontal * _speed, 0.0f, moveVertical * _speed);
            
        Rigidbody.AddForce(movement);
    }
    
    protected void Jump()
    {
        if (Input.GetButtonDown("Jump")&&_onGround)
        {
            Rigidbody.AddForce(Vector3.up * _forceJump,ForceMode.Impulse);
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
        if (other.TryGetComponent(out InteractiveObject interactiveObject))
        {
            switch (interactiveObject)
            {
                case BonusScore bonusScore :
                    bonusScore.GetComponent<GoodBonus>().scoreController.Score += 200;
                    Destroy(bonusScore.gameObject);
                    break;
                case Trap trap :
                    trap.GetComponent<BadBonus>().scoreController.Score -= 200;
                    break;
                case TrapDelay trapDelay :
                    _speed -= trapDelay.trapDelaySpeed;
                    break;
                case BonusKey bonusKey :
                    bonusKey.KeyController.Keys++;
                    Destroy(bonusKey.gameObject);
                    break; 
                case FinishPickUp finishPickUp :
                    if (finishPickUp.scoreController.screenBar.KeyController.Keys == 2)
                    {
                        finishPickUp.scoreController.screenBar.YouWin.enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public float GetSpeedPlayer()
    {
        return Rigidbody.velocity.magnitude;
    }
}