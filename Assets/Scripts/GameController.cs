using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Classe responsable pour gérer les écrans, l'affichage des points et timer, et fonctions principales du jeu
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public enum EtatJeu { Menu, EnJeu, GameOver }

    [Header("Canvas")]
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasHUD;
    [SerializeField] private GameObject canvasGameOver;

    [Header("Textes")]
    [SerializeField] private TextMeshProUGUI texteTimer;
    [SerializeField] private TextMeshProUGUI texteFin;
    [SerializeField] private TextMeshProUGUI texteDrink;


    List<string> drinks = new List<string>();

    public EtatJeu etatActuel { get; private set; }

    [SerializeField] private float dureePartie = 60f;
    private float tempsEcoule;
    private bool timerActif;

    private bool victoire = false;
    public bool partieTerminee { get; private set; }

    //Singleton pour accèder le GameController dans les autres classes
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        partieTerminee = false;
    }

    //Afficher le menu principal et peupler la list de drinks
    private void Start()
    {
        ChangerEtat(EtatJeu.Menu);
        ChargerListDrinks();
    }

    void Update()
    {
        if (timerActif)
        {
            tempsEcoule += Time.deltaTime;
            AfficherTimer();

            //Terminer jeu si temps écoulé
            if (tempsEcoule >= dureePartie)
            {
                if (victoire)
                {
                    Victoire();
                }
                else
                {
                    Defaite();
                }
            }

        }
    }

    private void ChargerListDrinks()
    {
        drinks.Add("Vômit d'ogre");
        drinks.Add("Jus de chaussette");
        drinks.Add("Pisse d'orang-outan");
        drinks.Add("Huile à moteur d'une grue");
    }

    //Changer l'écran affichée selon l'état du jeu
    public void ChangerEtat(EtatJeu nouvelEtat)
    {
        etatActuel = nouvelEtat;
        canvasMenu.SetActive(etatActuel == EtatJeu.Menu);
        canvasHUD.SetActive(etatActuel == EtatJeu.EnJeu);
        canvasGameOver.SetActive(etatActuel == EtatJeu.GameOver);
    }

    public void CommencerPartie()
    {
        tempsEcoule = 0f;
        timerActif = true;
        partieTerminee = false;
        ChangerEtat(EtatJeu.EnJeu);
        ChoisirDrink();
    }

    private void ChoisirDrink()
    {
        int indexAleatoire = Random.Range(0, drinks.Count);
        string drinkChoisi = drinks[indexAleatoire];

        Recettes.Instance.DefinirRecetteActuelle(drinkChoisi);

        texteDrink.text = "Faite le cocktail nommé: " + drinkChoisi;
    }

    //Afficher l'écran final de victoire
    public void Victoire()
    {
        timerActif = false;
        texteFin.text = "Jeu terminé, vous avez gagné";
        ChangerEtat(EtatJeu.GameOver);
    }

    //Afficher l'écran final de défaite
    public void Defaite()
    {
        timerActif = false;
        texteFin.text = "Jeu terminé, vous avez perdu";
        ChangerEtat(EtatJeu.GameOver);
    }

    //Relancer le menu principal
    public void Rejouer()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    //penalite de 3 secondes pour objet "cassé"
    public void Penalite()
    {
        tempsEcoule += 3f;
    }

    //Convertir et afficher le temps
    private void AfficherTimer()
    {
        int minutes = Mathf.FloorToInt(tempsEcoule / 60f);
        int secondes = Mathf.FloorToInt(tempsEcoule % 60f);
        texteTimer.text = $"{minutes:00}:{secondes:00}";
    }
}