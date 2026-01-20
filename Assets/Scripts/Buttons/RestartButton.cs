using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IClickListener
{
    public void OnClick()
    {
        GameManager.Instance.Sounds.Play(SoundType.Click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}