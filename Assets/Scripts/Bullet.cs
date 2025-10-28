using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Vector3 normalizeDirection;
    private Transform target;
    [SerializeField] private float countdown;
    [SerializeField] private float timer;
    [SerializeField] LionHP lionhp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("The Target").transform;
        normalizeDirection = (target.position - transform.position).normalized;
        target = null;

        lionhp = GameObject.FindGameObjectWithTag("Lion").GetComponent<LionHP>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += normalizeDirection * movementSpeed * Time.deltaTime;
        if (timer <= countdown)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("The Lion"))
        {
//            Debug.Log("Hit the lion");
            lionhp.LionHPHit();
            Destroy(this.gameObject);
        }
//        if (other.gameObject.CompareTag("The Ground"))
//        {
//            Debug.Log("Hit the ground");
//            Destroy(this.gameObject);
//        }
    }
}
