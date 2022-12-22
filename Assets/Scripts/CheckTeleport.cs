using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 prevPos;
    
    void Start()
    {
        prevPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var currPos = gameObject.transform.position;
        var dist = Vector3.Distance(prevPos, currPos);
        if (dist>1)
            GetComponent<TrailRenderer>().emitting = false;
        else
            GetComponent<TrailRenderer>().emitting = true;
        prevPos = currPos;
    }
}
