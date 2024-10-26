using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{   
    readonly float _movementSpeed;
    readonly Transform _playerTransform;

    public PlayerMovement (float movementSpeed, Transform transform)
    {
        this._movementSpeed = movementSpeed;
        this._playerTransform = transform;
    }

    public void Move(Vector3 direction)
    {
        _playerTransform.Translate(direction * _movementSpeed * Time.deltaTime);
    }
}
