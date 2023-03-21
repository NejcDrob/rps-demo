using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public TMP_Text countText;
    public TMP_Text winText;
    private int wincon = 0;
    public float PlaceX;
    public float PlaceZ;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            PlaceX = Random.Range(-9, 10);
            PlaceZ = Random.Range(-9, 10);
            other.gameObject.transform.position = new Vector3(PlaceX, 0.5f, PlaceZ);
            other.gameObject.SetActive(true);
            count++;
            SetCountText();

        }
    }
    void SetCountText()
    {
        if (count >= 2)
        {
            wincon = 1;
            winText.text = " YOU WIN \n PRESS R TO RESET";
        }
        if (count == 69)
        {
            countText.text = "Count: " + count.ToString() + " NICE!";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && wincon == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
