using UnityEngine;
using UnityEditor;
using System.Collections;

/* Changes the font settings of each UILabel in hierarchy
 * 
 * Created By: Jon Wahlström 2014-05-21
 * Modified By:
 */

public class FontChanger : EditorWindow 
{
	[MenuItem("LOL/Font changer")]
	private static void showEditor ()
	{
		EditorWindow window = EditorWindow.GetWindow<FontChanger> (false, "Tool");
		window.minSize = new Vector2 (250, 350);
	}

	private string _info = "";
	private Font _font;
	void OnGUI()
	{
		_font = EditorGUILayout.ObjectField ("Font", _font, typeof(Font)) as Font;

		if(GUILayout.Button("Apply") && _font != null)
		{
			SetFont();
		}
		else
		{
			Debug.Log("No font attached");
		}
	}

	void SetFont()
	{
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
		{
			TraverseAndSetFont(obj.transform);
		}
	}

	void TraverseAndSetFont(Transform go)
	{
		foreach (Transform obj in go.transform)
		{
			if(obj.GetComponent<UILabel>())
			{
				UILabel label = obj.GetComponent<UILabel>();
				label.ambigiousFont = _font;
			}
			TraverseAndSetFont(obj);
		}
	}
}
