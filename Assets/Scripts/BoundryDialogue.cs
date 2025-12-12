using TMPro;
using UnityEngine;


public class BoundryDialogue : MonoBehaviour
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
            string startTextState = "<color=#e02046>\"That blasted lion.\"</color><color=#d3cbcb> You mutter to yourself. </color><color=#e02046>\"I can't leave till I've dealth with him.\"</color>";
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
