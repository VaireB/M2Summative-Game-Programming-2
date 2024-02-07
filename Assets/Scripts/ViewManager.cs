using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager m_instance;
    [SerializeField] private View m_startingView;
    [SerializeField] private View[] m_views;

    private View m_currentView;

    private readonly Stack<View> m_history = new Stack<View>();


    private void Awake() => m_instance = this;


    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < m_instance.m_views.Length; i++)
        {
            if (m_instance.m_views[i] is T tView)
            {
                return tView;
            }
        }
        return null;

    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < m_instance.m_views.Length; i++)
        {
            if (m_instance.m_views[i] is T)
            {
                if (m_instance.m_currentView != null)
                {
                    if (remember)
                    {
                        m_instance.m_history.Push(m_instance.m_currentView);
                    }
                    
                    m_instance.m_currentView.Hide();
                }
                m_instance.m_views[i].Show();
                m_instance.m_currentView = m_instance.m_views[i];
            }
        }

    }


    public static void Show(View view, bool remember = true)
    {
        if (m_instance.m_currentView != null)
        {
            if (remember)
            {
                m_instance.m_history.Push(m_instance.m_currentView);
            }

            m_instance.m_currentView.Hide();
        }
        view.Show();

        m_instance.m_currentView = view;
    }

    // Main -> Options
    //Main
    //POP!
    //Stack remove Main and return it
    public static void ShowLast()
    {
        if (m_instance.m_history.Count != 0)
        {
            Show(m_instance.m_history.Pop(), false);
        }
    }

    internal static void ShowLast<T>()
    {
        throw new NotImplementedException();
    }


    private void Start()
    {
      for (int i = 0; i < m_views.Length; i++)
      {
        m_views[i].Initialize();
        m_views[i].Hide();
      }   

      if (m_startingView != null)
    {
        Show(m_startingView, true);
    }
    }
  
    }

