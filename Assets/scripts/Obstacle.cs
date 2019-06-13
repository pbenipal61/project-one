using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityMethodsAndEnums.UtilityEnums.Obstacles;

public class Obstacle : MonoBehaviour
{
    [HideInInspector]
    private ObstacleType obstacleType;                  // Reference to type of obstacle this is
    private SpriteRenderer spriteRenderer;              // Reference to main sprite renderer of this object
    private SpriteRenderer[] spriteRenderersInChildren; // Reference to all sprite renderes in the children including the main one
    private Collider2D coll;                            // Reference to the collider attached to this object
    private bool isActive;                              // Check if this obstacle is active
    private float speed = 10f;                          // Current speed of translation
    private Vector2 originalPosition = Vector2.zero;                   // First position for this obstacle
    private int poolIndex = 1;                          // Index in the pool

   
    /// <summary>
    /// Init this instance of obstacle. Needs to be overridden by extending classes.
    /// </summary>
    /// <param name="obstacleType">Obstacle type.</param>
    public virtual void Init(ObstacleType obstacleType) { }

    /// <summary>
    /// Init this obstacle and sets position to specified position.
    /// </summary>
    /// <param name="position">Position.</param>
    public virtual void Init(Vector2 position)
    {
        SetPosition(position);
    }


    /// <summary>
    /// Activate this instance based on provided position.
    /// </summary>
    /// <param name="position">Position.</param>
    public virtual void Activate(Vector2 position)
    {
        SetBasicsActive();
        Init(position);
    }

   
    /// <summary>
    /// Sets the basics active. Basics include Sprite Renderer and Collider2D
    /// </summary>
    private void SetBasicsActive()
    {
        SpriteRenderer rend = GetSpriteRenderer();
        rend.enabled = true;
        Collider2D col = GetCollider();
        col.enabled = true;
        isActive = true;
    }
    /// <summary>
    /// Deactivate this instance.
    /// </summary>
    public virtual void Deactivate()
    {
        SpriteRenderer rend = GetSpriteRenderer();
        rend.enabled = false;
        Collider2D col = GetCollider();
        col.enabled = false;
        isActive = false;
    }
    /// <summary>
    /// Gets the sprite renderer for this object.
    /// </summary>
    /// <returns>The sprite renderer.</returns>
    public virtual SpriteRenderer GetSpriteRenderer()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        }

        return spriteRenderer;
    }

    /// <summary>
    /// Gets the sprite renderers in children.
    /// </summary>
    /// <returns>The sprite renderers in children.</returns>
    public virtual SpriteRenderer[] GetSpriteRenderersInChildren()
    {
        if(spriteRenderersInChildren == null)
        {
            spriteRenderersInChildren = gameObject.GetComponentsInChildren<SpriteRenderer>();
        }
        return spriteRenderersInChildren;
    }

    /// <summary>
    /// Gets the collider.
    /// </summary>
    /// <returns>The collider.</returns>
    public virtual Collider2D GetCollider()
    {
        if(coll == null)
        {
            coll = gameObject.GetComponentInChildren<Collider2D>();
        }
        return coll;
    }

    /// <summary>
    /// Gets the speed.
    /// </summary>
    /// <returns>The speed.</returns>
    public virtual float GetSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Sets the speed.
    /// </summary>
    /// <param name="speed">Speed.</param>
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    /// <summary>
    /// Sets the position.
    /// </summary>
    /// <param name="position">Position.</param>
    public virtual void SetPosition(Vector2 position)
    {
        this.gameObject.transform.localPosition = position;
    }



    /// <summary>
    /// Gets the position.
    /// </summary>
    /// <returns>The position.</returns>
    public virtual Vector2 GetPosition()
    {
        return this.gameObject.transform.localPosition;
    }


    //private void Update()
    //{
    //    if (isActive)
    //    {
    //        float EPSILON = 0;
    //        if (System.Math.Abs(cameraController.GetYPosition() - 5) > EPSILON)
    //        {
    //            if (transform.localPosition.y <= cameraController.GetYPosition() - 5)
    //            {

    //                SetPosition(GenerateNewPosition());
    //            }
    //        }
    //    }
    //}
}
