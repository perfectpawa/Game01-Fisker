using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _turnSpeed = 1f;
    [SerializeField] private float _turnTime = 1f;
    [SerializeField] private float _maxTurnAngle = 180f;
    [SerializeField] private float _minTurnAngle = -180f;
    [SerializeField] private Transform _movePoint;


    [SerializeField] private float turnTimer = 0f;
    [SerializeField] private bool isCompleteTurn = true;
    [SerializeField] private float turnAngle;

    private void Awake()
    {
        if (_movePoint == null)
        {
            _movePoint = transform.Find("MovePoint");
            Debug.Log("MovePoint is null, set to default");
        }
    }

    private void Update()
    {
        IsTurning();
        Move();
    }

    private void IsTurning()
    {
        if (!isCompleteTurn)
        {

            Turn();
            if (transform.rotation == Quaternion.Euler(0f, 0f, turnAngle))
            {
                isCompleteTurn = true;
            }
        }
        else
        {
            turnTimer += Time.deltaTime;
            if (turnTimer >= _turnTime)
            {
                isCompleteTurn = false;
                turnTimer = 0f;
                turnAngle = Mathf.Round(UnityEngine.Random.Range(_minTurnAngle, _maxTurnAngle));
            }
        }
    }

    private void Turn()
    {
        //rotate fish randomly between -180 and 180 degrees using lerping
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, turnAngle), _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        //move fish to move point
        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _moveSpeed * Time.deltaTime);
    }


}