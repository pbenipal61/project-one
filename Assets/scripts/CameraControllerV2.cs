using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerV2 : MonoBehaviour
{
    private float speed = 10f;  // Current speed of camera
    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

    }

    /// <summary>
    /// Sets the speed.
    /// </summary>
    /// <param name="speed">Speed.</param>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    /// <summary>
    /// Gets the speed.
    /// </summary>
    /// <returns>The speed.</returns>
    public float GetSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Gets the y coordinate of position.
    /// </summary>
    /// <returns>The YP osition.</returns>
    public float GetYPosition()
    {
        return transform.localPosition.y;
    }

    /// <summary>
    /// Gets the position vector.
    /// </summary>
    /// <returns>The position.</returns>
    public Vector3 GetPosition() { return transform.localPosition; }

}
