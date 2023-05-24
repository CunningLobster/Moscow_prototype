using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public abstract class InteractableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected NavMeshAgent _player;
    protected Raycaster _raycaster;
    protected bool _isPointed;
    protected bool _isActivated;

    [SerializeField] private float _distance = 1f;
    [SerializeField] private InputAction MouseClickAction;

    [SerializeField] private Texture2D _pointCursor;
    [SerializeField] private Vector2 _hotspot;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(_pointCursor, _hotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnEnable()
    {
        MouseClickAction.Enable();
        MouseClickAction.performed += Interact;
    }

    public void OnDisable()
    {
        MouseClickAction.performed += Interact;
        MouseClickAction.Enable();
    }

    public void Start()
    {
        _raycaster = FindObjectOfType<Raycaster>();
        _player = FindObjectOfType<PlayerMover>().GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (_raycaster.Hit.transform == null) return;
        _isPointed = _raycaster.Hit.transform != null && _raycaster.Hit.transform.Equals(transform);

        if (_isPointed)
            Debug.Log(gameObject.name);
    }

    public abstract void Interact(InputAction.CallbackContext context);

    protected async Task ComeAlong()
    {
        _player.stoppingDistance = _distance;
        _player.destination = _raycaster.Hit.point;

        while (Vector3.Distance(_player.transform.position, _player.destination) >= _distance)
            await Task.Yield();
    }
}
