using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Spawner _spawner;

    private int _minCountFragments = 2;
    private int _maxCountFragments = 6;

    private void OnEnable()
    {
        _inputReader.HitReceived += TryDivide;
    }

    private void OnDisable()
    {
        _inputReader.HitReceived -= TryDivide;
    }

    private void TryDivide(RaycastHit hit)
    {
        int minPercent = 0;
        int maxPercent = 100;

        if (hit.collider.TryGetComponent(out Cube cube))
        {
            cube.Explode();

            if (Random.Range(minPercent, maxPercent + 1) <= cube.SplitChance)
            {
                List<Cube> fragments = Divide(cube);
                _exploder.Explode(fragments, cube);
            }
            else
            {
                _exploder.AddForceEnvieronmentCubes(cube);
            }
        }
    }

    private List<Cube> Divide(Cube cube)
    {
        List<Cube> fragments = new List<Cube>();
        int randomCount = Random.Range(_minCountFragments, _maxCountFragments + 1);

        for (int i = 0; i < randomCount; i++)
        {
            fragments.Add(_spawner.CreateFragment(cube));
        }

        return fragments;
    }
}

