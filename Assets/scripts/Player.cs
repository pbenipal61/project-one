using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityMethodsAndEnums.UtilityEnums;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public PlayerType playerType;

    /// <summary>
    /// Init this player.
    /// </summary>
    public virtual void init() { }

}
