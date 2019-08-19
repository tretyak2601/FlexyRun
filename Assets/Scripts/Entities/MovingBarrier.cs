using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarrier : Barrier
{
    [SerializeField] float speed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Transform rotateObject;

    private void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            rotateObject.eulerAngles -= moveDirection * speed;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
