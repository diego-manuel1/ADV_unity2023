using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CodeGamePhysics : MonoBehaviour
{
    public float forceMagnitud = 2f;
    public GameObject ball;
    private Rigidbody rb;
    private Camera cam;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3();
        initialPosition.x = ball.transform.position.x;
        initialPosition.y = ball.transform.position.y;
        initialPosition.z = ball.transform.position.z;
        rb = ball.GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = cam.transform.position - transform.position;
            rb.AddForce(direction.normalized * forceMagnitud, ForceMode.Impulse);
        }
        if (ball.transform.position.y < -7)    
        {
            rb.Sleep();
            ball.transform.Translate(initialPosition);
            rb.WakeUp();
        }
    }
}
