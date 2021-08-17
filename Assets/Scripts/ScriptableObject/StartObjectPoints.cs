using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PanteonGames
{
    [CreateAssetMenu(menuName = "StarterObject/StartObjectPoints", fileName = "New Start Values")]
    public class StartObjectPoints : ScriptableObject
    {
        public Vector3[] Points;
        public GameObject Agent;
    }
}