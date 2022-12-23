using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    
    [SerializeField] protected Vector3 moveButtonVector3;
    public Vector3 MoveButtonVector3 { get => moveButtonVector3; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager can exist!");
        InputManager.instance = this;    
    }
    private void Update()
    {
        this.GetKeyMove();
    }
    protected virtual void GetKeyMove()
    {
        moveButtonVector3.x = Input.GetAxis("Horizontal");
        moveButtonVector3.y = Input.GetAxis("Vertical");
    }
}
