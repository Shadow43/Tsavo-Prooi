using TMPro;
using UnityEngine;

public class LionsLair : MonoBehaviour
{
    [SerializeField] private GameObject grayImage;
    [SerializeField] private GameObject boundryTextObject;
    [SerializeField] private TMP_Text boundryDialogue;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grayImage.SetActive(true);
            boundryTextObject.SetActive(true);
            string startTextState = "<color=#e02046>\"Lions don't do this.\"</color><color=#d3cbcb> You shudder in horror. </color><color=#e02046>\"Lion's don't have a lair like this.\"</color>";
            boundryDialogue.text = startTextState;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grayImage.SetActive(false);
            boundryDialogue.text = string.Empty;
            boundryTextObject.SetActive(false);
        }
    }

}
