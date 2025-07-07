using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InputReader : MonoBehaviour
{
    private int _mouseButtonHit = 0;
    private float _maxDistanceRay = 100;

    private Camera _camera;

    public event Action<RaycastHit> HitReceived;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonHit))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistanceRay))
            {
                HitReceived?.Invoke(hit);
            }
        }
    }
}

