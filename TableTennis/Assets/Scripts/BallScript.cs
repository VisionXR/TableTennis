using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Transform BallPos;
    public float BallForce = 3;
    Rigidbody rb;
    Vector3 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = (transform.right - transform.up).normalized;
    }

    public void Startball()
    {
        transform.position = BallPos.position;
        transform.rotation = BallPos.rotation;
        rb.AddForce(dir * BallForce);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            transform.position = BallPos.position;
            transform.rotation = BallPos.rotation;
            rb.AddForce(dir * BallForce);
        }
    }
}
