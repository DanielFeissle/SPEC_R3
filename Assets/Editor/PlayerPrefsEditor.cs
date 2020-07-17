using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlayerPrefsEditor : EditorWindow
{
    //script from:
    //https://forum.unity.com/threads/editor-utility-player-prefs-editor-edit-player-prefs-inside-the-unity-editor.370292/
    [MenuItem("Edit/Player Prefs")]
    public static void openWindow()
    {

        PlayerPrefsEditor window = (PlayerPrefsEditor)EditorWindow.GetWindow(typeof(PlayerPrefsEditor));
        window.titleContent = new GUIContent("Player Prefs");
        window.Show();

    }

    public enum FieldType { String, Integer, Float }

    private FieldType fieldType = FieldType.String;
    private string setKey = "";
    private string setVal = "";
    private string error = null;

    void OnGUI()
    {

        EditorGUILayout.LabelField("Player Prefs Editor", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("by RomejanicDev");
        EditorGUILayout.Separator();

        fieldType = (FieldType)EditorGUILayout.EnumPopup("Key Type", fieldType);
        setKey = EditorGUILayout.TextField("Key to Set", setKey);
        setVal = EditorGUILayout.TextField("Value to Set", setVal);

        if (error != null)
        {

            EditorGUILayout.HelpBox(error, MessageType.Error);

        }

        if (GUILayout.Button("Set Key"))
        {

            if (fieldType == FieldType.Integer)
            {

                int result;
                if (!int.TryParse(setVal, out result))
                {

                    error = "Invalid input \"" + setVal + "\"";
                    return;

                }

                PlayerPrefs.SetInt(setKey, result);

            }
            else if (fieldType == FieldType.Float)
            {

                float result;
                if (!float.TryParse(setVal, out result))
                {

                    error = "Invalid input \"" + setVal + "\"";
                    return;

                }

                PlayerPrefs.SetFloat(setKey, result);

            }
            else
            {

                PlayerPrefs.SetString(setKey, setVal);

            }

            PlayerPrefs.Save();
            error = null;

        }

        if (GUILayout.Button("Get Key"))
        {
            error = null;
            setVal = "-";
            int i;
            float f;
            string s;

            if (PlayerPrefs.HasKey(setKey))
            {
                i = PlayerPrefs.GetInt(setKey, int.MinValue);
                if (i == int.MinValue)
                {
                    f = PlayerPrefs.GetFloat(setKey, float.NaN);
                    if (float.IsNaN(f))
                    {
                        s = PlayerPrefs.GetString(setKey, string.Empty);
                        if (string.IsNullOrEmpty(s))
                        {
                            error = "Unknown type: " + setKey;
                        }
                        else
                        {
                            setVal = s.ToString();
                            fieldType = FieldType.String;
                        }
                    }
                    else
                    {
                        setVal = f.ToString();
                        fieldType = FieldType.Float;
                    }
                }
                else
                {
                    setVal = i.ToString();
                    fieldType = FieldType.Integer;
                }
            }
            else
            {
                error = "No matching Key " + setKey;
            }
        }

        if (GUILayout.Button("Delete Key"))
        {

            PlayerPrefs.DeleteKey(setKey);
            PlayerPrefs.Save();

        }

        if (GUILayout.Button("Delete All Keys"))
        {

            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

        }

    }

}
