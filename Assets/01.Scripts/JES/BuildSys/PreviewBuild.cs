using System;
using Unity.VisualScripting;
using UnityEngine;

public class PreviewBuild : MonoBehaviour
{
    private Vector3 _offset;

    [SerializeField] private InputMouseClick _input;
    [SerializeField] private MapInfoSO _mapInfo;
    private void OnMouseDown()
    {
        _offset = transform.position - _input.MousePosition;
    }
    private void OnMouseDrag()
    {
        Vector3 pos = _input.MousePosition+_offset;
        transform.position = _mapInfo.GetTileCenterToWorldPos(pos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}