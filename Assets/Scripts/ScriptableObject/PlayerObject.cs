using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerObject/PlayerValues", fileName = "New PLayer Values")]
public class PlayerObject : ScriptableObject
{
    public Vector3[] Points;
    public GameObject Agent;
}
