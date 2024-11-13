using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public GameObject WinTextObject;
    private float speed;        //how hard the ball is pushed
    private float xDirection;   //move the ball left and right
    private float zDirection;   //move the ball forward and backwards
    private int count;   //count the pickups
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        count = 0;
        SetCountText();
        WinTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MoveBall();
    }

    private void MoveBall()
    {
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        rb.AddForce(direction.normalized * 1);
    }
    //listen for player pressing arrows of wasd keys
    private void GetPlayerInput()
    {
        xDirection = Input.GetAxis("Horizontal");
        float v1 = Input.GetAxis("Vertical");
        float v = v1;
        zDirection = v;

    }
    private void SetCountText()
    {
        CountText.text = "Count " + count.ToString();
        if (count >= 19)
        {
            WinTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

    }
}
