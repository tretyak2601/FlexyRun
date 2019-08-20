using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsAnimation : MonoBehaviour
{
    [SerializeField] Transform firstObject;
    [SerializeField] Transform secondObject;
    [SerializeField] float speed;
    [SerializeField] float width = 2f;

    private float totalPassed = 0;
    private Vector3 startScale;
    private Vector3 leftStartPosition;
    private Vector3 rightStartPosition;

    private void Start()
    {
        leftStartPosition = firstObject.localPosition;
        rightStartPosition = secondObject.localPosition;
        startScale = firstObject.localScale;
        StartCoroutine(ScisAnimation());
    }

    IEnumerator ScisAnimation()
    {
        while (true)
        {
            if (totalPassed <= width)
            {
                firstObject.localScale += Vector3.right * speed;
                firstObject.transform.localPosition += Vector3.right * speed / 2;
                secondObject.localScale += Vector3.left * speed;
                secondObject.transform.localPosition += Vector3.left * speed / 2;
                totalPassed += speed;
            }
            else
            {
                yield return new WaitForSeconds(1);

                firstObject.localScale = startScale;
                secondObject.localScale = startScale;

                firstObject.localPosition = leftStartPosition;
                secondObject.localPosition = rightStartPosition;

                totalPassed = 0;
            }


            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
