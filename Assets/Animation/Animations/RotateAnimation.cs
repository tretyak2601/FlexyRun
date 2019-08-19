using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;

    private float totalPassed = 0;
    private Vector3 startAngles;

    void Start()
    {
        startAngles = transform.localEulerAngles;
        StartCoroutine(PlatAnimation());
    }

    IEnumerator PlatAnimation()
    {
        while (true)
        {
            if (Mathf.RoundToInt(totalPassed) != 180)
            {
                transform.localEulerAngles += Vector3.forward * speed;
                totalPassed += speed;
            }
            else
            {
                yield return new WaitForSeconds(1);
                totalPassed = 0;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
