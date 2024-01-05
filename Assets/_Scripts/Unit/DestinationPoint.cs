using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    public static DestinationPoint Instance;
    public bool fishIn = false;
    private Collider2D fish;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {

    }
    public void SetPosition(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            fishIn = true;
            fish = collision;
        }
    }
    //on trigger exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            fishIn = false;
            fish = null;
        }
    }
    public void DespawnFish()
    {
        fish.gameObject.SetActive(false);
    }
}
