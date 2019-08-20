using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class CollisionDetector : MonoBehaviour
{
    Rigidbody rigid;
    Collider coll;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        Physics.gravity = new Vector3(0, -150, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigid.isKinematic = false;
            coll.isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rigid.useGravity = true;
            Vector3 direction = new Vector3(Random.Range(-45, 45), 25, 75);
            rigid.AddForce(direction, ForceMode.Impulse);
        }
    }
}
