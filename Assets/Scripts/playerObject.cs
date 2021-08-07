using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerObject/PlayerValues", fileName = "New PLayer Values")]
public class playerObject : ScriptableObject
{
    public Vector3[] _points;
    public float _geriTepmeKatSayisi;
    public float _playerSpeed;
    public float _jumpPower;
    public GameObject _agent;
}
