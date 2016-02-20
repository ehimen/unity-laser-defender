using UnityEngine;

class Transformer
{
    private float xmin;
    private float xmax;

    private Transform transform;

    private Vector3 objectSize;

    public Transformer(Camera camera, Transform transform, Vector3 size)
    {
        this.transform = transform;
        objectSize = size;
        InitialiseSpaceBoundaries(camera);
    }

    public bool MoveInXRelativeToTime(float amount)
    {
        float prospectiveX = transform.position.x + (amount * Time.deltaTime);
        float actualX = Mathf.Clamp(prospectiveX, xmin, xmax);

        transform.position = new Vector3(
            actualX,
            transform.position.y,
            transform.position.z
        );

        // Return if we've been clamped.
        return (actualX != prospectiveX);
    }

    void InitialiseSpaceBoundaries(Camera camera)
    {
        // Gets a point in the world space based on x and y, and the plane on to
        // which we're projecting (the z value). (0, 0) would be bottom left, (1, 1)
        // would be top right of the screen.

        // Not needed for 2D space, but useful for when we need 3D space.
        // We need to know the plane on to which we're projecting.
        float distance = transform.position.z - Camera.main.transform.position.z;

        // Take half of the size of the object and add it as padding so the right/left
        // sides stop at the edge of the screen.
        float padding = objectSize.x / 2;

        // Bottom left.
        xmin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;

        // Bottom right.
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - padding;
    }

}
