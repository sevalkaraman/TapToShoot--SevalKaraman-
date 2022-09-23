using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public GameObject cube;
    public Transform parent;
    public int xCount = 3;
    public int yCount = 4;
    public float size = 1;

    public List<GameObject> _cubes = new List<GameObject>();

    [ContextMenu("Place Cubes")]
    public void PlaceCubes()
    {
        DeleteCubes();
        SetCubesPositions();

        foreach (Transform child in parent)
        {
            _cubes.Add(child.gameObject);
        }

    }
    [ContextMenu("Delete Cubes")]
    public void DeleteCubes()
    {
        foreach (GameObject child in _cubes)
        {
            DestroyImmediate(child);
        }
        _cubes.Clear();
    }
    private void SetCubesPositions()
    {
        for (int i = 0; i < yCount; i++)
        {
            for (int j = 0; j < xCount; j++)
            {
                var newCube = Instantiate(cube, parent);
                newCube.transform.localScale = Vector3.one * size;
                newCube.transform.localPosition = new Vector3( j -(size / 2 * (xCount - 1)), (size / 2 * (yCount - 1)) - i , 0f);
            }
        }
    }
    
}
