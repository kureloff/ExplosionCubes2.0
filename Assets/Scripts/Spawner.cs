using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float StartSplitChance = 100;

    [SerializeField] private Cube _cubePrefab;

    private int _divisionScale = 2;
    private int _divisionSplitChance = 2;

    private void Start()
    {
        CreateCube(new Vector3(2, 0, 0));
        CreateCube(new Vector3(0, 0, 0));
        CreateCube(new Vector3(-2, 0, 0));
    }

    public Cube CreateFragment(Cube cube)
    {
        Cube cubeFragment = InstantiateCube(cube);

        Color color = ColorChanger.GetRandomColor();
        Vector3 scale = cube.LocalScale / _divisionScale;
        float splitChance = cube.SplitChance / _divisionSplitChance;

        cubeFragment.Initialize(color, scale, splitChance);

        return cubeFragment;
    }

    private void CreateCube(Vector3 position)
    {
        Cube cube = InstantiateCube(_cubePrefab);
        cube.transform.position = position;

        Color color = ColorChanger.GetRandomColor();
        cube.Initialize(color, cube.transform.localScale, StartSplitChance);
    }

    private Cube InstantiateCube(Cube sampleCube)
    {
        Cube newCube = Instantiate(sampleCube);
        newCube.Exploded += DestroyCube;

        return newCube;
    }

    private void DestroyCube(Cube cube)
    {
        cube.Exploded -= DestroyCube;
        Destroy(cube.gameObject);
    }
}