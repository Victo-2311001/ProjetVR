using System.Collections.Generic;
using UnityEngine;

public class Recettes : MonoBehaviour
{
    public static Recettes Instance;

    List<string> vomitOgre = new List<string> { "Biere", "Oeuf", "Monster", "Vanille" };
    List<string> jusDeChaussette = new List<string> { "Saque", "Biere", "Vanille" };
    List<string> pisseOrangOutan = new List<string> { "Soda", "Monster", "Saque" };
    List<string> huileMoteur = new List<string> { "Monster", "Biere", "Oeuf", "Saque", "Vanille" };

    List<string> recetteActuelle = new List<string> { };

    List<string> ingredientsJoueur = new List<string> { };
    private void Awake()
    {
        Instance = this;
        ingredientsJoueur.Clear();
        recetteActuelle.Clear();
    }


    /// <summary>
    /// Ajoute l'ingrédient de l'utilisateur
    /// </summary>
    /// <param name="ingredient">L'ingrédient à ajouter</param>
    public void AjouterIngredient(string ingredient)
    {
        if (!ingredientsJoueur.Contains(ingredient))
        {
            ingredientsJoueur.Add(ingredient);
        }
    }

    /// <summary>
    /// Assigne la recette actuel
    /// </summary>
    /// <param name="recette">La recette choisi</param>
    public void DefinirRecetteActuelle(string recette)
    {
        if (recette == "Vômit d'ogre")
            recetteActuelle = vomitOgre;
        else if (recette == "Jus de chaussette")
            recetteActuelle = jusDeChaussette;
        else if (recette == "Pisse d'orang-outan")
            recetteActuelle = pisseOrangOutan;
        else if (recette == "Huile à moteur d'une grue")
            recetteActuelle = huileMoteur;
    }

    /// <summary>
    /// Vérifie si le joueur a gagner ou non
    /// </summary>
    public void VerifierRecette()
    {
        if(ingredientsJoueur.Count != recetteActuelle.Count)
        {
            GameController.Instance.Defaite();
            return;
        }

        for (int i = 0; i < recetteActuelle.Count; i++)
        {
            if (!ingredientsJoueur.Contains(recetteActuelle[i]))
            {
                GameController.Instance.Defaite();
                return;
            }
        }

        GameController.Instance.Victoire();
    }
}
