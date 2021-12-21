using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadandRetrieve : MonoBehaviour
{
    public InputField animField;
    public Animator anim;
    public void SaveData()
    {
        DataStorage data = new DataStorage();
        data.animName = animField.text;
        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath+"/Appdata.json",json);
        OnSelect();
    }

    public void LoadData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Appdata.json");
        DataStorage data = JsonUtility.FromJson<DataStorage>(json);
        animField.text = data.animName;
        OnSelect();
    }

    private void OnSelect()
    {
        string name = animField.text;
        anim.SetTrigger(name);
    }
}
