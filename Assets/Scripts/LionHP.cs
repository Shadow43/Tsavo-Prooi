using TMPro;
using UnityEngine;

public class LionHP : MonoBehaviour
{
    public int lionHealth;
    [SerializeField] private AILionPatrol lionPatrol;
    [SerializeField] private Dialogue debugDialogue;
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private TMP_Text lionshealth;
    [SerializeField] private Shooting shootinglion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lionHealth = Random.Range(8, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(storyDialogue.killtheLion())
        {
            if (lionHealth != 0)
            {
                lionshealth.alignment = TextAlignmentOptions.Center;
                string startTextState = "lion's health is " + lionHealth;
                lionshealth.color = Color.red;
                lionshealth.text = startTextState;
            }
            else
            {
                lionshealth.text = string.Empty;
            }
        }
        else
        {
            lionshealth.text = string.Empty;
        }
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
            lionshealth.text = string.Empty;
            debugDialogue.LionKilled();
            lionPatrol.setPaused(true);
            shootinglion.OnDisable();
        }
    }
}
