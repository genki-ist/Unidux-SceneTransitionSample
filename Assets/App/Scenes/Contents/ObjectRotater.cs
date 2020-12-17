using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var angle = this.transform.rotation.eulerAngles;
        var elapsedTime = Time.time - this.startTime; 
        var speed = elapsedTime * 10f;
        angle = Vector3.one * speed;
        var rotation = Quaternion.Euler(angle);
        this.transform.rotation = rotation;
    }
}
