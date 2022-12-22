using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingController : MonoBehaviour
{
    public GameObject prevParent;
    public GameObject currParent;
    public GameObject player;
    public float resetAtY = 60;
    public float resetWhenY = 30;
    public bool stopFall = false;
    // Start is called before the first frame update
    public TrailRenderer trail1;
    public TrailRenderer trail2;
    void Start()
    {
        Physics.gravity = new Vector3(0, -2f, 0);
        SpawnNewParent();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<TimerScore>().isActive)
        {
            return;
        }
        if (player.transform.position.y < resetWhenY && !stopFall)
        {
            
            player.transform.position += new Vector3(0,resetAtY,0);
            currParent.transform.position = new Vector3(currParent.transform.position.x,resetAtY,currParent.transform.position.z);
            if (prevParent != null){
                Destroy(prevParent);
            }
            prevParent = currParent;
            SpawnNewParent();
            // handle trails
            trail1.Clear();
            trail2.Clear();
        }
    }

    void SpawnNewParent()
    {
        currParent = new GameObject();
    }
}
