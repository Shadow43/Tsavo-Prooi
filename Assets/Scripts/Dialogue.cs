using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{

    public TMP_Text lionState1;
    public TMP_Text lionState2;
    public TMP_Text lionState3;
    public TMP_Text lionState4;

    public void LionDetectedPlayer()
    {
        string lionState = " " + lionState1;
        lionState1.text = lionState;
    }

}
