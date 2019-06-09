using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityMethodsAndEnums.UtilityEnums;
using UtilityMethodsAndEnums.Models;

public class GameManager : MonoBehaviour
{
    [Header("Input")]
    private SwipeInputV2 swipeInput;

    [Header("Player")]
    private float extremeX = 2f;
    public Player player;

    private void Start()
    {
        swipeInput = SwipeInputV2.Instance;
        LevelCreationData levelCreationData = new LevelCreationData(20);
        FindObjectOfType<LevelGenerator>().Generate(levelCreationData);
    }

    /// <summary>
    /// Recieved input from SwipeInputV2 class
    /// </summary>
    /// <param name="swipe">Swipe.</param>
    public void RecieveInput(Swipe swipe)
    {
        Debug.Log(swipe);
        ReactToSwipe(swipe);
    }

    /// <summary>
    /// Reacts to swipe input.
    /// </summary>
    /// <param name="swipe">Swipe.</param>
    private void ReactToSwipe(Swipe swipe)
    {
        if(swipe == Swipe.RIGHT)
        {
            StartCoroutine(MoveTo(new Vector2(extremeX, player.transform.localPosition.y), player.gameObject));
        }
        else if(swipe == Swipe.LEFT)
        {
            StartCoroutine(MoveTo(new Vector2(-1 * extremeX, player.transform.localPosition.y), player.gameObject));
        }
    }

    /// <summary>
    /// Animate object and move it to the position.
    /// </summary>
    /// <returns>The to.</returns>
    /// <param name="pos">Position to move the object to. Should be a local position.</param>
    /// <param name="obj">Object to move.</param>
    private IEnumerator MoveTo(Vector2 pos, GameObject obj)
    {
        Debug.Log("Here");
        float time = 0.3f;
        Vector2 startPos = obj.transform.localPosition;
        for (float t = 0; t <= 1 * time; t += Time.deltaTime)
        {
            obj.transform.localPosition = Vector2.Lerp(startPos, pos, t / time);
            yield return 0;
        }
        obj.transform.localPosition = pos;

    }

}
