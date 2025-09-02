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

struct Articles
{
    private Article[] liste;
    private int taille;
    public Articles()
    {
        this.liste = Array.Empty<Article>();
        this.taille = 0;
    }

    public int Taille
    {
        get => taille;
    }

    public Article[] Liste
    {
        get => liste;
        set{
            liste = value;
            taille = value.Length;
        }
    }

    public Article this[int index]
    {
        get
        {
            if (index < 0 || index >= taille)
            {
                throw new IndexOutOfRangeException("Index hors limites.");
            }
            return liste[index];
        }
        set
        {
            if (index < 0 || index >= taille)
            {
                throw new IndexOutOfRangeException("Index hors limites.");
            }
            liste[index] = value;
        }
    }
    public void Ajouter(Article article)
    {
        Array.Resize(ref liste, taille + 1);
        liste[taille] = article;
        taille++;
    }

    public void Retirer(int index)
    {
        if (index < 0 || index >= taille)
        {
            throw new IndexOutOfRangeException("Index hors limites.");
        }
        for (int i = index; i < taille - 1; i++)
        {
            liste[i] = liste[i + 1];
        }
        Array.Resize(ref liste, taille - 1);
        taille--;
    }

    public void Vider()
    {
        liste = Array.Empty<Article>();
        taille = 0;
    }

    public override string ToString()
    {
        if (taille == 0)
        {
            return "Aucun article";
        }
        string result = "Articles:\n";
        foreach (var article in liste)
        {
            result += article.Afficher() + "\n";
        }
        return result;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Debut du test");
        Articles articles = new Articles();
        Console.WriteLine(articles);
        articles.Ajouter(new Article("test 1", 1.5, 10, TypeArticle.Alimentaire));
        articles.Ajouter(new Article("test 2", 2.2, 5, TypeArticle.Droguerie));
        articles.Ajouter(new Article("test 3", 15.0, 20, TypeArticle.Habillement));
        Console.WriteLine(articles);
        Article tempArticle = articles[0];
        tempArticle.Ajouter();
        articles[0] = tempArticle;
        tempArticle = articles[1];
        tempArticle.Retirer(60);
        articles[1] = tempArticle;
        articles[2] = new Article("test 3 BIS", 5.0, 4, TypeArticle.Loisir);
        Console.WriteLine(articles);
        articles.Vider();
        Console.WriteLine(articles);
    }
}
