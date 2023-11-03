using UnityEngine;
using UnityEngine.AI;

public class MobStateMachine : StateMachine
{
    [SerializeField] private float _fov;

    private int _walkingParameterHash = Animator.StringToHash("Walking");

    private int _runningParameterHash = Animator.StringToHash("Running");

    private int _attackingParameterHash = Animator.StringToHash("Attacking");

    private Animator _animator;

    public Animator Animator => _animator;

    private NavMeshAgent _navMeshAgent;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private Transform _target;

    public Transform Target { get => _target; set => _target = value; }

    public bool IsWalking { get; set; }

    public bool isRunning { get; set; }

    public bool isAttacking { get; set; }

    public override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Update()
    {
        base.Update();

        if (_animator is null) return;

        _animator.SetBool(_walkingParameterHash, IsWalking);
        _animator.SetBool(_runningParameterHash, isRunning);
        _animator.SetBool(_attackingParameterHash, isAttacking);
    }
}
