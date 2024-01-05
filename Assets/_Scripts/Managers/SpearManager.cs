using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearManager : MonoBehaviour
{
    
    public static SpearManager Instance;
    [SerializeField] private BigSpear _bigSpear;
    [SerializeField] private DestinationPoint _destinationPoint;
    [SerializeField] private SmallSpear _smallSpear;
    private bool mouseDown = false;
    public bool spearLanded = false;
    private float timer = 0;
    private Vector3 mousePos = new Vector3(0, 0, 0);
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {


        if (Input.GetMouseButtonDown(0) && !mouseDown)
        {
            if(GameManager.Instance.GameState != GameState.InGame) return;
        
            mouseDown = true;
            _bigSpear.gameObject.SetActive(true);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            _destinationPoint.SetPosition(mousePos);
            _smallSpear.Spawn(mousePos);
        }

        if (mouseDown)
        {
            _bigSpear.LauchSpear();
        }
        LaunchControl();
        if (spearLanded)
        {
            timer += Time.deltaTime;
            if (timer >= 0.25)
            {
                spearLanded = false;
                timer = 0;
                _bigSpear.ReLoad();
                mouseDown = false;
            }
        }
    }

    private void LaunchControl()
    {
        if (_bigSpear.OutOfCamera())
        {
            _bigSpear.gameObject.SetActive(false);
            _smallSpear.Move(_destinationPoint.transform);
        }
    }
}
