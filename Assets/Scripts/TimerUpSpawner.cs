using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUpSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject TimerUpPrefab;
    public GameObject Camera;
    float xMin = -3;
    float xMax = 5;
    public float frequency = 1;
    float elapsed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        groundPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<TimerScore>().isActive)
        {
            groundPrefab.SetActive(true);
            Destroy(gameObject.GetComponent<FallingController>().prevParent);
            Destroy(gameObject.GetComponent<FallingController>().currParent);
            return;
        }
        elapsed += Time.deltaTime;
        if (elapsed >= Random.Range(-0.5f, 0.5f)+frequency) {
            elapsed = elapsed % 1f;
            SpawnInRandomPlace();
        }
    }

    void SpawnInRandomPlace()
    {
        Vector3 position = new Vector3(Random.Range(xMin, xMax), Camera.transform.position.y-11.2f, 0);
        var spawnedObj = Instantiate(TimerUpPrefab, position, Quaternion.identity);
        var parent = gameObject.GetComponent<FallingController>().currParent;
        spawnedObj.transform.parent = parent.transform;
    }
}
