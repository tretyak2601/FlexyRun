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
            float x1 = Random.Range(-90, -45);
            float x2 = Random.Range(45, 90);
            float x = Random.Range(0, 2);
            x = x == 0 ? x1 : x2;

            Vector3 direction = new Vector3(x, Random.Range(45, 75), Random.Range(100, 125));
            rigid.AddForce(direction, ForceMode.Impulse);
            coll.isTrigger = true;
        }
    }
}
