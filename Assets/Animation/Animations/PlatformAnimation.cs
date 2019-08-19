using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float heigth;

    private float totalPassed = 0;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(PlatAnimation());
    }

    IEnumerator PlatAnimation()
    {
        while (true)
        {
            if (totalPassed <= heigth)
            {
                transform.position += Vector3.up * speed;
                totalPassed += speed;
            }
            else
            {
                transform.position = startPosition;
                totalPassed = 0;
            }
            
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
