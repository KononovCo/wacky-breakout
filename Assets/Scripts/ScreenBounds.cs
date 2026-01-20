using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private BoxCollider2D leftBound;
    private BoxCollider2D topBound;
    private BoxCollider2D rightBound;
    private BoxCollider2D bottomBound;

    [SerializeField]
    private bool left = true;

    [SerializeField]
    private bool top = true;

    [SerializeField]
    private bool right = true;

    [SerializeField]
    private bool bottom = true;

    [SerializeField]
    private float thickness = 1;

    [SerializeField]
    private PhysicsMaterial2D material;

    private void Start()
    {
        leftBound = CreateBound("Left");
        topBound = CreateBound("Top");
        rightBound = CreateBound("Right");
        bottomBound = CreateBound("Bottom");

        UpdateBounds();
    }

    private BoxCollider2D CreateBound(string name)
    {
        GameObject bound = new(name);

        bound.transform.SetParent(transform);
        return bound.AddComponent<BoxCollider2D>();
    }

    private void UpdateBound(BoxCollider2D bound, bool enabled, Vector2 position, Vector2 size)
    {
        bound.enabled = enabled;

        if (bound.enabled)
        {
            bound.sharedMaterial = material;
            bound.transform.position = position;
            bound.size = size;
        }
    }

    private void UpdateBounds()
    {
        Camera camera = Camera.main;
        Vector2 position = camera.transform.position;

        float viewHeight = camera.orthographicSize * 2;
        float viewWidth = camera.aspect * viewHeight;

        float halfViewWidth = viewWidth / 2;
        float halfViewHeight = viewHeight / 2;
        float halfThickness = thickness / 2;

        float left = position.x - halfViewWidth - halfThickness;
        float top = position.y + halfViewHeight + halfThickness;
        float right = position.x + halfViewWidth + halfThickness;
        float bottom = position.y - halfViewHeight - halfThickness;

        Vector2 leftPosition = new(left, position.y);
        Vector2 topPosition = new(position.x, top);
        Vector2 rightPosition = new(right, position.y);
        Vector2 bottomPosition = new(position.x, bottom);

        Vector2 horizontal = new(viewWidth, thickness);
        Vector2 vertical = new(thickness, viewHeight);

        UpdateBound(leftBound, this.left, leftPosition, vertical);
        UpdateBound(topBound, this.top, topPosition, horizontal);
        UpdateBound(rightBound, this.right, rightPosition, vertical);
        UpdateBound(bottomBound, this.bottom, bottomPosition, horizontal);
    }
}