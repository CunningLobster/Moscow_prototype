using System.Collections;
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
    protected bool _isObserved;

    private InputAction MouseClickAction = new InputAction();

    [SerializeField] protected float _distance = 1f;
    [SerializeField] protected Transform _interactionPoint;
    [SerializeField] protected Texture2D _pointCursor;
    [SerializeField] protected Vector2 _hotspot;

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
        MouseClickAction.AddBinding("<Mouse>/leftButton", "tap");
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

    public void Interact(InputAction.CallbackContext context)
    {
        if (_isPointed)
        {
            var coroutine = RunInteractionRoutine();
            try
            {
                StartCoroutine(coroutine);
            }
            catch
            {
                return;
            }
        }
    }

    protected abstract IEnumerator RunInteractionRoutine();

    protected IEnumerator ComeAlong()
    {
        _player.stoppingDistance = _distance;
        _player.destination = _raycaster.Hit.point;

        while (Vector3.Distance(_player.transform.position, _player.destination) >= _distance)
            yield return null;
    }

    protected IEnumerator ComeToInteractionPoint()
    {
        _player.stoppingDistance = 0f;
        _player.destination = _interactionPoint.position;

        Vector2 interactionPointV2 = new Vector2(_interactionPoint.position.x, _interactionPoint.position.z);

        while (Vector2.Distance(new Vector2(_player.transform.position.x, _player.transform.position.z), interactionPointV2) >= .3f)
            yield return null;
    }
}
