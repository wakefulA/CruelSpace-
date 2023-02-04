using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    //  [SerializeField] private Vector3 _minSize;

    //  [SerializeField] private Vector3 _maxSize;

    public Vector3 StartPadSize { get; private set; }

    public Pause _Pause;

    private void Start()
    {
    }

    private void Update()
    {
        if (_Pause.IsPaused)
            return;


        MoveWithMouse();


        //if (_Pause.IsPaused)
        return;
        //if (GameManager.Instance.LifeGame == 0)
        //  return;


        ////  if (GameManager.Instance.NeedAutoPlay)
        // {
        //     MoveWithBall();
        // }

        // else
        // {
        //    MoveWithMouse();
        // }
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