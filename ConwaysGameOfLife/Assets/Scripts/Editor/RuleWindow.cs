using UnityEngine;
using UnityEditor;

public class RuleWindow : EditorWindow {

    #region Variables

    public float tickTime = 0.1f;

    public int minNeighbors = 2;
    public int maxNeighbors = 5;
    public int amountToSpawn = 3;

    #endregion

    [MenuItem("Window/Rules")]
    static void Init()
    {
        RuleWindow window = (RuleWindow)EditorWindow.GetWindow(typeof(RuleWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Game Rules", EditorStyles.boldLabel);

        tickTime = EditorGUILayout.Slider("Time between ticks:", tickTime, 0.01f, 1f);

        EditorGUILayout.LabelField("Minimum amount of neighbors to survive.");
        minNeighbors = EditorGUILayout.IntField(minNeighbors);

        EditorGUILayout.LabelField("Maximum amount of neighbors to survive.");
        maxNeighbors = EditorGUILayout.IntField(maxNeighbors);

        EditorGUILayout.LabelField("Amount of neighbors to spawn.");
        amountToSpawn = EditorGUILayout.IntField(amountToSpawn);
    }
}
