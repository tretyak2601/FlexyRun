using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpController : MonoBehaviour
{
    [SerializeField] FlexyPlayer flexy;
    [SerializeField] TextMeshProUGUI jumpCountText;
    [SerializeField] int startJumpCount = 3;

    int jumpCount;
    public int JumpCount
    {
        get
        {
            return jumpCount;
        }
        set
        {
            jumpCount = value;
            jumpCountText.text = value.ToString();
        }
    }

    bool jump;
    public bool IsJumping
    {
        get
        {
            return jump;
        }
        set
        {
            if (value && !jump && JumpCount > 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 75, ForceMode.Impulse);
                JumpCount--;
            }

            jump = value;
        }
    }

    private void Awake()
    {
        flexy.Size.OnDeltaMax += () => IsJumping = true;
        JumpCount = startJumpCount;
    }

    public void Restart()
    {
        JumpCount = startJumpCount;
    }
}
