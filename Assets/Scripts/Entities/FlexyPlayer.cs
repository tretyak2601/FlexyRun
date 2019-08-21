using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexyPlayer : MonoBehaviour
{
    [SerializeField] MovingController moving;
    [SerializeField] SizeController size;
    [SerializeField] JumpController jump;

    public MovingController Moving { get { return moving; } }
    public SizeController Size { get { return size; } }
    public JumpController Jump { get { return jump; } }

    public event Action OnCreateFloorTriggered;
    public event Action OnBarrierTriggered;
    public event Action OnBarrierPassed;

    int passCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.CREATE_FLOOR_TRIGGER)
            OnCreateFloorTriggered?.Invoke();
        else if (other.tag == Constants.BARRIER)
            OnBarrierTriggered?.Invoke();
        else if (other.tag == Constants.PASS)
        {
            OnBarrierPassed?.Invoke();
            passCount++;
            
            if (passCount == 3)
            {
                PlayAnimation();
                passCount = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.FLOOR)
            jump.IsJumping = false;
    }

    void PlayAnimation()
    {

    }
}
