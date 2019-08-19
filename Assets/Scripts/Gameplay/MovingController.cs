using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] FlexyPlayer flexy;
    [SerializeField] InputController input;
    [SerializeField] Camera cam;
    [SerializeField] float speed;

    private float minSpeed;
    public float Speed { get { return speed; } set { speed = value; } }
    public bool isMoving { get; set; } = true;

    public event Action OnLose;

    bool speedUpSens = true;

    private void Awake()
    {
        input.onPointerDown += () => isMoving = true;
        input.onPointerUp += () => isMoving = false;
        flexy.OnBarrierPassed += () => StartCoroutine(SpeedUp());
        flexy.OnBarrierTriggered += SpeedDownHandler;

        minSpeed = speed;
    }

    private void SpeedDownHandler()
    {
        StartCoroutine(SpeedDown());
    }

    private void Update()
    {
        if (isMoving && !GameController.Instance.GameOver)
            transform.Translate(Vector3.forward * speed);
    }

    IEnumerator SpeedUp()
    {
        if (!speedUpSens)
            yield break;

        speed += 0.6f;
        yield return new WaitForSeconds(0.33f);
        speed -= 0.5f;
    }

    IEnumerator SpeedDown()
    {
        speedUpSens = false;

        if (speed == minSpeed)
            OnLose?.Invoke();
        else
        {
            speed = minSpeed;
            speed -= 0.5f;
        }
        
        yield return new WaitForSeconds(0.33f);
        speedUpSens = true;
        speed = minSpeed;
    }
}
