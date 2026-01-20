using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButton : MonoBehaviour, IClickListener
{
    [SerializeField]
    private string sceneName;

    public void OnClick()
    {
        GameManager.Instance.Sounds.Play(SoundType.Click);

        GameManager.Instance.Delays.Run(0.5f, () =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}