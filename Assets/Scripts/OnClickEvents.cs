using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    public GameObject placeHolders;

    private CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
            soundsText.text = "/";
        else
            soundsText.text = "";

        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    public void ToggleMute()
    {
        if(GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
    }

    public void DualMode(int mode)
    {
        if (mode == 0)
        {
            GameManager.dualGameMode = false;
            PlayerPrefs.SetInt("CurrentGameMode", 0);
            placeHolders.SetActive(false);
        } else if (mode == 1)
        {
            GameManager.dualGameMode = true;
            PlayerPrefs.SetInt("CurrentGameMode", 1);
            placeHolders.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
