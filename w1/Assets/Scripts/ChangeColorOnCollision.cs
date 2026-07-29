// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    [SerializeField] // SerializeField exposes 'changeColorTo' in the editor.
    private Color changeColorTo = Color.white;

    private void OnCollisionEnter()
    {
        // First we'll get the material used by this game object's 'Renderer'.
        var material = GetComponent<Renderer>().material;

        // Now we can change the colour of the material.
        material.color = this.changeColorTo;

        // NOTE: A 'material' specifies how the surface of an object should be
        // rendered. Materials are a pretty important construct in Unity, and
        // computer graphics more broadly. We'll learn about them more in future
        // weeks, but you want a head start, check out the following docs:
        //
        // - https://docs.unity3d.com/Manual/materials-introduction.html
        // - https://docs.unity3d.com/ScriptReference/Material.html
    }
}
