using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DataManage : MonoBehaviour
{
    public Text testText;
    public Button button;
    public Dropdown dropDown;
    public InputField inputText;
    private List<string> dropList;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(bianhua);
        dropDown.ClearOptions();
        dropList = new List<string>();
        dropList.Add("1");
        dropList.Add("8");
        dropList.Add("9");
        dropList.Add("X");
        dropDown.AddOptions(dropList);//添加选择列表
        dropDown.Show();
        dropDown.Hide();
        dropDown.captionText.text = "下拉菜单";
        dropDown.onValueChanged.RemoveAllListeners();
        dropDown.onValueChanged.AddListener(ClickDropdown);
        //dropDown.options.Remove(dropDown.options[2]);
        
    }

    // Update is called once per frame
    void Update()
    {
        testText.text = dropDown.options[dropDown.value].text;//当前选定的
    }
    int a = 1;
    void bianhua()
    {
        //print(dropDown.captionText.text);
        //print(dropDown.value);
        dropDown.value = a;
        a += 1;
        print(a);
        //dropDown.ClearOptions();
    }
    private void ClickDropdown(int index)
    {
        Debug.Log(index);
    }

}
