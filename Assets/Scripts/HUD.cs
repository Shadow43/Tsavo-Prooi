using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private TMP_Text ammo;
    [SerializeField] private GameObject ammunition;
    [SerializeField] private TMP_Text resources;
    [SerializeField] private GameObject woodandRope;
    [SerializeField] bool gameStarted;
    //[SerializeField] int counter;
    public int counter;
    [SerializeField] private bool ammoCounter;
    [SerializeField] private bool resourceCounter;


    void Start()
    {
        counter = 0;
        ammo.text = string.Empty;
        resources.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && storyDialogue.killtheLion())
        {
            ammunition.SetActive(true);
            ammoCounter = true;
            gameStarted = true;
        }
        if (!gameStarted && storyDialogue.trapRepair())
        {
            woodandRope.SetActive(true);
            resourceCounter = true;
            gameStarted = true;
        }
        if (resourceCounter == true)
        {
            string startTextState = "Resources " + counter;
            resources.text = startTextState;
        }
        if (ammoCounter == true)
        {
            string startTextState = "Ammo " + counter;
            ammo.text = startTextState;
        }
    }
    //public int SalvageCounter()
    //{
    //    return counter;
    //}
    //public void PickUpCounter()
    //{
    //    counter++;
    //}
}
