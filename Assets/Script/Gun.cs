using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzleTranform;
    public Rigidbody2D rb2d;
    public Camera cam;
    public Transform playerTranform;
    public Vector3 offset;

    private Vector3 mousePos;
    private Vector2 gunDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTranform.position + offset;
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gunDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("鼠标左键按下");
            Instantiate(bullet, muzzleTranform.position, Quaternion.Euler(transform.eulerAngles));
        }
    }
}
