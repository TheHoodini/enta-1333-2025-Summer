using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridSettings _gridSettings;
    public GridSettings GridSettings => _gridSettings;

    private GridNode[,] _gridNodes;

#if UNITY_EDITOR
    [Header("Debug for editor playmode only")]
    [SerializeField] private List<GridNode> AllNodes = new();
#endif

    public bool IsInitialized { get; private set; } = false;

    public void InitializeGrid()
    {
        _gridNodes = new GridNode[_gridSettings.GridSizeX, _gridSettings.GridSizeY];

        for(int x = 0, x < _gridSettings.GridSizeX; x++)
        {
            for (int y = 0, y < _gridSettings.GridSizeY; y++)
            {

            }
        }
    }


}
