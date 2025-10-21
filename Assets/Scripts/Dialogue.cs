using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TMP_Text text;
    //    public bool LionDetectedPlayerCalled;

    private void Start()
    {
        text.color = Color.red;
        text.text = string.Empty;
    }
    private void Update()
    {
//        if (!LionDetectedPlayerCalled)
//        {
//            text.text = string.Empty;
//        }
    }
    public void LionDetectedPlayer()
    {
//        Debug.Log("The function for the lion detecting the player for text on screen!");
//        LionDetectedPlayerCalled = !LionDetectedPlayerCalled;
        string lionState = "The Lion has detected and is about to stalk the player";
        text.text = lionState;
    }

    public void LionCaughtPlayer()
    {
//        Debug.Log("The function for the lion catching the player for text on screen!");
        string lionState = "The Lion has caught and is about to devour the player. \nGameOver. Please try to escape better next time!";
        text.text = lionState;
    }
    public void LionChasingPlayer()
    {
//        Debug.Log("The function for the lion chasing the player for text on screen!");
        string lionState = "The Lion is currently chasing the player. RUN!";
        text.text = lionState;
    }
    public void LionStalkingPlayer()
    {
//        Debug.Log("The function for the lion stalking the player for text on screen!");
        string lionState = "The Lion is currently stalking the player.";
        text.text = lionState;
    }
    public void LionLoosingPlayer()
    {
//        Debug.Log("The function for the lion loosing the player for text on screen!");
        string lionState = "The Lion is currently loosing the player.";
        text.text = lionState;
    }
    public void LionLostPlayer()
    {
        text.text = string.Empty;
    }

}
