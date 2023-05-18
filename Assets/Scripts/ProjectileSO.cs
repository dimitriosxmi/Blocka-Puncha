using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Units/Create Projectile")]
public class ProjectileSO : ScriptableObject
{
    public int Damage { get => damage; set => damage = value; }
    [SerializeField] private int damage = 0;

    public bool DamageOnImpact { get => damageOnImpact; set => damageOnImpact = value; }
    [SerializeField] private bool damageOnImpact = false;

    [Header("Timers")]
    [Range(0f, 120f)]
    [SerializeField] private float projectileCastTime = 0f;
    public float ProjectileCastTime { get => projectileCastTime; set => projectileCastTime = value; }
    // TODO: Add properties for collision checks etc. so we can work with the projectile physics
    public float ProjectileDurationTime { get => projectileDurationTime; set => projectileDurationTime = value; }
    [Range(0f, 120f)]
    [SerializeField] private float projectileDurationTime = 0f;
    public float DamageIntervalTime { get => damageIntervalTime; set => damageIntervalTime = value; }
    [Range(0f, 120f)]
    [SerializeField] private float damageIntervalTime = 0f;
    public float DestroyAfterDurationTime { get => destroyAfterDurationTime; set => destroyAfterDurationTime = value; }
    [Range(0f, 120f)]
    [SerializeField] private float destroyAfterDurationTime = 0f;

    [Header("Shape")]
    [SerializeField] private CastableShape projectileShape = CastableShape.none;
    public CastableShape ProjectileShape { get => projectileShape; set => projectileShape = value; }

    [Header("-- Shape Square")]
    [SerializeField] private Vector2 squareSize = new Vector2(0f, 0f);
    public Vector2 SquareSize { get => squareSize; set => squareSize = value; }
    public float SquareZRotation { get => squareZRotation; set => squareZRotation = value; }
    [Range(0f, 360f)]
    [SerializeField] private float squareZRotation = 0f;

    [Header("-- Shape Circle")]
    [Range(0.01f, 20f)]
    [SerializeField] private float radius = 0f;
    public float Radius { get => radius; set => radius = value; }

    [Header("Effects")]
    [SerializeField] private List<EffectSO> appliesEffects = new List<EffectSO>();
    public List<EffectSO> AppliesEffects { get => appliesEffects; set => appliesEffects = value; }

    [Header("Miscellaneous")]
    [SerializeField] private bool sticksOnTarget = false;
    public bool SticksOnTarget { get => sticksOnTarget; set => sticksOnTarget = value; }
    public GameObject Target { get => target; set => target = value; }
    [SerializeField] private GameObject target = null;
}