using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private MapInfoSO _mapInfoSO;
    [SerializeField] private Tilemap _floorTilemap;
    [SerializeField] private Tilemap _buildingTilemap,_treeTilemap;
    void Start()
    {
        _mapInfoSO.Initialize(_floorTilemap, _buildingTilemap,_treeTilemap);
    }
}
