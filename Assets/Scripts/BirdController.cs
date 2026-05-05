using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float gravity = 10f;
    public float JumpForce = 10f;
    private bool Salto = false;
    private int Score = 0;
    public TextMeshProUGUI TextoScore;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        UpdateUI();
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Salto = true;
            animator.SetBool("Jumping", true);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravity);
        if (Salto)
        {
            rb.velocity = Vector3.up * JumpForce; 
            Salto = false;
        }
        if (rb.velocity.y < 0 )
        {
            animator.SetBool("Jumping", false);
        }
    }
    public void UpdateUI()
    {
        TextoScore.text = "Puntos: " + Score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + "he colisionado con " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("colision detectada");
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBox"))
        {
            Score += 1;
            UpdateUI();
            Debug.Log(Score);
        }
    }
}

