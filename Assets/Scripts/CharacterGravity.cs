using UnityEngine;

public class CharacterGravity : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] private Vector3 playerPostion;
    [SerializeField] private float playerPositionY;
    [SerializeField] private bool _isTriggered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPostion = player.transform.position;
        playerPositionY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerPostion.x = player.transform.position.x;
        playerPostion.z = player.transform.position.z;
        if (_isTriggered == false)
        {
            player.transform.position = new Vector3(transform.position.x, playerPositionY, transform.position.z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isTriggered = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        {
            if(other.CompareTag("Player") && _isTriggered == true)
            {
                Debug.Log("is on train track");
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(transform.position.x, playerPositionY, transform.position.z);
            _isTriggered = false;
        }
    }
}