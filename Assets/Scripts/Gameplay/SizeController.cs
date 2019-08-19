using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    [SerializeField] InputController input;
    [SerializeField, Range(0.1f, 2f)] float sens;
    [SerializeField] float minSize = 1f;
    [SerializeField] float maxSize;
    
    float avarage = 0;

    public bool IsSizing { get; set; } = true;

    private void Awake()
    {
        input.onDragEvent += DragHandler;
        avarage = (maxSize + minSize) / 2;
        transform.localScale = new Vector3(avarage, avarage, avarage);
    }

    private void DragHandler(float delta)
    {
        if (!IsSizing)
            return;

        delta *= (sens / 10);

        if (delta > 0 && transform.localScale.y < maxSize)
        {
            transform.localScale = transform.localScale.y + delta > maxSize ?
                new Vector3(minSize, maxSize, avarage) :
                transform.localScale + new Vector3(-delta, delta, 0);

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + delta / 2, transform.localPosition.z);
        }

        if (delta < 0 && transform.localScale.x < maxSize)
        {
            transform.localScale = transform.localScale.x - delta > maxSize ?
                new Vector3(maxSize, minSize, avarage) :
                transform.localScale + new Vector3(-delta, delta, 0);

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + delta / 2, transform.localPosition.z);
        }
    }

    public void SetAvarageSize()
    {
        transform.localScale = new Vector3(avarage, avarage, avarage);
    }
}