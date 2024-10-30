using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public class ReferenceEventCustom
    {
        protected readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();
        protected readonly List<System.Action> _actions = new List<System.Action>();

        public virtual void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventRaised();

            for (int i = _actions.Count - 1; i >= 0; i--)
                _actions[i]();
        }
        public virtual void AddListener(IGameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }
        public virtual void RemoveListener(IGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
        public virtual void AddListener(System.Action action)
        {
            if (!_actions.Contains(action))
                _actions.Add(action);
        }
        public virtual void RemoveListener(System.Action action)
        {
            if (_actions.Contains(action))
                _actions.Remove(action);
        }
        public virtual void RemoveAll()
        {
            _listeners.RemoveRange(0, _listeners.Count);
            _actions.RemoveRange(0, _actions.Count);
        }
    }
}