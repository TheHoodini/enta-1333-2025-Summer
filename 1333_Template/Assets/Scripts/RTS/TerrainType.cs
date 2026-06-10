using UnityEngine;

[CreateAssetMenu(fileName = "TerrainType", menuName = "Game/TerrainType")]
public class TerrainType : ScriptableObject
{
    [SerializeField] private string _terrainName;
    [SerializeField] private Color _color;
    [SerializeField] private bool _walkable;
    [SerializeField] private int _movementCost;
    [SerializeField] private Texture2D _terrainTexture;

    public string TerrainName => _terrainName;
    public Color Color => _color;
    public bool Walkable => _walkable;
    public int MovementCost => _movementCost;
}
