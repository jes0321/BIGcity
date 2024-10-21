using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private MapInfoSO _mapInfoSO;
    [SerializeField] private PreviewBuild prefabs;
    public void InializeWithObject(PreviewBuild pre)
    {
        Vector3 pos = _mapInfoSO.GetTileCenterToWorldPos(Vector3.zero);
        PreviewBuild build = Instantiate(pre, pos, Quaternion.identity);
    }

    public void ClickBtn()
    {
        Instantiate(prefabs);
    }
}