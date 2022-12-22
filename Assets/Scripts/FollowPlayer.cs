using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        followPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer(){
        // check if end was not reached
        Camera cam = gameObject.GetComponent<Camera>();
        if (gameObject.transform.position.y > cam.orthographicSize)
        {
            float playerY = player.transform.position.y-8.0f;
            transform.position = new Vector3(transform.position.x, playerY, transform.position.z);
        }

    }
}
