using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.DictionaryInspect
{
    [CustomPropertyDrawer(typeof(DictionaryInspectAttribute))]
    public class DictionaryInspectDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty keysProperty = property.FindPropertyRelative("keys");
            SerializedProperty valuesProperty = property.FindPropertyRelative("values");

            if (keysProperty != null && keysProperty.isArray)
            {

                for (int i = 0; i < keysProperty.arraySize; i++)
                {
                    SerializedProperty keyProperty = keysProperty.GetArrayElementAtIndex(i);
                    SerializedProperty valueProperty = valuesProperty.GetArrayElementAtIndex(i);

                    EditorGUI.LabelField(new Rect(position.x, position.y, 50, EditorGUIUtility.singleLineHeight), "Key");
                    EditorGUI.PropertyField(new Rect(position.x + 55, position.y, 50, EditorGUIUtility.singleLineHeight), keyProperty, GUIContent.none);

                    EditorGUI.LabelField(new Rect(position.x + 110, position.y, 50, EditorGUIUtility.singleLineHeight), "Value");
                    EditorGUI.PropertyField(new Rect(position.x + 165, position.y, 50, EditorGUIUtility.singleLineHeight), valueProperty, GUIContent.none);
                    if (GUI.Button(new Rect(position.x + 220, position.y, 30, EditorGUIUtility.singleLineHeight), "X"))
                    {
                        keysProperty.DeleteArrayElementAtIndex(i);
                        valuesProperty.DeleteArrayElementAtIndex(i);
                    }

                    position.y += EditorGUIUtility.singleLineHeight;
                }
                
                if (GUI.Button(new Rect(position.x, position.y, EditorGUIUtility.currentViewWidth, EditorGUIUtility.singleLineHeight), "Add"))
                {
                    var index = keysProperty.arraySize;
                    keysProperty.InsertArrayElementAtIndex(index);
                    keysProperty.GetArrayElementAtIndex(index).stringValue = "";
                    valuesProperty.InsertArrayElementAtIndex(index);
                    valuesProperty.GetArrayElementAtIndex(index).stringValue = "";
                }

            }
            else
            {
                Debug.Log("Not array!");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty keysProperty = property.FindPropertyRelative("keys");
            return EditorGUIUtility.singleLineHeight * (keysProperty.arraySize + 1);
        }
    }
}
