using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleInteraction : BaseInteractable
{
    [SerializeField] protected CinemachineCamera puzzleCamera;
    public UnityEvent OnPuzzleInteract;

    protected bool isActive = false;

    public virtual void Update()
    {
        if(isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            DeActivePuzzle();
        }
    }

    public override void OnInteract()
    {
        if (isActive) return;

        base.OnInteract();
        ActivePuzzle();
    }

    public virtual void ActivePuzzle()
    {
        isActive = true;
        CameraManager.Instance.SwitchCamera(puzzleCamera);
        OnPuzzleInteract.Invoke();
        OnPlayerExit();
    }

    public virtual void DeActivePuzzle()
    {
        isActive = false;
        InteractorCanvas.Instance.CloseCanvas();
        CameraManager.Instance.SwitchToMain();
        OnPlayerEnter();
    }
}
