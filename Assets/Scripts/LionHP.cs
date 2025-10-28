using UnityEngine;

public class LionHP : MonoBehaviour
{
    public int lionHealth;
    [SerializeField] private AILionPatrol lionPatrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lionHealth = Random.Range(8, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LionHPHit()
    {
//        Debug.Log("Lion looses health");
        if (lionHealth > 0)
        {
            lionHealth -= 1;
        }
        if (lionHealth == 0)
        {
            Debug.Log("Lion is dead");
        }
    }
}
