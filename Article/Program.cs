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
