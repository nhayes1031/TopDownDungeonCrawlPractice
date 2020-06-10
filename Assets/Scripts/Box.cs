using UnityEngine;

public class Box : MonoBehaviour, ITakeHit
{
    [SerializeField] private float forceAmount = 10f;

    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeHit(IAttack hitBy)
    {
        var direction = Vector3.Normalize(transform.position - hitBy.transform.position);

        rigidbody.AddForce(direction * forceAmount, ForceMode.Impulse);
    }
}
