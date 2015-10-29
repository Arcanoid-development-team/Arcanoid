using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameObjectDebugger
    {
        private readonly MonoBehaviour _gameObject;
        private FieldInfo[] _fields;
        private PropertyInfo[] _properties;
        public GameObjectDebugger(MonoBehaviour gameObject)
        {
            _gameObject = gameObject;

            _fields = GetFields();
            _properties = GetProperties();
        }

        public void UpdateDebugInfo(string message = null)
        {
#if DEBUG
            var fields = string.Join(" ", _fields.Select(x => GetFieldOrPropertyValue(x.Name, BindingFlags.GetField)).ToArray());
            var properties = string.Join(" ", _properties.Select(x => GetFieldOrPropertyValue(x.Name, BindingFlags.GetProperty)).ToArray());

            var logMessage = string.IsNullOrEmpty(message)
                ? string.Format("{0}. {1} {2}", _gameObject.transform.name, fields, properties)
                : string.Format("{0}: {1}. {2} {3}", _gameObject.transform.name, message, fields, properties);

            Debug.Log(logMessage);
#endif
        }

        private string GetFieldOrPropertyValue(string name, BindingFlags bindingFlags)
        {
            var value = _gameObject.GetType().InvokeMember(name, bindingFlags, null, _gameObject, null).ToString();
            return string.Format("{0}: {1}", name, value);
        }
        
        private FieldInfo[] GetFields()
        {
            var gameObjectFields = _gameObject.GetType().GetFields();
            var baseFields = typeof(MonoBehaviour).GetFields();

            return gameObjectFields.Where(x => baseFields.All(p => p.Name != x.Name)).ToArray();
        }

        private PropertyInfo[] GetProperties()
        {
            var gameObjecttProperties = _gameObject.GetType().GetProperties();
            var basetProperties = typeof(MonoBehaviour).GetProperties();

            return gameObjecttProperties.Where(x => basetProperties.All(p => p.Name != x.Name)).ToArray();
        }
    }
}
