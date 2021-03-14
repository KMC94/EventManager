using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 더 많은 이벤트가 리스트에 추가된다
public enum EVENT_TYPE
{
    GAME_INIT,
    GAME_END,
    AMMO_CHANGE,
    HEALTH_CHANGE,
    DEAD,
};

// 리스너 클래스에서 구현될 리스너 인터페이스
public interface IListener
{
    // 이벤트가 발생할 때 리스너에서 호출할 함수
    void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);
}
