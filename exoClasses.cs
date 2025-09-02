using System;

public abstract class Article
{
    protected string designation;
    protected double prix;

    public Article(string designation, double prix)
    {
        this.designation = designation;
        this.prix = prix;
    }

    public string GetDesignation()
    {
        return designation;
    }

    public double GetPrix()
    {
        return prix;
    }

    public void SetDesignation(string designation)
    {
        this.designation = designation;
    }

    public void SetPrix(double prix)
    {
        this.prix = prix;
    }

    public void Acheter()
    {
        Console.WriteLine("Achat");
    }
}

public class Livre : Article
{
    protected string isbn;
    protected int nbPages;

    public Livre(string designation, double prix, string isbn, int nbPages) : base(designation, prix)
    {
        this.isbn = isbn;
        this.nbPages = nbPages;
    }

    public string GetIsbn()
    {
        return isbn;
    }

    public int GetNbPages()
    {
        return nbPages;
    }

    public void SetIsbn(string isbn)
    {
        this.isbn = isbn;
    }

    public void SetNbPages(int nbPages)
    {
        this.nbPages = nbPages;
    }
}

public class Disque : Article
{
    protected string label;

    public Disque(string designation, double prix, string label) : base(designation, prix)
    {
        this.label = label;
    }

    public string GetLabel()
    {
        return label;
    }

    public void SetLabel(string label)
    {
        this.label = label;
    }

    public void Ecouter()
    {
        Console.WriteLine("Ecouter");
    }
}

public class Video : Article
{
    protected int duree;

    public Video(string designation, double prix, int duree) : base(designation, prix)
    {
        this.duree = duree;
    }

    public int GetDuree()
    {
        return duree;
    }

    public void SetDuree(int duree)
    {
        this.duree = duree;
    }

    public void Afficher()
    {
        Console.WriteLine("Afficher");
    }
}

public class Poche : Livre
{
    private string categorie;

    public Poche(string designation, double prix, string isbn, int nbPages, string categorie) : base(designation, prix, isbn, nbPages)
    {
        this.categorie = categorie;
    }

    public string GetCategorie()
    {
        return categorie;
    }

    public void SetCategorie(string categorie)
    {
        this.categorie = categorie;
    }
}

public class Broche : Livre
{
    public Broche(string designation, double prix, string isbn, int nbPages) : base(designation, prix, isbn, nbPages)
    {
    }
}