using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public int NumberOfAttacks { get; private set; }

    [field: SerializeReference] public List<ComponentData> componentData { get; private set; }

    public T GetData<T>()
    {
        return componentData.OfType<T>().FirstOrDefault();
    }

    [ContextMenu("Add Sprite Data")]
    public void AddSpriteData() => componentData.Add(new WeaponSpriteData());

    [ContextMenu("Add Movement Data")]
    public void AddMovementData() => componentData.Add(new MovementData());
}