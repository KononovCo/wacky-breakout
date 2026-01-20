using UnityEngine;

public class QuitButton : MonoBehaviour, IClickListener
{
    public void OnClick()
    {
        GameManager.Instance.Sounds.Play(SoundType.Click);
        Application.Quit();
    }
}