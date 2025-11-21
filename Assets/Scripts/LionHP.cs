using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LionHP : MonoBehaviour
{
    public int lionHealth;
    [SerializeField] private AILionPatrol lionPatrol;
    [SerializeField] private Dialogue debugDialogue;
    [SerializeField] private PlayerInteractions playerInteractions;
    [SerializeField] private StoryDialogue storyDialogue;
    [SerializeField] private TMP_Text lionshealth;
    [SerializeField] private Shooting shootinglion;
    [SerializeField] private int minLionHealth;
    [SerializeField] private int maxLionHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lionHealth = Random.Range(minLionHealth, maxLionHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInteractions.killtheLion())
        {
            if (lionHealth != 0)
            {
                if (storyDialogue.gameStart() == true)
                {
//                    Debug.Log("Game Started");
                    lionshealth.alignment = TextAlignmentOptions.Center;
                    string startTextState = "lion's health is " + lionHealth;
                    lionshealth.color = Color.red;
                    lionshealth.text = startTextState;
                }
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
