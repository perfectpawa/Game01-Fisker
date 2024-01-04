using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _lastMovePoint;

    private void Awake()
    {
        if (_lastMovePoint == null)
        {
            Debug.LogError( transform.name + "Move point is null", gameObject);
        }   
    }

    private void Start()
    {
        LookAtMovePoint(_lastMovePoint.position);
    }

    private void Update()
    {
        Move();
        // LookAtMovePoint();
        if (transform.position == _lastMovePoint.position)
        {
            _fishSpawner.ReturnFishToPool(this);
        }
    }


    private void Move()
    {
        // transform.position = Vector3.Lerp(transform.position, _lastMovePoint.position, _moveSpeed * Time.deltaTime);
        Vector3 point = Vector3.MoveTowards(transform.position, _lastMovePoint.position, _moveSpeed * Time.deltaTime);
        LookAtMovePoint(point);
        transform.position = point;
    }
    private void LookAtMovePoint(Vector3 point){
        Vector3 diff = transform.position - point;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    public void SetMovePoint(Transform movePoint)
    {
        _lastMovePoint = movePoint;
    }
    
}