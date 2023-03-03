using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    public Vector3 StartPadSize { get; private set; }

    public Pause _Pause;

    private void Update()
    {
        if (_Pause.IsPaused)
            return;


        MoveWithMouse();
    }

    private void MoveWithMouse()
    {
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        Vector3 currentPosition = transform.position;
        currentPosition.x = mousePositionInUnits.x;
        transform.position = currentPosition;
    }
}