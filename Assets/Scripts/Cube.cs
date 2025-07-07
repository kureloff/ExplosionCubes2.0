using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Transform _transform;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private float _splitChance;

    public event Action<Cube> Exploded;

    public Vector3 LocalScale => _transform.localScale;
    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Color color, Vector3 scale, float splitChance)
    {
        _renderer.material.color = color;
        _transform.localScale = scale;
        _splitChance = splitChance;
    }

    public void Explode()
    {
        Exploded?.Invoke(this);
    }
}