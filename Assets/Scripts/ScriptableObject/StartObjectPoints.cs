using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StarterObject/StartObjectPoints", fileName = "New Start Values")]
public class StartObjectPoints : ScriptableObject
{
    public Vector3[] Points;
    public GameObject Agent;    
}
