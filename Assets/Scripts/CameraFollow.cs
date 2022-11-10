using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _player;
	public float _smoothing = 5f;
	Vector3 _offset;

	// Use this for initialization
	void Start () {
		_offset = transform.position - _player.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 _playerCamPos = _player.position + _offset;
		transform.position = Vector3.Lerp (transform.position, _playerCamPos, _smoothing * Time.deltaTime);
	}
}
