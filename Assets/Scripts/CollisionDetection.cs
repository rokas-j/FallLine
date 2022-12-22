using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public TimerScore timerScore;
    public AudioSource fallingSound;
    public AudioSource dropSound;
    public AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0, -10f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "TimerUp")
        {
            timerScore.AddToTimer();
            collectSound.Play();
        }
        if (collision.gameObject.tag == "Ground")
        {
            fallingSound.Stop();
            dropSound.Play();
        }
    }
}
