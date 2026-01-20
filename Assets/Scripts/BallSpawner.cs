using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private int minDelay = 5;

    [SerializeField]
    private int maxDelay = 10;

    [SerializeField]
    private GameObject prefab;

    private void Start() => StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        Vector2 point = Vector2.zero;
        float radius = prefab.GetComponent<CircleCollider2D>().radius;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            if (!Physics2D.OverlapCircle(point, radius))
            {
                Instantiate(prefab);
            }
        }
    }
}