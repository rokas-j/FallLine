using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject prefab;
    GameObject currPrefab;
    Coroutine touchEvent;

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<TimerScore>().isActive)
            return;
        if(Input.GetMouseButtonDown(0))
            StartPlacement();
        if(Input.GetMouseButtonUp(0))
            EndPlacement();
    }

    void StartPlacement()
    { 
        if(touchEvent!=null)
            StopCoroutine(touchEvent);
        touchEvent = StartCoroutine(PaintPrefab()); 
    }

    void EndPlacement()
    {
        if(currPrefab!=null)
            StopCoroutine(touchEvent);  
    }

    IEnumerator PaintPrefab()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currPrefab = Instantiate(prefab, new Vector3(position.x, position.y, -0.23f), Quaternion.identity);
        var parent = gameObject.GetComponent<FallingController>().currParent;
        currPrefab.transform.parent = parent.transform;

        while(true)
        {
            if (currPrefab!=null)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 objPos = currPrefab.transform.position;
                mousePos = new Vector3(mousePos.x, mousePos.y, 0);
                objPos = new Vector3(objPos.x, objPos.y, 0);
                float dist = Vector3.Distance(objPos, mousePos);
                currPrefab.transform.localScale = new Vector3(dist,currPrefab.transform.localScale.y,currPrefab.transform.localScale.z);

                float angle = AngleBetweenTwoPoints(objPos, mousePos);
                currPrefab.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            yield return null;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
}
