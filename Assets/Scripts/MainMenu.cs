using UnityEngine;
using UnityEditor;

public class Create2DMaterialFix
{
    // Ця функція додає нову опцію у меню Assets/Create
    [MenuItem("Assets/Create/Physics Material 2D (FIXED)")]
    public static void CreatePhysicsMaterial2DFix()
    {
        // Створюємо новий екземпляр PhysicsMaterial2D
        PhysicsMaterial2D newMat = new PhysicsMaterial2D();

        // Створюємо .physicMaterial2D файл в папці Assets
        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/New Physics Material 2D.physicMaterial2D");
        AssetDatabase.CreateAsset(newMat, path);
        AssetDatabase.SaveAssets();

        // Виділяємо новий асет у вікні Project
        Selection.activeObject = newMat;
    }
}