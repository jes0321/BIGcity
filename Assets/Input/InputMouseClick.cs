using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controlls;

[CreateAssetMenu(fileName = "InputMouseClick", menuName = "SO/Input")]
public class InputMouseClick : ScriptableObject,IMouseClickActions
{
    public event Action<Vector3> OnMouseClickEvent;//마우스가 클릭되었을때 월드좌표를 보내줄 이벤트
    
    public Vector3 MousePosition => MousePositionCal(_mouseScreenPos);
    private Vector3 _mouseScreenPos;

    private Controlls _controlls; //인풋 컨트롤
    private void OnEnable()
    {
        _controlls = new Controlls(); // 생성 및 초기화
        _controlls.MouseClick.SetCallbacks(this); // 이 스크립트를 콜백으로 설정
        _controlls.MouseClick.Enable(); // 켜주고
    }
    
    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed) // 눌렸을 때 
        {
            Vector3 pos =  MousePositionCal(Mouse.current.position.ReadValue());
            OnMouseClickEvent?.Invoke(pos);
        }
    }
    public void OnMousePos(InputAction.CallbackContext context)
    {
        _mouseScreenPos = context.ReadValue<Vector2>();
    }
    private Vector3 MousePositionCal(Vector3 mouseScreenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos); // 마우스 좌표를 기준으로 레이를 만든다
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
            return hit.point;
        }
        Debug.Log("밍");
        return Vector3.zero;
    }
}
