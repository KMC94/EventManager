using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCustomListener : MonoBehaviour, IListener
{
    int _health = 100;
    public int Health
    {
        get { return _health; }
        set
        {
            // 체력 값을 0-100 사이에 맞춘다
            _health = Mathf.Clamp(value, 0, 100);

            // 알림을 보낸다 - 체력 값이 변경 되었음
            EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, this, _health);
        }
    }

    void Start()
    {
        // 체력 변동 이벤트를 수신하기 위해 스스로를 리스너로 등록한다
        EventManager.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Take some damage of space bar  press
            Health -= 5;
        }
    }

    // 이벤트 수신을 위해 OnEvent 함수를 구현한다
    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        // 이벤트 종류를 알아낸다
        switch(Event_Type)
        {
            case EVENT_TYPE.HEALTH_CHANGE:
                OnHealthChange(Sender, (int)Param);
            break;
        }
    }

    void OnHealthChange(Component Enemy, int NewHealth)
    {
        //If health has changed of this object
        if (this.GetInstanceID() != Enemy.GetInstanceID()) return;

        Debug.Log("Object: " + gameObject.name + " Health is: " + NewHealth.ToString());
    }
}
