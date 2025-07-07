using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _startExplosionForce = 100;
    private float _startExplosionRadius = 10;

    public void Explode(List<Cube> cubes, Cube explodedCube)
    {
        Vector3 explodePosition = explodedCube.transform.position;

        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_startExplosionForce, explodePosition, _startExplosionRadius);
        }
    }

    public void AddForceEnvieronmentCubes(Cube explodedCube)
    {
        Vector3 explodePosition = explodedCube.transform.position;
        List<Cube> cubes = GetEnvieronmentCubes(explodePosition);

        foreach (Cube cube in cubes)
        {
            float explosionForce = _startExplosionForce / cube.LocalScale.x;
            float explosionRadius = _startExplosionRadius / cube.LocalScale.x;

            cube.Rigidbody.AddExplosionForce(explosionForce, explodePosition, explosionRadius);
        }
    }

    private List<Cube> GetEnvieronmentCubes(Vector3 explodePosition)
    {
        Collider[] colliders = Physics.OverlapSphere(explodePosition, _startExplosionRadius);

        List<Cube> cubes = new List<Cube>();

        foreach (Collider collider in colliders)
            if (collider.TryGetComponent(out Cube cube))
                cubes.Add(cube);

        return cubes;
    }
}