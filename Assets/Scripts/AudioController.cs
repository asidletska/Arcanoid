using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void MuteHandler(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
            PlayerPrefs.Save();
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.Save();
        }
    }
}
