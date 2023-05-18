using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementTypes {
    none = 0,
    rock = 1,
    steel = 2,
    superSteel = 3,
    silver = 4
}

[CreateAssetMenu(fileName = "New Unit", menuName ="Units/Create Unit")]
public class UnitSO : ScriptableObject
{
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    [Range(0f, 1000f)]
    [SerializeField] private float currentHealth = 1f;

    public float TotalHealth { get => totalHealth; set => totalHealth = value; }
    [Range(0f, 500f)]
    [SerializeField] private float totalHealth = 1f;

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    [Range(0f, 50f)]
    [SerializeField] private float movementSpeed = 0f;

    public ElementTypes ArmorElement { get => armorElement; set => armorElement = value; }
    [SerializeField] private ElementTypes armorElement = ElementTypes.none;

    public List<AbilitySO> Abilities { get => abilities; set => abilities = value; }
    [SerializeField] private List<AbilitySO> abilities = new List<AbilitySO>();
}