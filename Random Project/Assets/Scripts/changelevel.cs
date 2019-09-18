using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changelevel : MonoBehaviour {

	public void ChangeLevel(string SceneToChangeTo)
	{
		SceneManager.LoadScene (SceneToChangeTo);
	}
}
