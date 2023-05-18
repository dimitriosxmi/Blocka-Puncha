using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityTypes
{
    none = 0,
    melee = 1,
    rangedProjectile = 2,
    rangedHitscan,
    rangedAoE = 3
}

public enum CastableShape
{
    none = 0,
    square = 1,
    circle = 2,
    //multiple = 3, 
}

[CreateAssetMenu(fileName = "New Ability", menuName = "Units/Create Ability")]
public class AbilitySO : ScriptableObject
{
    [Header("Timers")]
    [Range(0f, 120f)]
    [SerializeField] private float abilityCastTime = 0f;
    public float AbilityCastTime { get => abilityCastTime; set => abilityCastTime = value; }
    public float AbilityRecoveryTime { get => abilityRecoveryTime; set => abilityRecoveryTime = value; }
    [Range(0f, 120f)]
    [SerializeField] private float abilityRecoveryTime = 0f;
    public float AbilityCooldownTime { get => abilityCooldownTime; set => abilityCooldownTime = value; }
    [Range(0f, 120f)]
    [SerializeField] private float abilityCooldownTime = 0f;

    [Header("Main")]
    [SerializeField] private bool abilityPassThrough = false;
    /// <summary>
    /// Whether the ability hits only the first unit or passes through multiple
    /// </summary>
    public bool AbilityPassThrough { get => abilityPassThrough; set => abilityPassThrough = value; }

    public ElementTypes AbilityElement { get => abilityElement; set => abilityElement = value; }
    [SerializeField] private ElementTypes abilityElement = ElementTypes.none;

    public AbilityTypes AbilityForm { get => abilityForm; set => abilityForm = value; }
    [SerializeField] private AbilityTypes abilityForm = AbilityTypes.none;

    [Header("Melee")]
    [Header("Ranged Hitscan")]
    [Range(0f, 200f)]
    [SerializeField] private float damage = 0;
    public float Damage { get => damage; set => damage = value; }

    [Header("Melee")]
    [Header("Ranged Projectile")]
    [Header("-- Shape")]
    [SerializeField] private CastableShape abilityCastShape = CastableShape.none;
    public CastableShape AbilityCastShape { get => abilityCastShape; set => abilityCastShape = value; }

    [Header("Melee")]
    [Header("Ranged Projectile")]
    [Header("-- Shape Square")]
    [SerializeField] private Vector2 squareSize = new Vector2(0f, 0f);
    public Vector2 SquareSize { get => squareSize; set => squareSize = value; }
    public float SquareZRotation { get => squareZRotation; set => squareZRotation = value; }
    [Range(0f, 360f)]
    [SerializeField] private float squareZRotation = 0f;

    [Header("Melee")]
    [Header("Ranged Projectile")]
    [Header("-- Shape Circle")]
    [Range(0.01f, 20f)]
    [SerializeField] private float radius = 1f;
    public float Radius { get => radius; set => radius = value; }
    public float Arc { get => arc; set => arc = value; }
    [Range(0f, 360f)]
    [SerializeField] private float arc = 360f;
    public float CircleZRotation { get => circleZRotation; set => circleZRotation = value; }
    [Range(0f, 360f)]
    [SerializeField] private float circleZRotation = 0f;

    [Header("Ranged Projectile")]
    [SerializeField] private bool randomMode = false;
    [Range(0f, 100f)]
    [SerializeField] private float abilityTravelSpeed = 0f;
    public float AbilityTravelSpeed { get => abilityTravelSpeed; set => abilityTravelSpeed = value; }

    [Header("Ranged Projectile")]
    [Header("Ranged Hitscan")]
    [Header("Ranged AoE")]
    [Range(0f, 50f)]
    [SerializeField] private float abilityReachMaxDistance = 0f;
    public float AbilityReachMaxDistance { get => abilityReachMaxDistance; set => abilityReachMaxDistance = value; }

    [Header("Ranged Projectile")]
    [Header("Ranged AoE")]
    [SerializeField] private List<ProjectileSO> projectile = new List<ProjectileSO>();
    public List<ProjectileSO> Projectile { get => projectile; set => projectile = value; }


    [Header("Melee")]
    [Header("Ranged Hitscan")]
    [Header("-- Effects")]
    [SerializeField] private List<EffectSO> appliesEffects = new List<EffectSO>();
    public List<EffectSO> AppliesEffects { get => appliesEffects; set => appliesEffects = value; }

    [Header("Melee")]
    [Header("Ranged Projectile")]
    [Header("Ranged Hitscan")]
    [Header("Ranged AoE")]
    [Range(0f, 15f)]
    [SerializeField] private float abilityCastFromMinDistance = 0f;
    public float AbilityCastFromMinDistance { get => abilityCastFromMinDistance; set => abilityCastFromMinDistance = value; }
}
