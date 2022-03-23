using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float camSpeed;
    private float closestPoint;

    public Transform[] camPoints;
    [SerializeField] private Transform player;

    void Update()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = player.transform.position;

        foreach (Transform t in camPoints)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        transform.position = Vector3.Lerp(transform.position, tMin.position, Time.deltaTime * camSpeed);
    } 
}
