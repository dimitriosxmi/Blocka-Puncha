using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Units/Create Effect")]
public class EffectSO : ScriptableObject
{
    public float Damage { get => damage; set => damage = value; }
    [Range(0f, 50f)]
    [SerializeField] private float damage = 0f;

    [Header("Timers")]
    [Range(0f, 120f)]
    [SerializeField] private float EffectDurationTime = 0f;
    public float EffectileDurationTime { get => EffectDurationTime; set => EffectDurationTime = value; }
    public float DamageIntervalTime { get => damageIntervalTime; set => damageIntervalTime = value; }
    [Range(0f, 120f)]
    [SerializeField] private float damageIntervalTime = 0f;

    [Header("Infect")]
    [SerializeField] private bool infectsNearby = false;
    public bool InfectsNearby { get => infectsNearby; set => infectsNearby = value; }
    public float InfectionReachRadius { get => infectionReachRadius; set => infectionReachRadius = value; }
    [Range(0.01f, 20f)]
    [SerializeField] private float infectionReachRadius = 0f;

    [Header("Effects")]
    [SerializeField] private List<EffectSO> effectsDuringDuration = new List<EffectSO>();
    public List<EffectSO> EffectsDuringDuration { get => effectsDuringDuration; set => effectsDuringDuration = value; }
    public List<EffectSO> EffectsAfterDuration { get => effectsAfterDuration; set => effectsAfterDuration = value; }
    [SerializeField] private List<EffectSO> effectsAfterDuration = new List<EffectSO>();

    [Header("Miscellaneous")]
    [SerializeField] private GameObject currentTarget = null;
    public GameObject CurrentTarget { get => currentTarget; set => currentTarget = value; }
}
