using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigSpear : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    // public void LookAtMouse()
    // {
    //     Vector3 mousePos = Input.mousePosition;
    //     Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
    //     mousePos.x = mousePos.x - objectPos.x;
    //     mousePos.y = mousePos.y - objectPos.y;

    //     float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
    //     transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    // }
    public bool OutOfCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        return (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1);
    }
    public void LauchSpear()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _moveSpeed);
        //localScale smaller with lerp
    }
    public void ReLoad()
    {
        transform.position = new Vector3(0, -4, 0);
        gameObject.SetActive(true);
    }
}
