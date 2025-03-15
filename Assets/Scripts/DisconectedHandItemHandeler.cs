using UnityEngine;

public class DisconectedHandItemHandeler : MonoBehaviour
{
    public GameObject handle;
    private Rigidbody rb ;
    // Update is called once per frame
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position= handle.transform.position;
    }
    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity * 0.9f;
    }
}
