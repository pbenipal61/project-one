using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityMethodsAndEnums.UtilityEnums;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;           // Reference to rigibody2D connected to this player
    private PlayerType playerType;      // Player type
    private float extremeX = -100;             // Extreme x allowed


    /// <summary>
    /// Init this player.
    /// </summary>
    public virtual void init() { }

    /// <summary>
    /// Init this player with specified extreme x.
    /// </summary>
    /// <param name="extremeX">Extreme x.</param>
    public virtual void Init(float extremeX)
    {
        if (extremeX < 0)
        {
            extremeX = -1 * extremeX;
        }
        this.extremeX = extremeX;
    }

    /// <summary>
    /// Gets the rigidbody2D.
    /// </summary>
    /// <returns>The rigidbody.</returns>
    public virtual Rigidbody2D GetRigidbody()
    {
        if(body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }

        return body;
    }

    /// <summary>
    /// Gets the position.
    /// </summary>
    /// <returns>The position.</returns>
    public virtual Vector3 GetPosition()
    {
        return (Vector2) transform.localPosition;
    }

    /// <summary>
    /// Sets the position.
    /// </summary>
    /// <param name="position">Position.</param>
    public virtual void SetPosition(Vector2 position)
    {
        transform.localPosition = new Vector3(position.x, position.y , transform.localPosition.z);
    }

    /// <summary>
    /// Sets the X position.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    public virtual void SetXPosition(float x)
    {
        transform.localPosition = new Vector3(x, GetPosition().y, GetPosition().z);
    }

    /// <summary>
    /// Sets the Y position.
    /// </summary>
    /// <param name="y">The y coordinate.</param>
    public virtual void SetYPosition(float y)
    {
        transform.localPosition = new Vector3(GetPosition().x, y, GetPosition().z);
    }

    /// <summary>
    /// Sets the z position
    /// </summary>
    /// <param name="z">The z coordinate.</param>
    private void SetZPosiiton(float z)
    {
        transform.localPosition = new Vector3(GetPosition().x, GetPosition().y, z);
    }
    private void Update()
    {
        if (extremeX > 0)
        {
            float x = GetPosition().x;

            if(x > extremeX)
            {
                SetXPosition(extremeX);
            }
            else if (x < -1*extremeX)
            {
                SetXPosition(-1 * extremeX);
            }

            float z = GetPosition().z;
            if(z < 1)
            {
                SetZPosiiton(1);
            }
        }
        else
        {
            ThrowError("Player not initialized");
        }
    }

    /// <summary>
    /// Throws the error.
    /// </summary>
    /// <param name="error">Error.</param>
    public virtual void ThrowError(string error)
    {
        Debug.LogError(error);
    }
}
