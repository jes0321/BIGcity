using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private MapInfoSO _mapInfoSO;
    [SerializeField] private Tilemap _floorTilemap,_colliderTilemap;
    void Start()
    {
        _mapInfoSO.Initialize(_floorTilemap, _colliderTilemap);
    }
}
