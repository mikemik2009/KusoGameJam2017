using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour {
    private float turnSpeed = 50f;
    
    // Update is called once per frame
    void Update () {
        
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }
}
