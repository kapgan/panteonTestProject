using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PlayerObject/PlayerValues", fileName = "New PLayer Values")]
public class playerObject : ScriptableObject
{
    public List<Transform> startPoint = new List<Transform>();
    public Transform finish;
    public float geriTepmeKatSayisi;
    public float playerSpeed;
    public float jumpPower;
}
