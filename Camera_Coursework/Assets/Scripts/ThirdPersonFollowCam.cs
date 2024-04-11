using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonFollowCam : MonoBehaviour
{

	// Cache a reference to the player
	private GameObject _player;

    // What's the furthest distance away from the player we can be?
    // What's the closest distance we can be to the player?
    [SerializeField] private float _maxDistance;
	[SerializeField] private float _minDistance;
    [SerializeField, Range(0.0f, 1.0f)] private float _sphereRadius;
    public LayerMask collisionLayer;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        // Vector3 _playersForward = _player.transform.forward;
        Vector3 _invertedPlayerForward = -_player.transform.forward;
        // lerp position
        transform.position = FindSafePosition(_invertedPlayerForward);
        transform.LookAt(_player.transform.position);

    }

    private Vector3 FindSafePosition(Vector3 direction)
    {
        RaycastHit hit;
        Vector3 safePosition;

        // Perform a spherecast
        if (Physics.SphereCast(_player.transform.position, _sphereRadius, direction, out hit, _maxDistance, collisionLayer))
        {
            // If the spherecast hits something, adjust the camera position
            safePosition = hit.point - direction * _sphereRadius;
            transform.position = safePosition;
        }
        else
        {
            // If no collision, position the camera at the maximum distance behind the player
            safePosition = _player.transform.position + direction * _maxDistance;
        }
        return safePosition;
    }

    //-------------- PASS
    // Every Update:
    // Where's the player?
    // Get Player's Forward vector, and invert it
    // Sphere cast behind the player, and find the safest place along the "backward vector"
    // Stick the camera there
    // Face the camera to look at the player...
    //-------------- PASS


    // ------------- GOLD STAR SUPER DUPER YAY
    // Hang on. Ramps. Uh Oh?
    // ------------- GOLD STAR SUPER DUPER YAY
}
