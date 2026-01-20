using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private int margin = 2;

    [SerializeField]
    private int offset = 0;

    [SerializeField]
    private GameObject[] prefabs;

    private void Start()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            float offset = (i - (prefabs.Length - 1) * 0.5f) * margin;
            Vector2 position = Vector2.right * offset;

            position.y = this.offset;
            Instantiate(prefabs[i], position, Quaternion.identity);
        }
    }
}