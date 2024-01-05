using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpear : MonoBehaviour
{
    SpearManager spearManager;
    DestinationPoint destinationPoint;
    [SerializeField] private float _moveSpeed;
    private void Start()
    {
        spearManager = SpearManager.Instance;
        destinationPoint = DestinationPoint.Instance;
    }

    public void Spawn(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(position.x, 7, 0);
    }
    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestinationPoint"))
        {
            gameObject.SetActive(false);
            
            if(destinationPoint.fishIn)
            {
                destinationPoint.fishIn = false;
                destinationPoint.DespawnFish();
                collision.gameObject.SetActive(false);
                spearManager.spearLanded=true; 
                Debug.Log("Fish in");
            }
            else
            {
                spearManager.spearLanded=true;
                collision.gameObject.SetActive(false);
                Debug.Log("Fish out");
            }
        }
    }
}
