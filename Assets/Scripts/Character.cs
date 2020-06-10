using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Character : MonoBehaviour, IAttack, ITakeHit
{
    public static List<Character> All = new List<Character>();

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int damage = 3;
    [SerializeField] private int maxHealth = 5;

    public int Damage { get { return damage; } }

    private Controller controller;
    private Attacker attacker;
    private Animator animator;
    private int currentHealth;

    private void Awake()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponentInChildren<Animator>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        Vector3 direction = controller.GetDirection();
        if (direction.magnitude > 0.1f)
        {
            transform.position += direction * Time.deltaTime * moveSpeed;
            transform.forward = direction * 360f;

            animator.SetFloat("Speed", direction.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (controller.attackPressed)
        {
            if (attacker.CanAttack)
            {
                 animator.SetTrigger("Attack");
            }
        }
    }

    public void SetController(Controller controller)
    {
        this.controller = controller;
    }

    private void OnEnable()
    {
        if (All.Contains(this) == false)
            All.Add(this);
    }

    private void OnDisable()
    {
        if (All.Contains(this))
            All.Remove(this);
    }

    public void TakeHit(IAttack hitBy)
    {
        currentHealth -= hitBy.Damage;
    }
}
