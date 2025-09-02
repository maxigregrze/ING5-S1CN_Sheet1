using System;
using System.Drawing;

enum TypeArticle
{
    Alimentaire,
    Droguerie,
    Habillement,
    Loisir
}

struct Article
{
    private string nom;
    private double prix;
    private int quantite;
    private TypeArticle type;

    public string Nom
    {
        get => nom;
        set => nom = value;
    }

    public double Prix
    {
        get => prix;
        set => prix = value;
    }

    public int Quantite
    {
        get => quantite;
        set
        {
            if (value < 0)
                throw new ArgumentException("La quantité doit être positive ou nulle.");
            quantite = value;
        }
    }

    public TypeArticle Type
    {
        get => type;
        set => type = value;
    }

    public string Afficher()
    {
        return $"Nom: {nom}, Prix: {prix}, Quantité: {quantite}, Type: {type}";
    }

    public void Ajouter(int ajout = 1)
    {
        if (ajout < 0)
        {
            throw new ArgumentException("La quantité à ajouter ne peut pas être négative.");
        }
        quantite += ajout;
    }

    public void Retirer(int retrait = 1)
    {
        if (retrait < 0)
        {
            throw new ArgumentException("La quantité à retirer ne peut pas être négative.");
        }
        else if (quantite - retrait >= 0)
        {
            quantite -= retrait;
        }
        else
        {
            quantite = 0;
        }
    }

    public Article(string nom, double prix, int quantite, TypeArticle type)
    {
        this.nom = nom;
        this.prix = prix;
        this.quantite = quantite;
        this.type = type;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Debut du test");
        Console.WriteLine("Partie 1 : test auto");
        Article[] articles = new Article[]
        {
            new Article("test 1", 1.5, 10, TypeArticle.Alimentaire),
            new Article("test 2", 2.2, 5, TypeArticle.Droguerie),
            new Article("test 3", 15.0, 20, TypeArticle.Habillement)
        };
        foreach (var article in articles)
        {
            Console.WriteLine(article.Afficher());
        }
        articles[0].Ajouter();
        articles[1].Retirer(60);
        try
        {
            articles[2].Ajouter(-5);
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erreur lors de l'ajout : {error.Message}");
        }
        foreach (var article in articles)
        {
            Console.WriteLine(article.Afficher());
        }
        Console.WriteLine("Partie 2 : test manuel");
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nom))
        {
            Console.Write("Le nom ne peut pas etre vide. Veuillez entrer un nom valide : ");
            nom = Console.ReadLine();
        }
        double prix = 0;
        while (true)
        {
            try
            {
                Console.Write("Prix : ");
                prix = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch (Exception error)
            {
                Console.WriteLine($"Erreur, {error.Message}. Veuillez réessayez avec un prix valide.");
            }
        }
        int quantite = -1;
        while (true)
        {
            try
            {
                Console.Write("Quantité : ");
                quantite = Convert.ToInt16(Console.ReadLine());
                if (quantite >= 0)
                    break;
                else
                    throw new ArgumentException("La quantité ne peut pas être négative.");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Erreur, {error.Message}. Veuillez reessayez avec une quantitée positive.");
            }
        }
        TypeArticle type;
        while (true)
        {
            try
            {
                Console.WriteLine("Type :");
                foreach (TypeArticle t in Enum.GetValues(typeof(TypeArticle)))
                {
                    Console.WriteLine($"{(int)t} : {t}");
                }
                int typeNbr = Convert.ToInt16(Console.ReadLine());
                if (typeNbr >= 0 && typeNbr < Enum.GetValues(typeof(TypeArticle)).Length)
                {
                    type = (TypeArticle)typeNbr;
                    break;
                }
                else
                {
                    throw new ArgumentException("Le numéro ne correspond pas à l'un des types indiqués");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Erreur, {error.Message}. Veuillez réessayer avec une valeur correcte.");
            }
        }


        Article nouvelArticle = new Article(nom, prix, quantite, type);
        Console.WriteLine("Nouvel article crée :");
        Console.WriteLine(nouvelArticle.Afficher());
    }
}
