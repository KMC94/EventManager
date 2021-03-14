using System.Collections;
using UnityEngine;
using System.Collections.Generic;

// 리스너들에게 이벤트를 보내기 위한 이벤트 매니저 싱글턴
// IListener 구현과 함께 작동한다
public class EventManager : MonoBehaviour
{
    #region C# 프로퍼티
    // 인스턴스에 접근하기 위한 public 프로퍼티
    public static EventManager Instance
    {
        get { return instance; }
        set { }
    }
    #endregion

    #region 변수들
    // 이벤트 매니저 인스턴스에 대한 내부 참조 (싱글턴 디자인 패턴)
    private static EventManager instance = null;

    // 리스너 오브젝트의 배열 (모든 오브젝트가 이벤트 수신을 위해 등록되어 있다)
    private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>>();
    #endregion

    #region 메소드
    // 시작 시에 초기화를 위해 호출 된다
    private void Awake()
    {
        // 인스턴스가 없는 경우 현재 인스턴스를 할당한다
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬에서 빠져나갈 때 파괴되는 것을 방지한다.
        }
        else // 인스턴스가 이미 있다면 현재 인스턴스를 파괴한다. 싱글턴 오브젝트가 되어야 한다
            DestroyImmediate(this);

    }

    /// <summary>
    /// 리스너 배열에 지정된 리스너 오브젝트를 추가하기 위한 함수
    /// </summary>
    /// <param name="Event_Type">수신할 이벤트</param>
    /// <param name="Listener">이벤트를 수신할 오브젝트</param>
    public void AddListener(EVENT_TYPE Event_Type, IListener Listener)
    {
        // 이 이벤트를 수신할 리스너의 리스트
        List<IListener> ListenList = null;

        // 이벤트 형식 키가 존재하는지 검사한다. 존재하면 이것을 리스트에 추가한다
        if(Listeners.TryGetValue(Event_Type, out ListenList))
        {
            // 리스트가 존재하면 새 항목을 추가한다
            ListenList.Add(Listener);
            return;
        }
    }

    /// <summary>
    /// 이벤트를 리스너에게 전달하기 위한 함수
    /// </summary>
    /// <param name="Event_Type">불려질 이벤트</param>
    /// <param name="Sender">이벤트를 부르는 오브젝트</param>
    /// <param name="Param">선택 가능한 파라미터</param>
    public void PostNotification(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        // 모든 리스너에게 이벤트에 대해 알린다

        // 이 이벤트를 수신하는 리스너들의 리스트
        List<IListener> ListenList = null;

        // 이벤트 항목이 없으면, 알릴 리스너가 없으므로 끝낸다
        if (!Listeners.TryGetValue(Event_Type, out ListenList))
            return;

        // 항목이 존재한다. 이제 적합한 리스너에게 알려준다
        for(int i = 0; i < ListenList.Count; i++)
        {
            // 오브젝트가 null이 아니면 인터페이스를 통해 메시지를 보낸다
            if (!ListenList[i].Equals(null))
                ListenList[i].OnEvent(Event_Type, Sender, Param);
        }
    }

    // 이벤트 종류와 리스너 항목을 딕셔너리에서 제거한다
    public void RemoveEvent(EVENT_TYPE Event_Type)
    {
        // 딕셔너리의 항목을 제거한다
        Listeners.Remove(Event_Type);
    }

    // 딕셔너리에서 쓸모없는 항목들을 제거한다
    public void RemoveRedundancies()
    {
        // 새딕셔너리 생성
        Dictionary<EVENT_TYPE, List<IListener>> TmpListenrs = new Dictionary<EVENT_TYPE, List<IListener>>();

        // 모든 딕셔너리 항목을 순회한다
        foreach (KeyValuePair<EVENT_TYPE, List<IListener>> Item in Listeners)
        {
            // 리스트의 모든 리스너 오브젝트를 순회하며 null 오브젝트를 제거한다
            for(int i = Item.Value.Count-1; i >= 0; i--)
            {
                // null이면 항목을 지운다
                if (Item.Value[i].Equals(null))
                    Item.Value.RemoveAt(i);
            }

            // 알림을 받기 위한 항목들만 리스트에 남으면 이 항목들을 임시 딕셔너리에 담는다
            if (Item.Value.Count > 0)
                TmpListenrs.Add(Item.Key, Item.Value);
        }

        // 새로 최적화된 딕셔너리로 교체한다
        Listeners = TmpListenrs;
    }

    // 씬이 변경될 때 호출된다. 딕셔너리를 청소한다
    private void OnLevelWasLoaded(int level)
    {
        RemoveRedundancies();
    }
    #endregion
}
