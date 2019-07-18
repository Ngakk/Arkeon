using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    AttackBase currAttack;
    public List<AttackBase> allAttacks;
    int AttacksIndex;

    #region public variables
    public Text Number;
    public InputField Name;
    public InputField Description;
    public InputField Power;
    public InputField Cost;
    public InputField Accuracy;
    public InputField Type;
    public Toggle IsPhysical;
    public InputField InvocationCode;
    public InputField EffectId;
    #endregion

    

    // Start is called before the first frame update
    void Start()
    {
        allAttacks = DBAccess.LoadAttacks();
        
        if (allAttacks == null)
        {
            Debug.LogError("All attacks is null");
            return;
        }

        if (allAttacks.Count < 1) return;

        AttacksIndex = 0;
        currAttack = allAttacks[AttacksIndex];

        SetOnScreen(currAttack);
    }

    void SetOnScreen(AttackBase a)
    {
        Number.text = a.id.ToString();
        Name.text = a.name;
        Type.text = a.type.ToString();
        Description.text = a.descrciption;
        Power.text = a.power.ToString();
        Cost.text = a.cost.ToString();
        Accuracy.text = a.accuracy.ToString();
        IsPhysical.isOn = a.isphysical;
        InvocationCode.text = a.invocationcode;
        EffectId.text = a.effectid.ToString();
    }

    public void NextPoke()
    {
        if (AttacksIndex < allAttacks.Count - 1)
        {
            currAttack = allAttacks[++AttacksIndex];
            SetOnScreen(currAttack);
        }
    }

    AttackBase ScreenToObj(int newNumber = -1)
    {
        AttackBase p = new AttackBase
        {
            id = newNumber > 0 ? newNumber : currAttack.id,
            name = Name.text,
            type = int.Parse(Type.text),
            descrciption = Description.text,
            power = int.Parse(Power.text),
            cost = int.Parse(Cost.text),
            accuracy = int.Parse(Accuracy.text),
            isphysical = IsPhysical.isOn,
            invocationcode = InvocationCode.text,
            effectid = int.Parse(EffectId.text)
        };

        return p;
    }

    public void UpdateCurrentPoke()
    {
        currAttack = ScreenToObj();
        allAttacks[AttacksIndex] = currAttack;
        DBAccess.UpdateAllAttacks(allAttacks);
    }

    public void SaveNewPoke()
    {
        AttacksIndex = allAttacks.Count + 1;
        AttackBase newMonster = ScreenToObj(AttacksIndex);
        Number.text = "Number: " + DBAccess.AddNewAttack(newMonster);
        allAttacks.Add(newMonster);
    }

    public void PrevPoke()
    {
        if (AttacksIndex > 0)
        {
            currAttack = allAttacks[--AttacksIndex];
            SetOnScreen(currAttack);
        }
    }
}
