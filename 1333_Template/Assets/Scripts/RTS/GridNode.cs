using UnityEngine;

[System.Serializable]
public struct GridNode 
{
    public string Name;
    public Vector3 WorldPosition;
    public TerrainType TerrainType;
    public bool Walkable => TerrainType != null ? TerrainType.Walkable : false;
    public int Weight => TerrainType != null ? TerrainType.MovementCost : 1;

    public Color GizmoColor => TerrainType != null ? TerrainType.Color : Color.grey;
}
