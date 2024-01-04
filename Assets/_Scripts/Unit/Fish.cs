using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector3 _lastMovePoint;

    private void Awake()
    {
        if (_lastMovePoint == null)
        {
            Debug.LogError( transform.name + "Move point is null", gameObject);
        }   
    }

    private void Start()
    {
        LookAtMovePoint();
    }

    private void Update()
    {
        Move();
        // LookAtMovePoint();
        if (transform.position == _lastMovePoint)
        {
            _fishSpawner.ReturnFishToPool(this);
        }
    }


    private void Move()
    {
        // transform.position = Vector3.Lerp(transform.position, _lastMovePoint, _moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _lastMovePoint, _moveSpeed * Time.deltaTime);
    }
    private void LookAtMovePoint(){
        Vector3 diff = this.transform.position - _lastMovePoint;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    public void SetMovePoint(Vector3 movePoint)
    {
        _lastMovePoint = movePoint;
    }
    
}