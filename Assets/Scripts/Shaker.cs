using UnityEngine;

public class Shaker : MonoBehaviour
{
    /// <summary>
    /// Envoi l'ingrédient quand il touche le shaker
    /// </summary>
    /// <param name="other">L'ingrédient</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Biere"))
            Recettes.Instance.AjouterIngredient("Biere");
        else if (other.CompareTag("Saque"))
            Recettes.Instance.AjouterIngredient("Saque");
        else if (other.CompareTag("Vanille"))
            Recettes.Instance.AjouterIngredient("Vanille");
        else if (other.CompareTag("Soda"))
            Recettes.Instance.AjouterIngredient("Soda");
        else if (other.CompareTag("Monster"))
            Recettes.Instance.AjouterIngredient("Monster");
        else if (other.CompareTag("Oeuf"))
            Recettes.Instance.AjouterIngredient("Oeuf");
    }
}
