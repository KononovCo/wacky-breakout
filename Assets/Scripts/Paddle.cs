using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D physics;

    [SerializeField]
    private int power = 10;

    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        physics.AddForce(Input.GetAxis("Move") * power * transform.right);
    }
}