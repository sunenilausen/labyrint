using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public int maxPoint;
    public string nextScene;
    public int health;
    public string loseScene;
    public Text healthText;

    private Rigidbody rb;
    private int count;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        SetHealthText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Goal") && count >= maxPoint)
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
        }
        else if (other.gameObject.CompareTag("Damages"))
        {
            Debug.Log("hit");
            health -= 1;
            SetHealthText();
            if (health <= 0)
            {
                SceneManager.LoadScene(loseScene, LoadSceneMode.Additive);
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
