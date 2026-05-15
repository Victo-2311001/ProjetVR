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
    }


    public void AjouterIngredient(string ingredient)
    {
        ingredientsJoueur.Add(ingredient);
    }

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
