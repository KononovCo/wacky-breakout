using UnityEngine;

public class MenuSwitchButton : MonoBehaviour, IClickListener
{
    [SerializeField]
    private GameObject close;

    [SerializeField]
    private GameObject open;

    public void OnClick()
    {
        GameManager.Instance.Sounds.Play(SoundType.Click);

        close.SetActive(false);
        open.SetActive(true);
    }
}