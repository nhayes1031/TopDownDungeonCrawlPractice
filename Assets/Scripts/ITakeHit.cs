using UnityEngine;

public interface ITakeHit
{
    void TakeHit(IAttack hitBy);
}

public interface IAttack
{
    int Damage { get; }
    Transform transform { get; }
}