using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// 맵의 정보를 담아두는 SO
/// </summary>
[CreateAssetMenu(menuName = "SO/Map/MapInfo")]
public class MapInfoSO : ScriptableObject
{
    private Tilemap _floorTilemap,_buildingTilemap,_treeTilemap;//플로어 타일맵, 콜라이더 타일맵
    private Grid _grid;
    public void Initialize(Grid grid,Tilemap floorTilemap, Tilemap buildingTilemap,Tilemap treeTilemap)
    {
        _grid = grid;
        _floorTilemap = floorTilemap;
        _buildingTilemap = buildingTilemap;
        _treeTilemap = treeTilemap;
    }
    
    public Vector3Int GetTilePosFromWorld(Vector3 from) => _floorTilemap.WorldToCell(from); //월드 좌표로 바닥 타일맵의 좌표를 반환
    public Vector3 GetCellCenterToWorld(Vector3Int cellCenter) => _floorTilemap.GetCellCenterWorld(cellCenter); //타일맵의 중심의 좌표를 월드좌표로 변환

    public Vector3 GetTileCenterToWorldPos(Vector3 position)
    {
        Vector3Int intPos = _grid.WorldToCell(position);
        Vector3 pos = _grid.GetCellCenterWorld(intPos);
        return pos;
    }
}
