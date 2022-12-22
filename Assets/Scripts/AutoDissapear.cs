using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDissapear : MonoBehaviour
{
    [SerializeField] private float fadePerSecond = 2f;
    public bool fadeOut = false;
    public float timeToDissapear = 1f;
    float elapsed = 0f;
 
    private void Update() {
        var material = GetComponentInChildren<Renderer>().material;
        var color = material.color;
        if (fadeOut)
           material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
        
       elapsed += Time.deltaTime;
       if (elapsed >= timeToDissapear) {
           elapsed = elapsed % 1f;
           fadeOut = true;
       }
       if (material.color.a <= 0f)
           Destroy(gameObject);
    }
}
