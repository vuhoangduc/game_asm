using UnityEngine;
using UnityEngine.UI;

public class PlayGameScript : MonoBehaviour
{
    public Sprite[] image;
    private bool ok;
    private AudioSource music;
    
    public void startScenen(){
        Application.LoadLevel("PlayGame");
    }
    
    public void SoundImage(Button button)
    {
        music = GetComponent<AudioSource>();
        if (ok)
        {
            music.mute = false;
            ok = false;
            button.GetComponent<Image>().sprite = image[0];
        }
        else
        {
            music.mute = true;
            ok = true;
            button.GetComponent<Image>().sprite = image[1];
        }
    }
}
