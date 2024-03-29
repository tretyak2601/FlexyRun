﻿using System;
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
        if (!RageMode.Instance.IsRageMode)
            StartCoroutine(SpeedDown());
    }

    private void Update()
    {
        if (((isMoving && !GameController.Instance.GameOver) || flexy.Jump.IsJumping) || RageMode.Instance.IsRageMode)
            transform.Translate(Vector3.forward * speed);
        else
            transform.Translate(Vector3.forward * .1f);
    }

    IEnumerator SpeedUp()
    {
        if (!speedUpSens || RageMode.Instance.IsRageMode)
            yield break;

        StartCoroutine(CameraFocus(0.5f));
        speed += 1.1f;
        yield return new WaitForSeconds(0.2f);
        speed -= 1f;
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

    IEnumerator CameraFocus(float timeInSeconds)
    {
        for (int i = 0; i < timeInSeconds / Time.deltaTime; i++)
        {
            if (i < (timeInSeconds / Time.deltaTime) / 2)
                Camera.main.fieldOfView += 0.3f;
            else
                Camera.main.fieldOfView -= 0.3f;

            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
    }
}
